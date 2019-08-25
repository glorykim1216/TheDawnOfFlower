using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandingCharacter : MonoBehaviour
{
    // 캐릭터 마다 위치 배열변수 5개 미리정의 필요 {중앙, 왼1, 오른1, 왼2, 오른2, 검}
    Vector2[] setiPos = { new Vector2(70, -85), new Vector2(-440, -85), new Vector2(465, -85), new Vector2(-670, -85), new Vector2(662, -85) };
    Vector2[] deneheuPos = { new Vector2(28, -21), new Vector2(-353, -21), new Vector2(355, -21), new Vector2(-603, -21), new Vector2(600, -21), new Vector2(-110, -5) };
    Vector2[] tamuzPos = { new Vector2(38, 1), new Vector2(-430, 1), new Vector2(426, 1), new Vector2(-661, 1), new Vector2(665, 1) };
    Vector2[] maidPos = { new Vector2(37, -135), new Vector2(-420, -135), new Vector2(467, -135), new Vector2(-642, -135), new Vector2(635, -135) };
    Vector2[] nepelaliaPos = { new Vector2(0, -83) };
    Vector2[] titoPos = { new Vector2(29, -18), new Vector2(-375, -18), new Vector2(385, -18), new Vector2(-626, -18), new Vector2(626, -18) };
    string[] nameTmp;

    public void SetCharacter(Image _image, bool _bool, string _expression = "", string _direction = "", float _scale = 1, eStandingPosition _position = 0)
    {
        if (_bool == true)
        {
            if (_image.enabled == false)
                _image.enabled = true;

            _image.sprite = SpriteManager.Instance.GetSprite(_expression);
            _image.SetNativeSize();

            RectTransform tr_chracter = _image.GetComponent<RectTransform>();

            switch (_direction)
            {
                case "L":
                    tr_chracter.localScale = new Vector3(_scale, _scale, _scale);
                    break;
                case "R":
                    tr_chracter.localScale = new Vector3(-_scale, _scale, _scale);
                    break;
            }

            nameTmp = _expression.Split('_');
            switch (nameTmp[0])
            {
                case "Seti":
                    tr_chracter.anchoredPosition = setiPos[(int)_position];
                    break;
                case "Deneheu":
                    tr_chracter.anchoredPosition = deneheuPos[(int)_position];
                    break;
                case "Tamuz":
                    tr_chracter.anchoredPosition = tamuzPos[(int)_position];
                    break;
                case "Maid":
                    tr_chracter.anchoredPosition = maidPos[(int)_position];
                    break;
                case "Nepelalia":
                    tr_chracter.anchoredPosition = nepelaliaPos[(int)_position];
                    break;
                case "Tito":
                    tr_chracter.anchoredPosition = titoPos[(int)_position];
                    break;
            }
        }
        else
        {
            if (_image.enabled == true)
                _image.enabled = false;
        }
    }
}
