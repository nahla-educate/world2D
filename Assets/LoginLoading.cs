using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginLoading : MonoBehaviour
{
    public Slider slider;
    public GameObject loadingScreen;
    public Text progressText;

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f); 
<<<<<<< HEAD
            //Debug.Log(progress);
=======
            Debug.Log(progress);
>>>>>>> 5ef3753343931c5f31f96651844b05317bb63430
            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
