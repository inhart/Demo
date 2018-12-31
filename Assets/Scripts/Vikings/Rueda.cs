
using UnityEngine;

public enum Tercio {primer,segundo,tercero};
public class Rueda : MonoBehaviour {
    public Tercio tercio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponent<Animator>().GetBool("Highlighted"))
        {
            if (tercio == Tercio.primer)
            {
                SeleccionPersonaje.sp.SeleccionPers(0);
            }
            if (tercio == Tercio.segundo)
            {
                SeleccionPersonaje.sp.SeleccionPers(1);
            }
            if (tercio == Tercio.tercero)
            {
                SeleccionPersonaje.sp.SeleccionPers(2);
            }
        }
	}
}
