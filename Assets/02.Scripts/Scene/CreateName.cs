using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateName : MonoBehaviour
{
    public InputField inputField;
    public Button okBtn;
    public Button backBtn;

    void Start ()
    {
        okBtn.onClick.AddListener(() => OK());	
        backBtn.onClick.AddListener(() => Back());
    }
	
    private void OK()
    {
        GameManager.Instance.mainCharacterName = inputField.text;

        UIManager.Instance.ShowUI(eUIType.Intro);

        SceneFadeManager.Instance.Fade(0.5f);

        UIManager.Instance.HideUI(eUIType.CreateName);
    }

    private void Back()
    {
        SceneFadeManager.Instance.LoadScene(eScene.MAIN);
    }
}
