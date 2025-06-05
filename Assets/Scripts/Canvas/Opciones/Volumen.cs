using UnityEngine;
using UnityEngine.UI;

public class Volumen : MonoBehaviour
{
    public Slider sliderVolumen;
    public Button botonMute;

    public Sprite iconoSonido;
    public Sprite iconoMute;

    private bool estaMuteado = false;
    private float volumenAnterior = 1f;

    void Start()
    {
        // Cargar volumen guardado
        float volumenGuardado = PlayerPrefs.GetFloat("volumen", 1f);
        sliderVolumen.value = volumenGuardado;
        AudioListener.volume = volumenGuardado;

        if (volumenGuardado == 0f)
        {
            estaMuteado = true;
        }

        sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
        botonMute.onClick.AddListener(ToggleMute);

        ActualizarIcono();
    }

    public void CambiarVolumen(float valor)
    {
        AudioListener.volume = valor;
        PlayerPrefs.SetFloat("volumen", valor);
        PlayerPrefs.Save();

        estaMuteado = valor == 0f;
        ActualizarIcono();
    }

    public void ToggleMute()
    {
        if (estaMuteado)
        {
            // Restaurar volumen (si estaba en 0, usar un valor por defecto)
            float nuevoVolumen = volumenAnterior > 0f ? volumenAnterior : 1f;

            AudioListener.volume = nuevoVolumen;
            sliderVolumen.value = nuevoVolumen;
            estaMuteado = false;
        }
        else
        {
            // Guardar volumen solo si es mayor a 0
            if (sliderVolumen.value > 0f)
            {
                volumenAnterior = sliderVolumen.value;
            }

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
