using UnityEngine;
using System.Collections;

public class EnemigoScript : MonoBehaviour {
    private GameObject protagonista;
    public byte vidaInicial;
    private byte vida;
    public byte distanciaAcercar;
    public byte velocidadDisparo;
    public float esperaEntreDisparos;
    public GameObject bala;
    [HideInInspector]
    public GameObject generador;

    void Start()
    {
        vida = vidaInicial;
        protagonista = GameObject.FindGameObjectWithTag("Protagonista");
        StartCoroutine("Disparar");
    }

	// Update is called once per frame
	void Update () {
        Mover();
	}

    void Mover()
    {
        Vector3 dir = protagonista.GetComponent<Transform>().position - transform.position;
        if (dir.magnitude > distanciaAcercar)
            GetComponent<Rigidbody2D>().velocity = new Vector2(dir.normalized.x, dir.normalized.y);
        else
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    IEnumerator Disparar()
    {
        while (true)
        {
            Vector3 dir = protagonista.GetComponent<Transform>().position - transform.position;
            dir=dir.normalized;
            GameObject b = Instantiate(bala);
            b.GetComponent<BalaCañonScript>().SetProtagonista(gameObject);
            b.GetComponent<Rigidbody2D>().velocity= new Vector2(dir.x * velocidadDisparo, dir.y * velocidadDisparo);
            b.GetComponent<Rigidbody2D>().gravityScale = 0;
            b.layer = 10;
            yield return new WaitForSeconds(esperaEntreDisparos);
        }
    }

    public void RecibeDaño()
    {
        vida--;
        if (vida == 0)
        {
            generador.GetComponent<GeneradorEntidadesScript>().MatarEntidad(gameObject.tag);
            Destroy(gameObject);
        }
    }
}
