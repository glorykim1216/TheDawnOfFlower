﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    bool isFristOn;
    bool isIntroView;

    public eLanguage language = eLanguage.KOREA_;


    // DB 로드 후 값 초기화 필요!
    void Start()
    {
        GameManager.Instance.LoadMain();
        LanguageManager.Instance.TextLoad();
    }

    void Update()
    {

    }

    public void LoadMain()
    {
        StartCoroutine("Cor_LoadMain");
    }
    IEnumerator Cor_LoadMain()
    {
        if (isFristOn == false)
        {
            GameObject caution = UIManager.Instance.ShowUI(eUIType.Caution);
            isFristOn = true;
            yield return new WaitForSeconds(2);
            caution.GetComponent<Image>().CrossFadeAlpha(0, 0.5f, true);
            SceneFadeManager.Instance.LoadScene(eScene.MAIN);
        }
        else
        {
            UIManager.Instance.ShowUI(eUIType.Main);
            UIManager.Instance.SetHierarchy(eUIType.Main);
        }
    }

    public void LoadGame()
    {
        if (isIntroView == false)
        {
            UIManager.Instance.ShowUI(eUIType.Intro);
            // 인트로 X
            //isIntroView = true;
        }
        else
            UIManager.Instance.ShowUI(eUIType.Game);
    }
}
