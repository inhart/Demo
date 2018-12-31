
using UnityEngine;

public class SeleccionPersonaje : MonoBehaviour {
    public static SeleccionPersonaje sp;
    public GameObject[] Players;
    public int selectedPlayer = 0;
    private GameObject cross;
    public Camera camara;
    public float desp;
    public GameObject floor;

    private void Awake()
    {
      
        if (sp == null)
        {
            sp = this;
        }
        else {
            Destroy(this);
        }
       
        cross = GameObject.Find("Crosshair");
        camara = GameObject.FindObjectOfType<Camera>();
    }


    void Start ()
    {
		
        foreach(GameObject obj in Players)
        {
            if(obj.GetComponent<PlayerMovement_Pang>() != null)
            {
                obj.GetComponent<PlayerMovement_Pang>().enabled = false;
                cross.SetActive(false);
            }
            if (obj.GetComponent<PlayerMovement>() != null)
            {
                obj.GetComponent<PlayerMovement>().enabled = false;
            }
            if (obj.GetComponent<Tumble_behavior>()!= null)
            {
                obj.GetComponent<Tumble_behavior>().enabled = false;
            }
           
            if (obj.GetComponent<Snow_Behavior>() != null)
            {
                obj.GetComponent<Snow_Behavior>().enabled = false;
            }

        }
        SeleccionPers(Random.Range(0,3));
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
       
        
        switch (selectedPlayer)
        {
            case 0:
                GameController.gc.LastSelected = GameController.gc.CurrentSelected;
                GameController.gc.CurrentSelected = Players[selectedPlayer];
                Players[1].GetComponent<Snow_Behavior>().enabled = false;
                Players[1].GetComponent<PlayerMovement>().enabled = false;
                Players[2].GetComponent<PlayerMovement>().enabled = false;
                Players[2].GetComponent<Tumble_behavior>().enabled = false;

                cross.SetActive(true);
                Players[0].GetComponent<PlayerMovement>().enabled = true;
                
                
                break;
            case 1:
                GameController.gc.LastSelected = GameController.gc.CurrentSelected;
                GameController.gc.CurrentSelected = Players[selectedPlayer];
                Players[0].GetComponent<PlayerMovement>().enabled = false;
                
                cross.SetActive(false);
                Players[2].GetComponent<PlayerMovement>().enabled = false;
                Players[2].GetComponent<Tumble_behavior>().enabled = false;
                Players[1].GetComponent<PlayerMovement>().enabled = true;
                Players[1].GetComponent<Snow_Behavior>().enabled = true;
                
                break;
            case 2:
                GameController.gc.LastSelected = GameController.gc.CurrentSelected;
                GameController.gc.CurrentSelected = Players[selectedPlayer];
                Players[1].GetComponent<PlayerMovement>().enabled = false;
                Players[1].GetComponent<Snow_Behavior>().enabled = false;
                cross.SetActive(false);
                Players[0].GetComponent<PlayerMovement>().enabled = false;
                
                Players[2].GetComponent<PlayerMovement>().enabled = true;
                Players[2].GetComponent<Tumble_behavior>().enabled = true;
                

                break;

        }
        
            
                camara.transform.position = new Vector3(Players[selectedPlayer].transform.position.x, Players[selectedPlayer].transform.position.y + desp, -10f);
            
        
       
    }
    
    public void SeleccionPers(int pers)
    {
        selectedPlayer = pers;
    }
   
    
}
