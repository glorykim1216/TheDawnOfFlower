using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StandingCharacter : MonoBehaviour
{
    public Image image;
    RectTransform rectTr_chracter;
    public Vector2 targetPosition;

    eCharacterEffect characterEffectState;
    void Start()
    {
        rectTr_chracter = this.GetComponent<RectTransform>();
        image = this.GetComponent<Image>();
    }

    void Update()
    {
        // 확대
        if (characterEffectState == eCharacterEffect.EXPAND)
        {
            rectTr_chracter.localScale = Vector3.MoveTowards(rectTr_chracter.localScale, new Vector3(1.25f, 1.25f, 1.0f), 1 * Time.deltaTime);
        }
        // 이동
        if (characterEffectState == eCharacterEffect.MOVE || characterEffectState == eCharacterEffect.DISAPPEAR || characterEffectState == eCharacterEffect.APPEAR)
        {
            rectTr_chracter.anchoredPosition = Vector2.MoveTowards(rectTr_chracter.anchoredPosition, targetPosition, GameManager.Instance.standingMoveSpeed * Time.deltaTime);
        }
    }

    public void Init(string _expression)
    {
        characterEffectState = eCharacterEffect.NONE;
        image.sprite = SpriteManager.Instance.GetSprite(_expression);
        image.SetNativeSize();

        image.CrossFadeAlpha(1, 0, true);
        StopShake();
    }
    public void SetCharacterEffect(string _effect)
    {
        string[] effectTmp = _effect.Split('_');

        if (effectTmp[0].Equals("Expand"))
            characterEffectState = eCharacterEffect.EXPAND;
        else if (effectTmp[0].Equals("Shake"))
        {
            //짧게
            if (effectTmp[1].Equals("1"))
            {
                characterEffectState = eCharacterEffect.SHAKE1;
                InvokeRepeating("StartShake", 0f, Time.deltaTime);
                Invoke("StopShake", 1.3f);
            }
            // 길게
            else
            {
                characterEffectState = eCharacterEffect.SHAKE2;
                InvokeRepeating("StartShake", 0f, Time.deltaTime);
                Invoke("StopShake", 2.2f);
            }
        }
        else if (effectTmp[0].Equals("Skill"))
        {

        }
        else
        {
            // 이동, 사라짐, 나타남
            if (effectTmp[0].Equals("Move"))
                characterEffectState = eCharacterEffect.MOVE;
            else if (effectTmp[0].Equals("Disappear"))
            {
                characterEffectState = eCharacterEffect.DISAPPEAR;
                //알파값 
                image.CrossFadeAlpha(0, 0.7f, true);
            }
            else if (effectTmp[0].Equals("Appear"))
            {
                characterEffectState = eCharacterEffect.APPEAR;
                //알파값 
                image.CrossFadeAlpha(1, 0.7f, true);
            }

            // 이동방향
            if (effectTmp[1].Equals("R"))
                targetPosition = new Vector2(rectTr_chracter.anchoredPosition.x + 400, rectTr_chracter.anchoredPosition.y);
            else if (effectTmp[1].Equals("L"))
                targetPosition = new Vector2(rectTr_chracter.anchoredPosition.x - 400, rectTr_chracter.anchoredPosition.y);
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

    void StartShake()
    {
        float PosX = Random.value * 2 - 1.0f;
        float PosY = Random.value - 0.55f;
        targetPosition = new Vector2(rectTr_chracter.anchoredPosition.x + PosX, rectTr_chracter.anchoredPosition.y + PosY);
        rectTr_chracter.anchoredPosition = targetPosition;
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
    }
}
