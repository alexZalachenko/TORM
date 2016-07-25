using UnityEngine;
using System.Collections;

public class ControladorPersonajeScript : MonoBehaviour {

    public float maxVelocidad;
    public GameObject balaCañon;
    public GameObject escudo;
    bool mirandoDerecha = true;
    float axisH = 0, axisV = 0;

	// Update is called once per frame
    void Update()
    {
        GetInput();
    }

	void FixedUpdate() {
        if (axisV != 0 || axisH != 0)
            Movimiento();
    }

    void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
            UsarEscudo();
        axisH = Input.GetAxis("Horizontal");
        axisV = Input.GetAxis("Vertical");
    }

    void Movimiento()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(axisH * maxVelocidad, axisV * maxVelocidad);
        //CAMBIO LA ORIENTACION DEL SPRITE SI HACE FALTA
        if (axisH < 0 && mirandoDerecha == true)
            GirarSprite();
        else if (axisH > 0 && mirandoDerecha == false)
            GirarSprite();
    }

    void GirarSprite() {
        mirandoDerecha = !mirandoDerecha;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }

    void UsarEscudo()
    {
        if (GetComponent<AtributosPersonaje>().escudosDisponible > 0)
        {
            GetComponent<AtributosPersonaje>().escudoActivado = true;
            GameObject creado = Instantiate(escudo);
            creado.GetComponent<EscudoScript>().SetProtagonista(gameObject);
        }
    }
}
