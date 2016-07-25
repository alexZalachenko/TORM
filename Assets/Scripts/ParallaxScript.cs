using UnityEngine;
using System.Collections;

public class ParallaxScript : MonoBehaviour {

    public float velocidadParallax;
    public bool parallaxHorizontal = false;
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = GetComponent<MeshRenderer>().material.mainTextureOffset;
        if (!parallaxHorizontal)
            offset.x += velocidadParallax;
        else
            offset.y += velocidadParallax;
        GetComponent<MeshRenderer>().material.mainTextureOffset = offset;
	}
}
