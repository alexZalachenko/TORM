using UnityEngine;
using System.Collections;

public class GeneradorEntidadesScript : MonoBehaviour {

    public GameObject isla;
    public GameObject enemigo;
    public GameObject vida;
    public byte maxIslaSimult = 0;
    public byte maxEnemSimult = 0;
    public byte maxVidaSimult = 0;
    public float interIslas = 1;
    public float interEnem = 1;
    public float interVida = 1;
    private byte islasAct = 0;
    private byte enemAct = 0;
    private byte vidaAct = 0;

    void Update()
    {
        if (islasAct < maxIslaSimult)
        {
            islasAct++;
            StartCoroutine(CreaEntidad(interIslas, isla));
        }
        if (enemAct < maxEnemSimult)
        {
            enemAct++;
            StartCoroutine(CreaEntidad(interEnem, enemigo));
        }
        if (vidaAct < maxVidaSimult)
        {
            vidaAct++;
            StartCoroutine(CreaEntidad(interVida, vida));
        }
    }

    IEnumerator CreaEntidad(float intervalo, GameObject entidad)
    {
        yield return new WaitForSeconds(intervalo);
        GameObject c = Instantiate(entidad);
        float x = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x + c.GetComponent<SpriteRenderer>().sprite.bounds.extents.x;
        float yMax = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - c.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        float yMin = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + c.GetComponent<SpriteRenderer>().sprite.bounds.extents.y;
        float y = Random.Range(yMin, yMax);
        c.transform.position = new Vector2(x, y);
        if (entidad == isla)
            c.GetComponent<IslaScript>().generador = gameObject;
        else if (entidad == enemigo)
            c.GetComponent<EnemigoScript>().generador = gameObject;
        else if (entidad == vida)
            c.GetComponent<VidaScript>().generador = gameObject;
    }

    public void MatarEntidad(string tag)
    {
        if (tag=="Enemigo")
            enemAct--;
        else if (tag=="Isla")
            islasAct--;
        else if (tag=="Vida")
            vidaAct--;
    }
}
