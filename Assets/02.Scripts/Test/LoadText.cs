using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadText : MonoBehaviour
{
    public Button btn;
    public Text label;
    bool isLoading;
    int count = 0;

    string[] test = { "길게 늘어선 복도. 작고 조심스러운 발소리가 들렸다.", "시선을 옮겨 앞을 보니 어린 시녀의 작은 등이 보였다. ", "그녀는 자기 몸집보다 큰 물병을 위태롭게 들고 있었다." };

    void Start()
    {
        btn.onClick.AddListener(() => Load());
        StartCoroutine("Cor_LoadText", test[count]);
    }

    public void Load()
    {
        if (isLoading == true)
        {
            StopCoroutine("Cor_LoadText");
            label.text = test[count];

            if (count < test.Length - 1)
                count++;
            else
                count = 0;

            isLoading = false;
        }
        else
            StartCoroutine("Cor_LoadText", test[count]);
    }

    public IEnumerator Cor_LoadText(string _text)
    {
        isLoading = true;

        string tempText;
        int max_idx = 0;

        for (int i = 0; i < _text.Length; i++)
        {
            max_idx++;
            tempText = _text.Substring(0, max_idx);
            label.text = tempText;
            yield return new WaitForSeconds(0.1f);
        }

        if (count < test.Length - 1)
            count++;
        else
            count = 0;

        isLoading = false;
    }
}
