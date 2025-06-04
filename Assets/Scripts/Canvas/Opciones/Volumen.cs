using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider sliderVolumen;
    public Button botonMute;

    private bool estaMuteado = false;
    private float volumenAnterior = 1f;

    public Sprite iconoSonido;
    public Sprite iconoMute;


    void Start()
    {
        // Cargar volumen guardado
        if (PlayerPrefs.HasKey("volumen"))
        {
            float volumenGuardado = PlayerPrefs.GetFloat("volumen");
            sliderVolumen.value = volumenGuardado;
            AudioListener.volume = volumenGuardado;
        }
        else
        {
            sliderVolumen.value = 1f;
            AudioListener.volume = 1f;
        }

        // Asignar eventos 
        sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        botonMute.onClick.AddListener(ToggleMute);

        ActualizarIcono();
    }

    public void CambiarVolumen(float valor)
    {
        AudioListener.volume = valor;
        PlayerPrefs.SetFloat("volumen", valor);
    
        PlayerPrefs.Save();

        if (valor > 0f)
        {
            estaMuteado = false;
        }

        ActualizarIcono();
    }

    public void ToggleMute()
    {
        if (estaMuteado)
        {
            // Restaurar volumen
            AudioListener.volume = volumenAnterior;
            sliderVolumen.value = volumenAnterior;
            estaMuteado = false;
        }
        else
        {
            // Guardar volumen y silenciar
            volumenAnterior = sliderVolumen.value;
            AudioListener.volume = 0f;
            sliderVolumen.value = 0f;
            estaMuteado = true;
        }

        ActualizarIcono();
    }

    private void ActualizarIcono()
    {
        if (estaMuteado || sliderVolumen.value == 0)
        {   
            botonMute.image.sprite = iconoMute;
        }
        else
        {
            botonMute.image.sprite = iconoSonido;
        }
    }

}
