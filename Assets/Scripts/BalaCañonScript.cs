using UnityEngine;
using System.Collections;


public class BalaCañonScript : MonoBehaviour {

    private GameObject protagonista;
    public GameObject explosion;

    // Use this for initialization
	void Start () {
        GetComponent<Transform>().position = protagonista.GetComponent<Transform>().position;
        Destroy(gameObject, 2);
	}
	
    public void SetProtagonista(GameObject p)
    {
        protagonista = p;
    }

    void OnDestroy()
    {
        GameObject e = Instantiate(explosion);
        e.GetComponent<Transform>().position = gameObject.transform.position;
        e.layer = gameObject.layer;
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        Destroy(gameObject);
        if (c.gameObject.tag=="Enemigo")
            c.gameObject.GetComponent<EnemigoScript>().RecibeDaño();
        else if (c.gameObject.tag=="Protagonista")
            GameObject.FindGameObjectWithTag("UI").GetComponent<IUScript>().DisminuyeVida();
    }
}
