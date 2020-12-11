/**
 * @Description : LanguageManager 파싱 할 정보를 담는 클래스.
 * @Author : glorykim
 */

using System.Collections.Generic;
using SimpleJSON;

public class LanguageInfo
{
    List<string> nameList = new List<string>();
    List<string> contentsList = new List<string>();

    // name, contents 프로퍼티
    public List<string> NAME_LIST { get { return nameList; } }
    public List<string> CONTENTS_LIST { get { return contentsList; } }

    // 해당 List에 데이터를 저장
    public LanguageInfo(JSONNode _nodeData)
    {
        // Name 저장
        JSONArray arrName = _nodeData["Name"].AsArray;
        if (arrName != null)
        {
            for (int i = 0; i < arrName.Count; i++)
			{
                nameList.Add(arrName[i]);
			}
        }

        // Contents 저장
        JSONArray arrContens = _nodeData["Contents"].AsArray;
        if (arrContens != null)
        {
            for (int i = 0; i < arrContens.Count; i++)
            {
                contentsList.Add(arrContens[i]);
            }
        }
    }
}
