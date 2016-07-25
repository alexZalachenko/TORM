using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

    public float tiempoExpl;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, tiempoExpl);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
