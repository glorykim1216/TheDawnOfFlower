// LanguageManager 파싱 할 정보를 담는 클래스

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class LanguageInfo
{
    string strKey = string.Empty;
    List<string> nameList = new List<string>();
    List<string> contentsList = new List<string>();

    public List<string> NAME_LIST { get { return nameList; } }
    public List<string> CONTENTS_LIST { get { return contentsList; } }

    public LanguageInfo(string _strKey, JSONNode _nodeData)
    {
        strKey = _strKey;

        JSONArray arrName = _nodeData["Name"].AsArray;
        if (arrName != null)
        {
            for (int i = 0; i < arrName.Count; i++)
			{
                nameList.Add(arrName[i]);
			}
        }

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
