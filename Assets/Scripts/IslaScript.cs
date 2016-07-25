using UnityEngine;
using System.Collections;

public class IslaScript : MonoBehaviour {

    public float velocidadIsla;
    [HideInInspector]
    public GameObject generador;
	
	// Update is called once per frame
    void Update()
    {
        if (Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x > transform.position.x + GetComponent<SpriteRenderer>().sprite.bounds.extents.x)
        {
            generador.GetComponent<GeneradorEntidadesScript>().MatarEntidad(gameObject.tag);
            Destroy(gameObject);
        }
    }

	void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-velocidadIsla, 0);
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag=="Protagonista")
           GameObject.FindGameObjectWithTag("UI").GetComponent<IUScript>().DisminuyeVida();
    }
}
