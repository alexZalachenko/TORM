using UnityEngine;
using System.Collections;

public class DragAndDrop : MonoBehaviour {

    public LineRenderer linea1;
    public GameObject bala;
    public float maxEstirar=3.0f;
    private float maxEstirarSqr;
    private bool clicado;
    private Ray rayoAlCursor;
    private GameObject protagonista;
    private SpringJoint2D spring;
    private Vector2 anteriorVel;
    
	// Use this for initialization
	void Start () {
        linea1.enabled = false;
        protagonista = gameObject.transform.parent.gameObject;
        rayoAlCursor = new Ray(protagonista.transform.position, Vector3.zero);
        maxEstirarSqr = maxEstirar * maxEstirar;
        spring = GetComponent<SpringJoint2D>();
        anteriorVel.x = anteriorVel.y = 0;
        clicado = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (clicado==true)
        {
            DibujaLinea();
            RatonPulsado();
        }
        else
            SoltarBomba();
	}

    void DibujaLinea()
    {
        linea1.SetPosition(0, gameObject.transform.position);
        linea1.SetPosition(1, protagonista.transform.position);
    }

    void OnMouseDown()
    {
        clicado = true;
        linea1.enabled = true;
        protagonista.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void OnMouseUp()
    {
        GetComponent<Rigidbody2D>().isKinematic = false;
        clicado = false;
        linea1.enabled = false;
    }

    void RatonPulsado()
    {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = transform.position.z - Camera.main.transform.position.z;
            //POSICION RATON EN COORDENADAS MUNDO
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            
            Vector2 vectProtaCursor = mousePos - protagonista.transform.position;
            if (vectProtaCursor.sqrMagnitude > maxEstirarSqr)
            {
                rayoAlCursor.origin = protagonista.transform.position;
                rayoAlCursor.direction = vectProtaCursor;
                mousePos = rayoAlCursor.GetPoint(maxEstirar);
            }
            transform.position = mousePos;
    }

    void SoltarBomba()
    {
        if (spring!=null)
        {
            //DECELERAMOS.
            if (anteriorVel.sqrMagnitude > GetComponent<Rigidbody2D>().velocity.sqrMagnitude)
            {
                GameObject c = Instantiate(bala);
                c.GetComponent<BalaCañonScript>().SetProtagonista(protagonista);
                c.GetComponent<Rigidbody2D>().velocity = anteriorVel;
                protagonista.GetComponent<AudioSource>().Play();

                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GetComponent<Rigidbody2D>().isKinematic = true;
                transform.localPosition = new Vector3(0, 0, -0.5f);
                anteriorVel = new Vector2(0, 0);

                protagonista.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            //ACELERAMOS. CUANDO AUN NO HEMOS HECHO CLIC UP ENTRA SIEMPRE EN ESTE METODO PQ LAS VELOCIDADES SON 0
            else
                anteriorVel = GetComponent<Rigidbody2D>().velocity;
        }
    }
}
