using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Text textUI;
    FadeInText fadeInText;
    string[] test = { "그녀가 나를 감싸 안자\n\n한 줌의 온기도 느껴지지 않았다.\n\n비로소 꿈이라는 것을 깨달았다.", "나는 오래전에 그녀를 잃었고\n\n태양은 영원히 저물어 버렸다.\n\n그리움만이 그림자처럼 짙게 \n\n내 마음에 드리웠다.", "그녀는 자기 몸집보다 큰 물병을 위태롭게 들고 있었다." };

    void Start()
    {
        fadeInText = this.GetComponent<FadeInText>();
        fadeInText.Init(textUI, 6, 0);

        LanguageInfo info = LanguageManager.Instance.GetText(GameManager.Instance.language + "Intro");

        test = new string[info.NAME_LIST.Count];

        for (int i = 0; i < test.Length; i++)
        {
            test[i] = info.CONTENTS_LIST[i];
        }

        StartCoroutine(Cor_Test());
    }

    IEnumerator Cor_Test()
    {
        for (int i = 0; i < test.Length; i++)
        {
            yield return StartCoroutine(fadeInText.Cor_PrintFadeText(test[i]));
            yield return StartCoroutine(fadeInText.Cor_FadeOutText());
        }

        // 인트로 끝나면 Game 로드
        textUI.gameObject.SetActive(false);

        SceneFadeManager.Instance.FadeIn(0.5f);
        yield return new WaitForSeconds(1);
        UIManager.Instance.ShowUI(eUIType.Game);
        SceneFadeManager.Instance.FadeOut(0.5f);
        UIManager.Instance.HideUI(eUIType.Intro);
    }
}
