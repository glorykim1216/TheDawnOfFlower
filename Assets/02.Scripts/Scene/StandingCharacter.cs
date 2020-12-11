using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StandingCharacter : MonoBehaviour
{
    public Image image;
    RectTransform rectTr_chracter;
    bool isMove = false;
    bool isShake = false;
    Vector2 targetPosition;
    void Start()
    {
        rectTr_chracter = this.GetComponent<RectTransform>();
        image = this.GetComponent<Image>();
    }

    void Update()
    {
        if(isMove == true)
        {
            rectTr_chracter.anchoredPosition = Vector2.MoveTowards(rectTr_chracter.position, targetPosition, 0.1f);
        }
        if(isShake == true)
        {

        }
    }

    public void Init(string _expression, string _effect)
    {
        isMove=false;
        isShake = false;
        image.sprite = SpriteManager.Instance.GetSprite(_expression);
        image.SetNativeSize();

        switch (_effect)
            {
                case "Move1":
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                case "Move2":
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                   case "Move3":
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                case "Disappear1":
                // 알파값 추가
                // 사라지기
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                case "Disappear2":
                // 알파값 추가
                //사라지기
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                case "Disappear3":
                // 알파값 추가
                // 사라지기
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                case "Appear1":
                // 알파값 추가
                //나타나기
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                case "Appear2":
                // 알파값 추가
                // 나타나기
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                case "Appear3":
                // 알파값 추가
                //나타나기
                    targetPosition = new Vector2(0,0);
                    isMove = true;
                    break;
                case "Shake1":
                // 짧게
                    isShake = true;
                    break;
                case "Shake2":
                // 길게
                    isShake = true;
                    break;
                case "Skill":
                // 특수 효과 캐릭마다 다를거같음.
                    break;
            }
    }

    public void SetPosition(Vector2 pos)
    {
        rectTr_chracter.anchoredPosition = pos;
    }

    public void SetDirection(string _direction)
    {
        // L, M2 일때는 x스케일 -1
        if (_direction.Equals("L") || _direction.Equals("M1"))
            rectTr_chracter.localScale = new Vector3(-1, 1, 1);
        else
            rectTr_chracter.localScale = new Vector3(1, 1, 1);
    }

    // 항상 좌측방향
    public void SetDirection()
    {
        rectTr_chracter.localScale = new Vector3(1, 1, 1);
    }
}
