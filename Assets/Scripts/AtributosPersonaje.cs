using UnityEngine;
using System.Collections;

public class AtributosPersonaje : MonoBehaviour {

    public byte vidaInicial;
    public byte daño;
    public byte escudosIniciales;
    [HideInInspector]
    public byte escudosDisponible;
    [HideInInspector]
    public bool escudoActivado = false;

    void Start()
    {
        escudosDisponible = escudosIniciales;
    }
}
