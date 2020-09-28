using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoosePanel : MonoBehaviour
{
    
    private void Awake()
    {
        gameObject.SetActive(false);
        EventCenter.AddListener<bool>(EventDefine.IsShowCharacterChoosePanel, Show);
        transform.Find("Btn_Back").GetComponent<Button>().onClick.AddListener(() =>
        {
            EventCenter.Broadcast(EventDefine.IsShowStartPanel, true);
            Show(false);
        });
    }
    private void OnDestroy()
    {
        EventCenter.RemoveListener<bool>(EventDefine.IsShowCharacterChoosePanel, Show);
    }

    private void Update()
    {

    }

    private void Show(bool value)
    {
        gameObject.SetActive(value);
    }


}
