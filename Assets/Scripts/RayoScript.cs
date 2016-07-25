using UnityEngine;
using System.Collections;

public class RayoScript : MonoBehaviour {
    [HideInInspector]
    public GameObject nube;
    public float tiempoRay;

	// Use this for initialization
	void Start () {
        Vector3 t = nube.GetComponent<Transform>().position;
        t.x -= 0.5f;
        t.y -= 2f;
        transform.position = t;
        Destroy(gameObject, tiempoRay);
	}
	
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Protagonista")
        {
            //PRIMERA EXPRESION PARA COMPROBAR QUE NO HA COLISIONADO EN EL BOXCOLLIDER DEL DRAG AND DROP
            if (c.gameObject.GetComponent<AtributosPersonaje>()!=null && c.gameObject.GetComponent<AtributosPersonaje>().escudoActivado == true)
                GameObject.FindGameObjectWithTag("UI").GetComponent<IUScript>().AumentaPuntuacion();
            else
                GameObject.FindGameObjectWithTag("UI").GetComponent<IUScript>().DisminuyeVida();
            Destroy(gameObject);
        }
    }
}
