
// 씬 전환 시 페이드 효과를 준다.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFadeManager : MonoSingleton<SceneFadeManager>
{

    public Image fadeImg;//Test Fade Img


    // 씬 전환 중에 중복 씬 전환 제어.
    bool IsSceneLoading = false;
    
    bool IsAsyc = true;
    AsyncOperation Operation = null;

    eScene CurrentScene = eScene.SCENE_NONE;
    eScene NextScene = eScene.SCENE_NONE;

    float stackTime = 0.0f;

    public void Start()
    {
        fadeImg.gameObject.SetActive(true);
        fadeImg.CrossFadeAlpha(0, 0, true);
    }

    public void LoadScene(eScene _scene, bool _async = true)
    {
        if (IsSceneLoading == true && CurrentScene == _scene)
            return;

        IsSceneLoading = true;
        NextScene = _scene;
        IsAsyc = _async;

        StartCoroutine("Cor_LoadScene");
    }

    IEnumerator Cor_LoadScene()
    {
        // FadeIn 실행
        FadeIn(0.5f);
        Debug.Log("fade");

        if (IsAsyc)
        {
            // 비동기
            Operation = SceneManager.LoadSceneAsync(NextScene.ToString());
            stackTime = 0.0f;
        }
        else
        {
            // 동기
            SceneManager.LoadScene(NextScene.ToString());
            CurrentScene = NextScene;
            NextScene = eScene.SCENE_NONE;

            FadeOut(1);
        }

        while (IsSceneLoading == true)
        {
            if (Operation != null)
            {
                stackTime += Time.deltaTime;

                if (Operation.isDone == true && stackTime >= 0.5f)
                {
                    // 삭제
                    DisableScene(CurrentScene);

                    CurrentScene = NextScene;

                    // 초기화
                    NextScene = eScene.SCENE_NONE;
                    Operation = null;
                    IsSceneLoading = false;

                    SuccesScene(CurrentScene);

                    // FadeOut 실행
                    FadeOut(0.5f);

                }
                else
                    yield return null;
            }
            else
                yield return null;
        }
    }

    void DisableScene(eScene _scene)
    {
        // 씬 UI 삭제
        UIManager.Instance.Clear();
        
        // 기타 삭제
        switch (_scene)
        {
            case eScene.MAIN:
                break;
            case eScene.GAME:
                break;
        }
    }

    void SuccesScene(eScene _scene)
    {
        switch (_scene)
        {
            case eScene.MAIN:
                GameManager.Instance.LoadMain();
                break;
            case eScene.GAME:
                GameManager.Instance.LoadGame();
                break;
        }
    }

     public void FadeIn(float _time)
    {
        fadeImg.CrossFadeAlpha(1, _time, true);
    }

    public void FadeOut(float _time)
    {
        fadeImg.CrossFadeAlpha(0, _time, true);
    }

    public void Fade(float _time)
    {
        StartCoroutine("Cor_Fade", _time);
    }
    IEnumerator Cor_Fade(float _time)
    {
        fadeImg.CrossFadeAlpha(1, 0.5f, true);
        yield return new WaitForSeconds(_time);
        fadeImg.CrossFadeAlpha(0, 0.5f, true);
    }
}
