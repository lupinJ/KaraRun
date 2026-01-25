using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    
    public Transform canvas; //캔버스의 위치

    public Dictionary<string, PopupUI> popupUIDictionary = new();
    protected override void Init()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        
        SaveData data = DataManager.Instance.Data;
        GetPanel("CoinDataUI").SetPanel<int>(data.coin);
        GetPanel("JewelDataUI").SetPanel<int>(data.jewel);
    }
    public void ShowPanel(string uiName) 
    {
        popupUIDictionary.TryGetValue(uiName, out PopupUI popupUI); 
        if (popupUI == null)
            Debug.Log("null");

        if (popupUI != null)
        {
            popupUI.ShowPanel(); 
        }
    }

    public void HidePanel(string uiName) 
    {
        popupUIDictionary.TryGetValue(uiName, out PopupUI popupUI); 

        popupUI.HidePanel(); 
    }

    public PopupUI GetPanel(string uiName)
    {
        popupUIDictionary.TryGetValue(uiName, out PopupUI popupUI);

        if (popupUI != null)
        {
            return popupUI;
        }

        return null;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        canvas = GameObject.Find("Canvas").transform;

        PopupUI[] popupUIs = canvas.GetComponentsInChildren<PopupUI>(true); 
        popupUIDictionary.Clear();
        
        foreach (PopupUI popupUI in popupUIs)
        {

            if (!popupUIDictionary.ContainsKey(popupUI.name))
            {
                //Debug.Log($"{popupUI.name}");
                popupUIDictionary.Add(popupUI.name, popupUI); 
            }
            else
            {
                Debug.LogWarning($"중복 키 : {popupUI.name}");
            }
        }
        
        if(scene.name == "StartScene")
        {
            SaveData data = DataManager.Instance.Data;
            Debug.Log($"{data.coin} {data.jewel}");
            GetPanel("CoinDataUI").SetPanel<float>(data.coin);
            GetPanel("JewelDataUI").SetPanel<float>(data.jewel);
            GetPanel("ScoreBorad").SetPanel<List<int>>(data.score);
        }
    }
}
