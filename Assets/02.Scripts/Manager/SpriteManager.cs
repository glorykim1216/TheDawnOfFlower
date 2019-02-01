using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class SpriteManager : MonoSingleton<SpriteManager>
{
    private Dictionary<string, Sprite> DicExpression = new Dictionary<string, Sprite>();
    private StringBuilder sb = new StringBuilder();

    public void LoadSprite()
    {
        StandingSpriteLoad();
        BackgroudSpriteLoad();
    }

    public Sprite GetSprite(string _key)
    {
        Sprite spriteTmp;
        DicExpression.TryGetValue(_key, out spriteTmp);

        if (spriteTmp == null)
        {
            Debug.LogError("1. key값 확인, 2. 이미지 있는지 확인");
            return null;
        }

        return spriteTmp;
    }

    // 이미지 로드
    public void ResourcesSpriteLoad(string _str)
    {
        sb.Length = 0;
        sb.AppendFormat("{0}{1}", "Sprite/", _str);
        Sprite[] resourcesSprite = Resources.LoadAll<Sprite>(sb.ToString());
        for (int i = 0; i < resourcesSprite.Length; i++)
        {
            DicExpression.Add(resourcesSprite[i].name, resourcesSprite[i]);
        }
    }

    public void StandingSpriteLoad()
    {
        // 세티
        ResourcesSpriteLoad("Standing/Seti");

        // 데네흐
        ResourcesSpriteLoad("Standing/Deneheu");

        // 타무즈
        ResourcesSpriteLoad("Standing/Tamuz");

        // 시녀
        ResourcesSpriteLoad("Standing/Maid");

        //네페라리아
        ResourcesSpriteLoad("Standing/Nepelalia");
    }

    public void BackgroudSpriteLoad()
    {
        // 배경
        ResourcesSpriteLoad("Background");
    }
}
