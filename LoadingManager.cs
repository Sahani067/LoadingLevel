using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private GameObject _LodingUi;
    [SerializeField] private GameObject _MainMenuUi;

    [SerializeField] private Slider _LoadingSliderUi;

    public void LoadLevelBtn(string levelToLoad)
    {
        _MainMenuUi.SetActive(false);
        _LodingUi.SetActive(true);

        StartCoroutine(LoadLevelASync(levelToLoad));
    }

    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        
        

        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            _LoadingSliderUi.value = progressValue;

            yield return null;
        }
    }
}
