using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CargarPartidaScript : MonoBehaviour
{
    public void CargaPartida (int escena) {
        if (escena==-1)
            Application.Quit();
        SceneManager.LoadScene(escena);
	}
}
