using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

// © 2017 TheFlyingKeyboard and released under MIT License 
// theflyingkeyboard.net 

public class FadeInTextWordByWord : MonoBehaviour
{
    [SerializeField] private Text textToUse;
    [SerializeField] private bool useThisText = false;
    [TextAreaAttribute(4, 15)]
    [SerializeField] private string textToShow;
    [SerializeField] private bool useTextText = false;

    [SerializeField] private float fadeSpeedMultiplier = 0.25f;
    [SerializeField] private bool fade;

    private float colorFloat = 0.1f;
    private int colorInt;
    private string shownText;

    // 생정자
    public void Init(int _a)
    {
        fadeSpeedMultiplier = _a;
    }

    private void Start()
    {
        if (useThisText)
        {
            textToUse = GetComponent<Text>();
        }

        if (useTextText)
        {
            textToShow = textToUse.text;
        }

        if (fade)
        {
            Fade();
        }


    }

    public void Fade()
    {
        StartCoroutine(FadeInText());
    }
    private StringBuilder sb = new StringBuilder();
    private IEnumerator FadeInText()
    {
        int letterCounter = 0;
        float colorFloat2 = 0;
        int colorInt2 = 0;

        while (letterCounter < textToShow.Length - 1)
        {
            if (colorFloat <= 1.0f)
            {
                colorFloat += Time.deltaTime * fadeSpeedMultiplier;
                colorInt = (int)(Mathf.Lerp(0.0f, 1.0f, colorFloat) * 255.0f);

                colorFloat2 = colorFloat / 2;
                colorInt2 = (int)(Mathf.Lerp(0.0f, 1.0f, colorFloat2) * 255.0f);

                if (letterCounter == textToShow.Length - 1)     // 마지막 글자 알파값 처리
                {
                    sb.Length = 0;
                    sb.AppendFormat("{0}{1}{2:X}{3}{4}{5}{6}{7:X}{8}{9}{10}", shownText, "<color=\"#000000", colorInt, "\">", textToShow[letterCounter], "</color>", "<color=\"#000000", colorInt, "\">", textToShow[letterCounter + 1], "</color>");
                    textToUse.text = sb.ToString();
                }
                else    
                {
                    sb.Length = 0;
                    sb.AppendFormat("{0}{1}{2:X}{3}{4}{5}{6}{7:X}{8}{9}{10}", shownText, "<color=\"#000000", colorInt, "\">", textToShow[letterCounter], "</color>", "<color=\"#000000", colorInt2, "\">", textToShow[letterCounter + 1], "</color>");
                    textToUse.text = sb.ToString();
                }
            }
            else
            {
                colorFloat = colorFloat2;
                colorFloat2 = 0.0f;
                shownText += textToShow[letterCounter];
                letterCounter++;
            }
            yield return null;
        }
    }


}
