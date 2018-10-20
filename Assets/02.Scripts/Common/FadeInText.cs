using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class FadeInText : MonoBehaviour
{
    private Text textUI;
    private StringBuilder sb = new StringBuilder();

    private string blackColor = "<color=\"#000000";
    private string whiteColor = "<color=\"#FFFFFF";
    private string textColor = "<color=\"#000000";
    private string showText;

    private float fadeSpeed = 5;
    private float alphaFloat1 = 0;
    private float alphaFloat2 = 0;
    private int alphaInt1 = 0;
    private int alphaInt2 = 0;

    public bool isPrinting = false;

    public void Init(Text _textUI, float _fadeSpeed = 5, int _color = 0)
    {
        textUI = _textUI;

        if (_fadeSpeed != 0)
            fadeSpeed = _fadeSpeed;

        if (_color == 0)
            textColor = blackColor;
        else
            textColor = whiteColor;
    }
    public void SetTextUI(Text _textUI)
    {
        textUI = _textUI;
    }
    public void SetFadeSpeed(float _fadeSpeed)
    {
        if (_fadeSpeed != 0)
            fadeSpeed = _fadeSpeed;
    }
    public void SetTextColor(int _color)
    {
        if (_color == 0)
            textColor = blackColor;
        else
            textColor = whiteColor;
    }

    public void PrintFadeText(string _text)
    {
        StartCoroutine("Cor_PrintFadeText", _text);
    }

    public IEnumerator Cor_PrintFadeText(string _text)
    {
        isPrinting = true;

        int count = 0;
        alphaFloat1 = 0;
        alphaFloat2 = 0;
        alphaInt1 = 0;
        alphaInt2 = 0;
        showText = string.Empty;
        while (count < _text.Length - 1)
        {
            if (alphaFloat1 <= 1.0f)
            {
                alphaFloat1 += Time.deltaTime * fadeSpeed;
                alphaInt1 = (int)(Mathf.Lerp(0.0f, 1.0f, alphaFloat1) * 255.0f);

                alphaFloat2 = alphaFloat1 * 0.5f;
                alphaInt2 = (int)(Mathf.Lerp(0.0f, 1.0f, alphaFloat2) * 255.0f);

                sb.Length = 0;
                sb.AppendFormat("{0}{1}{2:X}{3}{4}{5}{6}{7:X}{8}{9}{10}", showText, textColor, alphaInt1, "\">", _text[count], "</color>", textColor, alphaInt2, "\">", _text[count + 1], "</color>");
                textUI.text = sb.ToString();
            }
            else
            {
                alphaFloat1 = alphaFloat2;
                alphaFloat2 = 0;
                showText += _text[count];
                count++;
            }
            yield return null;
        }
        showText += _text[count++];
        textUI.text = showText;

        isPrinting = false;
    }
    //public IEnumerator Cor_StopPrintFadeText()
    //{

    //}
    public IEnumerator Cor_FadeOutText()
    {
        float alphaTime = 0;
        float alpha = 0;
        Color textUIColor = textUI.color;
        while (alphaTime <= 1.0f)
        {
            alphaTime += Time.deltaTime / 3.0f;
            alpha = Mathf.Lerp(1.0f, 0.0f, alphaTime);

            textUIColor.a = alpha;
            textUI.color = textUIColor;

            yield return null;
        }
        textUIColor.a = 1;
        textUI.color = textUIColor;
    }
}
