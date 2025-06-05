using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroSplash : MonoBehaviour
{
    public GameObject logo1;
    public GameObject logo2;
    public GameObject menuPrincipal;
    public GameObject BG;
 

    public float tiempoLogo1 = 2f;
    public float tiempoLogo2 = 2f;
    public float tiempoOFF = 3f;

    void Start()
    {
        logo1.SetActive(false);
        logo2.SetActive(false);
        menuPrincipal.SetActive(false);

        StartCoroutine(MostrarLogos());
    }

    IEnumerator MostrarLogos()
    {
        // Mostrar primer logo
        logo1.SetActive(true);
        yield return new WaitForSeconds(tiempoLogo1);
        logo1.SetActive(false);

        // Mostrar segundo logo
        logo2.SetActive(true);
        yield return new WaitForSeconds(tiempoLogo2);
        logo2.SetActive(false);

        // Mostrar el menú
        menuPrincipal.SetActive(true);

        // Ocualtar BG
        yield return new WaitForSeconds(tiempoOFF);
        BG.SetActive(false);
    }
}
