using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType { Tumble,Snow,Pang};

public class PlayerMovement : MonoBehaviour
{
    public float speed = 2f;
    public float jumpSpeed = 3f;
    public bool groundCheck;
    public bool isSwinging;
    public bool blink;
    private Rigidbody2D rBody;
    private bool isJumping;
    private Animator animator;
    private float jumpInput;
    private float horizontalInput;
    public float grounCheckDist = 0.04f;
    public Vector2 ropeHook;
    public float swingForce = 4f;
    public Vector3 lastPos;
    public PlayerType pt;
    public float detectionRadius = 0.035f;
    public GameObject lurraChecker;
    SpriteRenderer[] sR;
    public float fBalanceo;
   

    private void Awake()
    {
        if (gameObject.name.Contains("Tumble"))
        {
            pt = PlayerType.Tumble;
        }
        if (gameObject.name.Contains("Snow"))
        {
            pt = PlayerType.Snow;
        }
        if (gameObject.name.Contains("Pang"))
        {
            pt = PlayerType.Pang;
        }
        sR = gameObject.transform.GetComponentsInChildren<SpriteRenderer>();
        rBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
   private void Update()
    {
       
        jumpInput = Input.GetAxis("Jump");
        horizontalInput = Input.GetAxis("Horizontal");
        
        var myLayerMask = ~(1 << LayerMask.NameToLayer("Caput") | 1<< LayerMask.NameToLayer("Player")); // ignore collisions with layerX
        groundCheck = Physics2D.OverlapCircle(lurraChecker.transform.position, detectionRadius,myLayerMask);
       
        if (groundCheck)
        {
            lastPos = transform.position;
        }

    }
    private void FixedUpdate()
    {
        
        if (horizontalInput != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
            
            if (pt == PlayerType.Tumble)
            {
                if (Tumble_behavior.tb.kutxa == null && gameObject.name.Contains("Tumble"))
                {
                    MovLateral();
                }
            }
            if (pt == PlayerType.Snow)
            {
                MovLateral();
            }
            if (pt == PlayerType.Pang)
            {
                //   playerSprite.flipX = horizontalInput < 0f;
                MovLateral();
                if (isSwinging)
                {
                    animator.SetBool("IsSwinging", true);

                    // 1 - Get a normalized direction vector from the player to the hook point
                    var playerToHookDirection = (ropeHook - (Vector2)transform.position).normalized;

                    // 2 - Inverse the direction to get a perpendicular direction
                    Vector2 perpendicularDirection;
                    if (horizontalInput < 0)
                    {
                        perpendicularDirection = new Vector2(-playerToHookDirection.y, playerToHookDirection.x);
                        var leftPerpPos = (Vector2)transform.position - perpendicularDirection * -fBalanceo;
                        Debug.DrawLine(transform.position, leftPerpPos, Color.green, 0f);
                    }
                    else
                    {
                        perpendicularDirection = new Vector2(playerToHookDirection.y, -playerToHookDirection.x);
                        var rightPerpPos = (Vector2)transform.position + perpendicularDirection * fBalanceo;
                        Debug.DrawLine(transform.position, rightPerpPos, Color.green, 0f);
                    }

                    var force = perpendicularDirection * swingForce;
                    rBody.AddForce(force, ForceMode2D.Force);
                }

            }
            if (Pang_Behavior.rs.ropeAttached)
            {
                Pang_Behavior.rs.HandleRopeLength();
                rBody.AddForce(new Vector2(0f, 0f));

            }

            if (!isSwinging)
            {
                animator.SetBool("IsSwinging", false);
                var groundForce = speed * 2f;
                rBody.AddForce(new Vector2((horizontalInput * groundForce - rBody.velocity.x) * groundForce, 0));
                rBody.velocity = new Vector2(rBody.velocity.x, rBody.velocity.y);
            }
        }

        if (horizontalInput == 0)
        {
            animator.SetFloat("Speed", 0.0f);
        }

            if (!isSwinging)
        {
            if (!groundCheck) return;

            isJumping = jumpInput > 0f;
            if (isJumping)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, jumpSpeed);
                gameObject.GetComponent<Animator>().SetBool("Jumping", true);
            }
            else
            {
                gameObject.GetComponent<Animator>().SetBool("Jumping", false);
            }

          
        }
    }
      void MovLateral()
    {
        var scala = transform.localScale;
        if (horizontalInput < 0)
        {
          
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (horizontalInput > 0)
        {
           
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            // gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    public void Pupita()
    {
        StartCoroutine(Blinking());
    }
    public IEnumerator Blinking()
    {
        blink = true;
        for (int i = 0; i < 8; i++)
        {
            if (blink)
            {
                foreach (SpriteRenderer sr in sR)
                {
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
                }
                yield return new WaitForSeconds(0.2f);

                foreach (SpriteRenderer sr in sR)
                {
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
                }

                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                break;
            }
        }
        blink = false;
    }


}
