using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

// 표정
enum Deneheu
{
    Deneheu_anger,
    Deneheu_basic,
    Deneheu_cruelty,
    Deneheu_sad,
    Deneheu_shy,
    Deneheu_smile,
    Deneheu_surprised,
    Deneheu_surprised2,
    Deneheu_sword,
    MAX
}
enum Seti
{
    Seti_m_anger,
    Seti_m_basic,
    Seti_m_sad,
    Seti_m_smile,
    Seti_m_think,
    MAX
}
enum Tamuz
{
    Tamuz_anger,
    Tamuz_bed_smile,
    Tamuz_basic,
    Tamuz_difficulty,
    Tamuz_sad,
    Tamuz_shy,
    Tamuz_smile,
    Tamuz_think,
    MAX
}
enum Maid
{
    Maid,
    MAX
}
enum Nepelalia
{
    Nepelalia,
    MAX
}
enum Tito
{
    Tito,
    MAX
}

public class SpriteManager : MonoSingleton<SpriteManager>
{
    private Dictionary<string, Sprite> DicExpression = new Dictionary<string, Sprite>();
    private StringBuilder sb = new StringBuilder();
    private Sprite sprite;
    private string expressionName;
    public void Load()
    {
        for (int i = 0; i < (int)Seti.MAX; i++)
        {
            Seti enumTmp = (Seti)i;
            expressionName = enumTmp.ToString();
            sb.Length = 0;
            sb.AppendFormat("{0}{1}{2}", "Standing/", "Seti/", expressionName);
            sprite = Resources.Load<Sprite>(sb.ToString());
            DicExpression.Add(expressionName, sprite);
        }
        for (int i = 0; i < (int)Deneheu.MAX; i++)
        {
            Deneheu enumTmp = (Deneheu)i;
            expressionName = enumTmp.ToString();
            sb.Length = 0;
            sb.AppendFormat("{0}{1}{2}", "Standing/", "Deneheu", expressionName);
            sprite = Resources.Load<Sprite>(sb.ToString());
            DicExpression.Add(expressionName, sprite);
        }
        for (int i = 0; i < (int)Tamuz.MAX; i++)
        {
            Tamuz enumTmp = (Tamuz)i;
            expressionName = enumTmp.ToString();
            sb.Length = 0;
            sb.AppendFormat("{0}{1}{2}", "Standing/", "Tamuz", expressionName);
            sprite = Resources.Load<Sprite>(sb.ToString());
            DicExpression.Add(expressionName, sprite);
        }
        for (int i = 0; i < (int)Maid.MAX; i++)
        {
            Maid enumTmp = (Maid)i;
            expressionName = enumTmp.ToString();
            sb.Length = 0;
            sb.AppendFormat("{0}{1}{2}", "Standing/", "Maid", expressionName);
            sprite = Resources.Load<Sprite>(sb.ToString());
            DicExpression.Add(expressionName, sprite);
        }
        for (int i = 0; i < (int)Nepelalia.MAX; i++)
        {
            Nepelalia enumTmp = (Nepelalia)i;
            expressionName = enumTmp.ToString();
            sb.Length = 0;
            sb.AppendFormat("{0}{1}{2}", "Standing/", "Nepelalia", expressionName);
            sprite = Resources.Load<Sprite>(sb.ToString());
            DicExpression.Add(expressionName, sprite);
        }
        for (int i = 0; i < (int)Tito.MAX; i++)
        {
            Tito enumTmp = (Tito)i;
            expressionName = enumTmp.ToString();
            sb.Length = 0;
            sb.AppendFormat("{0}{1}{2}", "Standing/", "Tito", expressionName);
            sprite = Resources.Load<Sprite>(sb.ToString());
            DicExpression.Add(expressionName, sprite);
        }
    }

    public Sprite GetSprite(string _key)
    {
        Sprite spriteTmp;
        DicExpression.TryGetValue(_key, out spriteTmp);

        if (spriteTmp == null)
        {
            Debug.LogError("1. JSON name 확인, 2. 이미지 있는지 확인");
            return null;
        }

        return spriteTmp;
    }
}
