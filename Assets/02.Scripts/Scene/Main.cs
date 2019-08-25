using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public Image title;
    public Image titleBG;
    public Button[] btn;

    void Start()
    {
        for (int i = 0; i < btn.Length; i++)
        {
            int _i = i;
            btn[i].onClick.AddListener(() => MainButton((eMainButton)_i));
        }

        titleBG.CrossFadeAlpha(0, 0, true);
        title.CrossFadeAlpha(0, 0, true);
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].GetComponent<Image>().CrossFadeAlpha(0, 0, true);
        }

        StartCoroutine("Cor_StartMain");
    }

    public void MainButton(eMainButton _btn)
    {
        switch (_btn)
        {
            case eMainButton.NEW_GAME:
                SceneFadeManager.Instance.LoadScene(eScene.GAME);
                break;
            case eMainButton.LOAD:
                //UIManager.Instance.ShowUI(eUIType.Image);
                break;
            case eMainButton.OPTION:
                //UIManager.Instance.HideUI(eUIType.Image);

                break;
            case eMainButton.EXTRA:

                break;
            case eMainButton.EXIT:

                break;
        }
    }

    IEnumerator Cor_StartMain()
    {
        yield return new WaitForSeconds(0.5f);
        titleBG.CrossFadeAlpha(1, 2.0f, true);
        yield return new WaitForSeconds(1);
        title.CrossFadeAlpha(1, 2.0f, true);
        yield return new WaitForSeconds(1);
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].GetComponent<Image>().CrossFadeAlpha(1, 1, true);
        }
        yield return new WaitForSeconds(0.7f);
        for (int i = 0; i < btn.Length; i++)
        {
            btn[i].interactable = true;
        }
    }
}
