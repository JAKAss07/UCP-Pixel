using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public string sceneLoadName;
    public TextMeshProUGUI textProgress;
    public TextMeshProUGUI cargaBtn;
    public Slider sliderProgress;
    public float currentPercent;
    private AsyncOperation loadAsync;

    [Header("Escena de Inicio: Jugar")]
    public GameObject sceneInical;
    [Header("Escena de carga")]
    public GameObject sceneCarga;


    public void LoadSceneButton()
    {
        sceneInical.SetActive(false);
        sceneCarga.SetActive(true);
        StartCoroutine(LoadScene(sceneLoadName));
    }

    public IEnumerator LoadScene(string nameToLoad)
    {
        textProgress.text = "Cargando.. 00%";
        loadAsync = SceneManager.LoadSceneAsync(nameToLoad);
        loadAsync.allowSceneActivation = false;
        while (!loadAsync.isDone)
        {
            // 0.9 -> 100
            // 0.9?   0.9 *100 /0.9
            currentPercent = loadAsync.progress * 100 / 0.9f;
            textProgress.text = "Cargando.. " + currentPercent.ToString("00") + "%";
            yield return null;
        }
    }
    private void Update()
    {
        sliderProgress.value = Mathf.MoveTowards(sliderProgress.value, currentPercent, 10 * Time.deltaTime);

        if (loadAsync != null && currentPercent >= 100)
        {
            cargaBtn.text = "Enter para continuar ";
            if (Input.GetKeyDown(KeyCode.Return))
            {   
                loadAsync.allowSceneActivation = true;
            }
        }

    }
}
