using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingCharacterManager : MonoBehaviour
{
    // 캐릭터 마다 위치 배열변수 5개 미리정의 필요 {중앙1(좌), 중앙2(우), 좌, 우, 검}
    Vector2[] setiPosM = { new Vector2(47, -85), new Vector2(-41, -85), new Vector2(-508, -85), new Vector2(504, -85) };
    Vector2[] deneheuPos = { new Vector2(30, -21), new Vector2(15, -21), new Vector2(-420, -21), new Vector2(412, -21), new Vector2(-20, -13) };
    Vector2[] tamuzPos = { new Vector2(57, 4), new Vector2(-56, 4), new Vector2(-460, 4), new Vector2(460, 4), new Vector2(-13, -8) };
    Vector2[] enlimPos = { new Vector2(57, -12), new Vector2(-43, -12), new Vector2(-457, -12), new Vector2(442, -12), new Vector2(-50, -5) };
    Vector2[] maidPos = { new Vector2(24, -143), new Vector2(-27, -143), new Vector2(-526, -143), new Vector2(515, -143) };
    Vector2[] nepelaliaPos = { new Vector2(-8, -77), new Vector2(10, -77), new Vector2(-455, -77), new Vector2(435, -77) };
    Vector2[] titoPos = { new Vector2(-9, -18), new Vector2(8, -18), new Vector2(-470, -18), new Vector2(-442, -18) };
    Vector2[] anuslettPos = { new Vector2(48, 6), new Vector2(28, 6), new Vector2(-455, 6), new Vector2(455, 6) };

    public void SetCharacter(StandingCharacter character, bool _bool, string _expression = "", string _direction = "", float _scale = 1, string _effect = "null")
    {
        if (_bool == true)
        {
            if (character.image.enabled == false)
                character.image.enabled = true;

            character.Init(_expression);

            // 캐릭터 위치
            eStandingPosition parsed_enum = (eStandingPosition)System.Enum.Parse(typeof(eStandingPosition), _direction);
            string[] nameTmp = _expression.Split('_');
            switch (nameTmp[0])
            {
                case "Seti":
                    character.SetPosition(setiPosM[(int)parsed_enum]);
                    break;
                case "Deneheu":
                    character.SetPosition(deneheuPos[(int)parsed_enum]);
                    break;
                case "Tamuz":
                    character.SetPosition(tamuzPos[(int)parsed_enum]);
                    break;
                case "Maid":
                    character.SetPosition(maidPos[(int)parsed_enum]);
                    break;
                case "Nepelalia":
                    character.SetPosition(nepelaliaPos[(int)parsed_enum]);
                    break;
                case "Tito":
                    character.SetPosition(titoPos[(int)parsed_enum]);
                    break;
                case "Enlim":
                    character.SetPosition(enlimPos[(int)parsed_enum]);
                    break;
            }

            // 캐릭터 방향
            character.SetDirection(_direction);

            character.image.enabled = true;
            // 캐릭터 이펙트 설정(null이 아닐 때만 동작)
            if (_effect.Equals("null") == false)
                character.SetCharacterEffect(_effect);
        }
        else
        {
            if (character.image != null && character.image.enabled == true)
                character.image.enabled = false;
        }
    }
}