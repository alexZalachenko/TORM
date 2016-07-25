using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IUScript : MonoBehaviour {

    public GameObject protagonista;
    public GameObject corazon;
    public GameObject puntuacion;
    public GameObject[] vidas;
    public GameObject generadorEnt;

	// Use this for initialization
	void Start () {
        vidas = new GameObject[protagonista.GetComponent<AtributosPersonaje>().vidaInicial];
        PintarVidas();
    }
	
	// Update is called once per frame
	void Update () {
        /*if (ultimaVidaMostrada!=protagonista.GetComponent<AtributosPersonaje>().vida)
        {
            if (protagonista.GetComponent<AtributosPersonaje>().vida == 0)
                SceneManager.LoadScene(2);
            else
            {
                GameObject borrar = null;
                foreach (GameObject corazon in GameObject.FindGameObjectsWithTag("Corazon"))
                {
                    if (borrar == null)
                        borrar = corazon;
                    else if (borrar.transform.position.x < corazon.transform.position.x)
                        borrar = corazon;
                }
                Destroy(borrar);
                ultimaVidaMostrada--;
            }
        }*/
	}

    void PintarVidas()
    {
        GameObject c;
        Vector3 pos;
        for (int numCor = 0; numCor < vidas.Length; numCor++)
        {
            c = Instantiate(corazon);
            c.transform.SetParent(gameObject.transform, false);
            pos = c.transform.position;
            pos.x += numCor * c.GetComponent<Image>().sprite.bounds.extents.x * 20;
            c.transform.position = pos;
            c.transform.SetParent(gameObject.transform, false);
            vidas[numCor] = c;
        }
    }

    public void AumentaPuntuacion()
    {
        byte puntAct = byte.Parse(puntuacion.GetComponent<Text>().text);
        puntAct += 5;
        puntuacion.GetComponent<Text>().text = puntAct.ToString();
        if (puntAct%15==0)
        {
            generadorEnt.GetComponent<GeneradorEntidadesScript>().maxEnemSimult++;
        }
    }

    public void DisminuyeVida()
    {
        for(int v = vidas.Length - 1; v >= 0; v--)
        {
            if (vidas[v]!=null)
            {
                Destroy(vidas[v]);
                if (v==0)
                    SceneManager.LoadScene(2);
                break;
            }
        }
    }

    public void AumentaVida()
    {
        for (int v = 0; v < vidas.Length; v++)
        {
            if (vidas[v] == null)
            {
                GameObject c = Instantiate(corazon);
                c.transform.SetParent(gameObject.transform, false);
                Vector3 pos = c.transform.position;
                pos.x += v * c.GetComponent<Image>().sprite.bounds.extents.x * 20;
                c.transform.position = pos;
                c.transform.SetParent(gameObject.transform, false);
                vidas[v] = c;
                break;
            }
        }
    }
}
