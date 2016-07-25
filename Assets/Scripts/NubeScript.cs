using UnityEngine;
using System.Collections;

public class NubeScript : MonoBehaviour {

    private float ladoIzq, ladoDer;
    private bool moviendoIzquierda;
    private float mitadTamNube;
    public float velocidad=1;
    public GameObject rayo;
    private float tiempoUltRay;
    public float tiempoEntreRay=2.5f;
    private bool mover;

	// Use this for initialization
	void Start () {
        ladoIzq = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        ladoDer = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        moviendoIzquierda = true;
        mitadTamNube = GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        tiempoUltRay = Time.realtimeSinceStartup;
        mover = true;
        transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
    void Update()
    {
        ComprobarMov();
        if (Time.realtimeSinceStartup > tiempoUltRay + tiempoEntreRay)
            InvocarRayo();
    }

	void FixedUpdate () {
        if (mover)
        {
            if (moviendoIzquierda)
                GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidad, 0);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(velocidad, 0);
        }
	}

    void InvocarRayo()
    {
        //PARO LA NUBE
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = true;
        mover = false;
        //ESPERO
        GetComponent<AudioSource>().Play();
        StartCoroutine("LanzarRayo");
        
        tiempoUltRay = Time.realtimeSinceStartup + 5;//PARA QUE NO VUELVA A LANZAR OTRO RAYO
    }

    void ComprobarMov()
    {
        if (moviendoIzquierda)
        {
            if (transform.position.x - mitadTamNube < ladoIzq)
                moviendoIzquierda = false;
        }
        else
        {
            if (transform.position.x + mitadTamNube > ladoDer)
                moviendoIzquierda = true;
        }
    }

    IEnumerator LanzarRayo()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject creado = Instantiate(rayo);
        creado.GetComponent<RayoScript>().nube = gameObject;
        yield return new WaitForSeconds(1f);
        transform.GetChild(0).gameObject.GetComponent<Renderer>().enabled = false;
        mover = true;
        tiempoUltRay = Time.realtimeSinceStartup;
    }
}
