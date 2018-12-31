using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootController : MonoBehaviour {

    public PlayerController_tp p_c;
    public GameObject RightCollider;
    public GameObject LeftCollider;
    public GameObject aspright;
    public GameObject aspright2;
    public GameObject aspright3;
    public GameObject aspright4;
    public GameObject aspright5;
    public GameObject aspright6;
    public GameObject aspright7;
    public GameObject aspleft;
    public GameObject aspleft2;
    public GameObject aspleft3;
    public GameObject aspleft4;
    public GameObject aspleft5;
    public GameObject aspleft6;
    public GameObject aspleft7;
    public AudioSource ShootSound;
    public AudioClip StartSound;
    public AudioClip FollowSound;

    public float Magnitude = 2f;
    public float Roughness = 10f;
    public float FadeOutTime = 5f;

    public CameraShake CameraShake;

    public ParticleSystem MyParticle;
    public ParticleSystem MyParticle2;
    public PowerController pw;

    // Use this for initialization
    void Start () {
        RightCollider.SetActive(false);
        LeftCollider.SetActive(false);
        CameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
        pw = gameObject.GetComponent<PowerController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            CameraShake.ShakeCamera(0.10f,25);
            if ((p_c.IsFlipped == false) && (pw.PowerIsOn == false))
            {
                RightCollider.SetActive(true);
                LeftCollider.SetActive(false);
                aspright.GetComponent<Animation>().Play("NewShootAnim");
                aspright2.GetComponent<Animation>().Play("NewShootAnim 1");
                aspright3.GetComponent<Animation>().Play("NewShootAnim 2");
                aspright4.GetComponent<Animation>().Play("NewShootAnim 3");
                aspright5.GetComponent<Animation>().Play("NewShootAnim 4");
                aspright6.GetComponent<Animation>().Play("NewShootAnim 5");
                aspright7.GetComponent<Animation>().Play("NewShootAnim 6");
                aspright.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspright2.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspright3.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspright4.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspright5.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspright6.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspright7.GetComponentInChildren<Image>().fillAmount += 0.1f;
                ShootSound.PlayOneShot(StartSound, 0.7f);
                ShootSound.PlayDelayed(1);
                gameObject.GetComponent<Animator>().SetBool("Shooting", true);
                MyParticle.gameObject.SetActive(true);
            }
            if ((p_c.IsFlipped == true) && (pw.PowerIsOn == false))
            {
                RightCollider.SetActive(false);
                LeftCollider.SetActive(true);
                aspleft.GetComponent<Animation>().Play("NewShootAnim");
                aspleft2.GetComponent<Animation>().Play("NewShootAnim 1");
                aspleft3.GetComponent<Animation>().Play("NewShootAnim 2");
                aspleft4.GetComponent<Animation>().Play("NewShootAnim 3");
                aspleft5.GetComponent<Animation>().Play("NewShootAnim 4");
                aspleft6.GetComponent<Animation>().Play("NewShootAnim 5");
                aspleft7.GetComponent<Animation>().Play("NewShootAnim 6");
                aspleft.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspleft2.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspleft3.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspleft4.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspleft5.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspleft6.GetComponentInChildren<Image>().fillAmount += 0.1f;
                aspleft7.GetComponentInChildren<Image>().fillAmount += 0.1f;
                ShootSound.PlayOneShot(StartSound, 0.7f);
                ShootSound.PlayDelayed(1);
                gameObject.GetComponent<Animator>().SetBool("Shooting", true);
                MyParticle2.gameObject.SetActive(true);
            }
        }
        else
        {
            if(gameObject.GetComponent<PowerController>().PowerIsOn == true)
            {

            }
            else
            {
                RightCollider.SetActive(false);
                LeftCollider.SetActive(false);
                MyParticle.gameObject.SetActive(false);
                MyParticle2.gameObject.SetActive(false);
                ShootSound.Stop();
                gameObject.GetComponent<Animator>().SetBool("Shooting", false);
            }
            
        }
        if((aspright.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspright.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspright2.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspright2.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspright3.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspright3.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspright4.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspright4.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspright5.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspright5.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspright5.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspright5.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspright6.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspright6.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspright7.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspright7.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspleft.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspleft.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspleft2.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspleft2.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspleft3.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspleft3.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspleft4.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspleft4.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspleft5.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspleft5.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspleft5.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspleft5.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspleft6.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspleft6.GetComponent<Image>().fillAmount = 0;
        }
        if ((aspleft7.GetComponent<Image>().fillAmount == 1) && (!Input.GetKey(KeyCode.Mouse0)) || (!Input.GetButton("Fire1")))
        {
            aspleft7.GetComponent<Image>().fillAmount = 0;
        }
    }
}
