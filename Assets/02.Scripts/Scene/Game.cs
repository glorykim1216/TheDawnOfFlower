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

    float s1Pos;
    float s2Pos;
    float s3Pos;

    int currCount;
    public float SkipTime;

    StandingInfo standingInfo;
    StandingCharacter standingChracter;
    // Use this for initialization
    void Start()
    {
        fadeInText = this.GetComponent<FadeInText>();
        fadeInText.Init(contentsText, 8, 1);

        btn.onClick.AddListener(() => NextBtn());

        // Chapter 로드
        LanguageInfo info = LanguageManager.Instance.GetText(GameManager.Instance.language + "Chapter1");
        // Standing 로드 -필요
        standingInfo = StandingManager.Instance.GetInfo("Standing");
        standingChracter = this.gameObject.AddComponent<StandingCharacter>();
        // DB 로드 -필요
        currCount = 0;

        strNameText = new string[info.NAME_LIST.Count];
        strContentsText = new string[info.CONTENTS_LIST.Count];

        for (int i = 0; i < strNameText.Length; i++)
        {
            strNameText[i] = info.NAME_LIST[i];
            strContentsText[i] = info.CONTENTS_LIST[i];
        }

        NextBtn();
    }

    private void Update()
    {
        // 자동넘기기
        if (fadeInText.isPrinting == false)
        {
            SkipTime += Time.deltaTime;
        }

        if (SkipTime >= 5)
        {
            NextBtn();
        }
    }

    void NextBtn()
    {
        SkipTime = 0;
        //SceneFadeManager.Instance.LoadScene(eScene.MAIN);

        if (fadeInText.isPrinting == true)
        {
            currCount--;

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
            SetVisual(strNameText[currCount], strContentsText[currCount], standingInfo.BACKGROUND_LIST[currCount],
                standingInfo.S1_LIST[currCount], standingInfo.S1_DIRECTION_LIST[currCount], standingInfo.S1_SCALE_LIST[currCount],
                standingInfo.S2_LIST[currCount], standingInfo.S2_DIRECTION_LIST[currCount], standingInfo.S2_SCALE_LIST[currCount],
                standingInfo.S3_LIST[currCount], standingInfo.S3_DIRECTION_LIST[currCount], standingInfo.S3_SCALE_LIST[currCount],
                "", "");

            currCount++;
        }

    }
    // 모든 변수 입력
    public void SetVisual(string _name, string _contents, string _Background,
        string _standing1, string _s1Direction, float _s1Scale,
        string _standing2, string _s2Direction, float _s2Scale,
        string _standing3, string _s3Direction, float _s3Scale,
        string _sound1, string _sound2)
    {
        // Name 구분
        if (_name.Equals("chapter"))
        {
            // 버튼 UI 숨기기
            GameObjectActive(ChapterImg, true);

            chapterText.text = _contents;
        }
        else if (_name.Equals("회상"))
        {
            GameObjectActive(ChapterImg, false);
            GameObjectActive(nameImg, false);
            GameObjectActive(contentsImg, false);
            GameObjectActive(remembranceImg, true);

            fadeInText.SetTextUI(remembranceText);
        }
        else if (_name.Equals("null"))
        {
            GameObjectActive(ChapterImg, false);
            GameObjectActive(remembranceImg, false);
            GameObjectActive(nameImg, false);
            GameObjectActive(contentsImg, true);

            if (fadeInText.GetTextUI() != contentsText)
            {
                fadeInText.SetTextUI(contentsText);
            }
        }
        else
        {
            GameObjectActive(ChapterImg, false);
            GameObjectActive(remembranceImg, false);
            GameObjectActive(nameImg, true);
            GameObjectActive(contentsImg, true);

            if (fadeInText.GetTextUI() != contentsText)
            {
                fadeInText.SetTextUI(contentsText);
            }
        }

        // Standing 캐릭터
        if (_standing1.Equals("null"))               // 0명
        {
            standingChracter.SetCharacter(character1, false);
            standingChracter.SetCharacter(character2, false);
            standingChracter.SetCharacter(character3, false);
        }
        else
        {
            if (!_standing3.Equals("null"))         // 3명
            {
                standingChracter.SetCharacter(character1, true, _standing1, _s1Direction, _s1Scale, eStandingPosition.STANDING3_LEFT);
                standingChracter.SetCharacter(character2, true, _standing2, _s2Direction, _s2Scale, eStandingPosition.STANDING1_CENTER);
                standingChracter.SetCharacter(character3, true, _standing3, _s3Direction, _s3Scale, eStandingPosition.STANDING3_RIGHT);
            }
            else if (!_standing2.Equals("null"))    // 2명
            {
                standingChracter.SetCharacter(character1, true, _standing1, _s1Direction, _s1Scale, eStandingPosition.STANDING2_LEFT);
                standingChracter.SetCharacter(character2, true, _standing2, _s2Direction, _s2Scale, eStandingPosition.STANDING2_RIGHT);
                standingChracter.SetCharacter(character3, false);
            }
            else                                    // 1명
            {
                // 스크립트 나올때까지 임시 주석(검 좌우 구분해야하나? 물어봐야함.)
                //if(_standing1.Contains("sword"))
                //    standingChracter.SetCharacter(character1, true, _standing1, _s1Direction, _s1Scale, eStandingPosition.SWORD);
                //else
                standingChracter.SetCharacter(character1, true, _standing1, _s1Direction, _s1Scale, eStandingPosition.STANDING1_CENTER);

                standingChracter.SetCharacter(character2, false);
                standingChracter.SetCharacter(character3, false);
            }
        }
        nameText.text = _name;
        cor_textPrint = StartCoroutine(fadeInText.Cor_PrintFadeText(_contents));
    }

    public void GameObjectActive(GameObject _obj, bool _bool)
    {
        if (_bool == true)
        {
            if (_obj.activeSelf == false)
                _obj.SetActive(true);
        }
        else
        {
            if (_obj.activeSelf == true)
                _obj.SetActive(false);
        }
    }

    //public void CharacterEnable(Image _image, bool _bool, string _character = "", string _position = "", string _direction = "", string _scale = "")
    //{
    //    if (_bool == true)
    //    {
    //        if (_image.enabled == false)
    //            _image.enabled = true;

    //        _image.sprite = SpriteManager.Instance.GetSprite(_character);// Resources.Load("") as Sprite;
    //        _image.SetNativeSize();
    //        Transform tr_chracter = _image.transform;
    //        if (_position.Equals("L"))
    //        {
    //            tr_chracter.position = new Vector3();
    //        }
    //        else if (_position.Equals("R"))
    //        {

    //        }
    //        else if (_position.Equals("C"))
    //        {

    //        }


    //    }
    //    else
    //    {
    //        if (_image.enabled == true)
    //            _image.enabled = false;
    //    }
    //}
}