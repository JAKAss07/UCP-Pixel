using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorDeBotones : MonoBehaviour
{
    // Nombres de los paneles a controlar
    public GameObject nombreUIAMostrar;
    public GameObject nombreUIAOcultar;

    // Cargar una escena por nombre
    public void CargarEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }

    // Salir del juego
    public void SalirDelJuego()
    {
        print("Has salido del juego :C");
        Application.Quit();
    }

    //Activar o desactivar UI
    public void ActivarYDesactivarUI()
    {
        if (nombreUIAMostrar != null && nombreUIAOcultar != null)
        {
            
            if(nombreUIAOcultar.activeSelf ==  true)
            {
                nombreUIAOcultar.SetActive(false);
                nombreUIAMostrar.SetActive(true);
            }
            else
            {
                nombreUIAOcultar.SetActive(true);
                nombreUIAMostrar.SetActive(false);
            }      
          
        }
    }
}
