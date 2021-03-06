using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;


public class MainMenu : MonoBehaviour
{
    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    //public void PlayGame()
    //{
    //    SceneManager.LoadScene(1);
    //}

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.
            LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            //Debug.Log(operation.progress);
            //0.9变成1
            float progress = operation.progress / 0.9f;
            slider.value = progress;

            //返回小于或等于 f 的最大整数。
            progressText.text = Mathf.FloorToInt
                (progress * 100f) + "%";

            //Debug.Log(progressText.text);
            yield return null;
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }
}
