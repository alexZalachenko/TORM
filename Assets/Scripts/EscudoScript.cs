using UnityEngine;
using System.Collections;

public class EscudoScript : MonoBehaviour
{
    private GameObject protagonista;
	// Use this for initialization
	void Start () {
        protagonista.GetComponent<AtributosPersonaje>().escudosDisponible--;
        Vector3 posProt = protagonista.GetComponent<Transform>().position;
        posProt.y += 1.55f;
        transform.position = posProt;
        Destroy(gameObject, 2);
	}

    void Update()
    {
        Vector3 posProt = protagonista.GetComponent<Transform>().position;
        posProt.y += 1.55f;
        transform.position = posProt;
    }

    public void SetProtagonista(GameObject p)
    {
        protagonista = p;
    }
    void OnDestroy()
    {
        protagonista.GetComponent<AtributosPersonaje>().escudoActivado = false;
    }
}
