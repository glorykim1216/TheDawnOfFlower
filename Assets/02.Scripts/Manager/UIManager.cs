// 프리펩 UI 관리

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    Dictionary<eUIType, GameObject> DicUI = new Dictionary<eUIType, GameObject>();
    Transform ui;

    // UI 생성 및 가져오기
    private GameObject GetUI(eUIType _uiType)
    {
        // Dictionary에 있으면 바로 리턴
        if (DicUI.ContainsKey(_uiType) == true)
        {
            return DicUI[_uiType];
        }
        GameObject makeUI = null;
        GameObject prefabUI = Resources.Load("Prefabs/" + _uiType.ToString()) as GameObject;

        if (prefabUI != null)
        {
            if (ui == null)
                ui = this.transform.Find("UI");

            makeUI = Instantiate(prefabUI, ui);
            makeUI.name = _uiType.ToString();

            DicUI.Add(_uiType, makeUI);
            makeUI.SetActive(false);    // 꺼서 반환
        }
        return makeUI;
    }

    // UI 보이기
    public GameObject ShowUI(eUIType _uiType)
    {
        GameObject showObject = GetUI(_uiType);
        if (showObject != null && showObject.activeSelf == false)
        {
            showObject.SetActive(true);
        }
        else if (showObject == null)
        {
            Debug.LogError(_uiType + " is null");
        }
        return showObject;
    }

    // UI 숨기기
    public void HideUI(eUIType _uiType)
    {
        GameObject showObject = GetUI(_uiType);
        if (showObject != null && showObject.activeSelf == true)
        {
            showObject.SetActive(false);
        }
    }

    // Hierarchy 맨위로 변경
    public void SetHierarchy(eUIType _uiType)
    {
        GameObject showObject = GetUI(_uiType);
        showObject.transform.SetAsFirstSibling();
    }

    // Dictionary 초기화
    public void Clear()
    {
        foreach (KeyValuePair<eUIType, GameObject> pair in DicUI)
        {
            Destroy(pair.Value);
        }

        DicUI.Clear();
    }
}
