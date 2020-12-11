/**
 * @Description : 인트로 클래스, Cor_IntroToInGame() 코루틴이 끝나면 인게임화면으로 전환.
 * @Author : glorykim
 */

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Text textUI;
    FadeInText fadeInText;
    string[] introContents;

    void Start()
    {
        // 텍스트 fade 효과 적용
        fadeInText = this.GetComponent<FadeInText>();
        fadeInText.Init(textUI, 6, 0);

        // 언어 정보 로드
        LanguageInfo info = LanguageInfoManager.Instance.GetText(GameManager.Instance.language + "Intro");

        introContents = new string[info.NAME_LIST.Count];

        // 언어 정보를 introContents에 저장
        for (int i = 0; i < introContents.Length; i++)
        {
            introContents[i] = info.CONTENTS_LIST[i];
        }

        StartCoroutine(Cor_IntroToInGame());
    }

    // 인트로 종료시 인게임화면으로 전환
    IEnumerator Cor_IntroToInGame()
    {
        for (int i = 0; i < introContents.Length; i++)
        {
            yield return StartCoroutine(fadeInText.Cor_PrintFadeText(introContents[i]));
            yield return StartCoroutine(fadeInText.Cor_FadeOutText());
        }

        textUI.gameObject.SetActive(false);

        // 인트로 끝나면 Game 로드
        SceneFadeManager.Instance.FadeIn(0.5f);
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowUI(eUIType.Game);
        SceneFadeManager.Instance.FadeOut(0.5f);
        UIManager.Instance.HideUI(eUIType.Intro);
    }
}
