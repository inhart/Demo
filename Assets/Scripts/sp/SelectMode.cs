using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMode : MonoBehaviour {
    public Image tourModeImage;
    public Text tourModeText;
    public Image panicModeImage;
    public Text panicModeText;

    public bool mode;
    // Use this for initialization
    void Start () {
        mode = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (mode)
        {
            tourModeImage.color = new Color(1, 1, 1);
            tourModeText.color = new Color(1, 1, 1);
            panicModeImage.color = new Color(1, 1, 0,0.5f);
            panicModeText.color = new Color(1, 1, 0, 0.5f);

            if (Input.GetAxis("Horizontal")>0)
            {
                mode = false;
            }
            if (Input.GetAxis("Jump")!=0)
            {
                SceneManager.LoadScene("Tour_01");
            }
        }
        else
        {
            tourModeImage.color = new Color(1, 1, 0, 0.5f);
            tourModeText.color = new Color(1, 1, 0, 0.5f);
            panicModeImage.color = new Color(1, 1, 1);
            panicModeText.color = new Color(1, 1, 1);

            if (Input.GetAxis("Horizontal") < 0)
            {
                mode = true;
            }
            if (Input.GetAxis("Jump") != 0)
            {
                SceneManager.LoadScene("Panic");
            }
        }
        
       
    }
}
