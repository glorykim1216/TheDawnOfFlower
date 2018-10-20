using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    FadeInText fadeInText;

    public Image backGround;

    public Image character1;
    public Image character2;
    public Image character3;

    public GameObject nameImg;
    public GameObject contentsImg;
    public GameObject remembranceImg;
    public GameObject ChapterImg;

    public Text nameText;
    public Text contentsText;
    public Text remembranceText;
    public Text chapterText;

    public Button btn;

    string[] strNameText;
    string[] strContentsText;

    Coroutine cor_textPrint;

    int currCount;

    // Use this for initialization
    void Start()
    {
        fadeInText = this.GetComponent<FadeInText>();
        fadeInText.Init(contentsText, 8, 1);

        btn.onClick.AddListener(() => main());

        // Chapter 로드
        LanguageInfo info = LanguageManager.Instance.GetText(GameManager.Instance.language + "Chapter1");
        // Standing 로드 -필요

        // DB 로드 -필요
        currCount = 0;

        strNameText = new string[info.NAME_LIST.Count];
        strContentsText = new string[info.CONTENTS_LIST.Count];

        for (int i=0; i< strNameText.Length; i++)
        {
            strNameText[i] = info.NAME_LIST[i];
            strContentsText[i] = info.CONTENTS_LIST[i];
        }

    }
    void main()
    {
        //SceneFadeManager.Instance.LoadScene(eScene.MAIN);

        if (fadeInText.isPrinting == true)
        {
            StopCoroutine(cor_textPrint);
            contentsText.text = strContentsText[currCount];

            if (currCount < strNameText.Length - 1)
                currCount++;
            else
            {
                Debug.Log("끝");
            }

            fadeInText.isPrinting = false;
        }
        else
        {
            cor_textPrint = StartCoroutine(fadeInText.Cor_PrintFadeText(strContentsText[currCount]));
            currCount++;
        }
    }
    public void AAAAA()
    {
        // 모든 변수 입력
    }
}