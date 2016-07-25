using UnityEngine;
using System.Collections;

public class VidaScript : MonoBehaviour {
    
    [HideInInspector]
    public GameObject generador;
    public float velocidadVida=3;
	
	void Update () {
        if (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x > transform.position.x + GetComponent<SpriteRenderer>().sprite.bounds.extents.x)
        {
            generador.GetComponent<GeneradorEntidadesScript>().MatarEntidad(gameObject.tag);
            Destroy(gameObject);
        }
	}

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadVida, 0);
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag=="Protagonista")
        {
            GetComponent<AudioSource>().Play();
            GameObject.FindGameObjectWithTag("UI").GetComponent<IUScript>().AumentaVida();

            GetComponent<Renderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            //MORIRA CUANDO SALGA DE LA PANTALLA
        }
    }
}
