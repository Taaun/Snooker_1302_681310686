using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private float waitSecond = 1f;


    void Start()
    {
        
    }

    void Update()
    {
        if (waitSecond > 0f)
            waitSecond -= Time.deltaTime;
        else
            StartCoroutine (LoadNewScene()); 

    }
    private IEnumerator LoadNewScene()
    {
        AsyncOperation oper = SceneManager.LoadSceneAsync("Scene01");

        while (!oper.isDone)
        {
            slider.value = oper.progress / 0.9f;
            yield return null;
        }
    }
}
