using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    private string m_Character;
    private bool isClick=false;
    public GameObject startPanel;
    private void Awake()
    {
        
        EventCenter.AddListener<bool>(EventDefine.IsShowStartPanel, Show);
        transform.Find("Btn_Start").GetComponent<Button>().onClick.AddListener(() =>
        {
            startPanel.SetActive(false);
            EventCenter.Broadcast(EventDefine.ShowProcessing);
            
            PlayerPrefs.SetString("CharacterName", m_Character);
            
            
        });
        EventCenter.AddListener<string>(EventDefine.OnCharacterChoose,OnCharacterChoose);
        transform.Find("Btn_Choose").GetComponent<Button>().onClick.AddListener(()=> 
        {
            EventCenter.Broadcast(EventDefine.IsShowCharacterChoosePanel, true);
            Show(false);
        });
    }
    private void Start()
    {

    }
    private void OnDestory()
    {
        
        EventCenter.RemoveListener<bool>(EventDefine.IsShowStartPanel, Show);
        EventCenter.RemoveListener<string>(EventDefine.OnCharacterChoose, OnCharacterChoose);
    }
    private void Update()
    {
        
    }
    private void Show(bool value)
    {
        gameObject.SetActive(value);
    }
    private void OnCharacterChoose(string characterName)
    {
        m_Character = characterName;
    }
}
