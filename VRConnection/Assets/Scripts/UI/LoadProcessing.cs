using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadProcessing : MonoBehaviour
{
    public string SceneName;
    private Text txt_Procress;
    private bool isLoad = false;
    private AsyncOperation ao;
    private void Awake()
    {
        gameObject.SetActive(false);
        txt_Procress = GetComponent<Text>();
        EventCenter.AddListener(EventDefine.ShowProcessing,ShowProcessing);
    }
    private void OnDestory()
    {
        EventCenter.RemoveListener(EventDefine.ShowProcessing, ShowProcessing);
    }
 
    private void ShowProcessing()
    {
        gameObject.SetActive(true);
        StartCoroutine("Load");
    }
    IEnumerator Load()
    {
        int displayProcess = -1;
        int toProcess = 100;
        while (displayProcess < toProcess)
        {
            ++displayProcess;
            ShowProcessingValue(displayProcess);
            if (isLoad == false)
            {
                ao = SceneManager.LoadSceneAsync(SceneName);
                ao.allowSceneActivation = false;
                isLoad = true;
            }
            yield return new WaitForEndOfFrame();
        }
        if (displayProcess == 100)
        {
            ao.allowSceneActivation = true;
            StopCoroutine("Load");
        }
    }
    private void ShowProcessingValue(int process)
    {
        txt_Procress.text = process.ToString() + "%";
    }
}
