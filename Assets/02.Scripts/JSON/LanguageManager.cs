// 언어 JSON 파싱

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System.IO;

public class LanguageManager : MonoSingleton<LanguageManager>
{
    Dictionary<string, LanguageInfo> DicLanguageInfo = new Dictionary<string, LanguageInfo>();

    public bool LoadJson()
    {
        #region Resources에서 로드
        TextAsset languageInfoJSON = Resources.Load<TextAsset>("JSON/Chapter_KOR");

        JSONNode rootNode = JSON.Parse(languageInfoJSON.text);

        foreach (KeyValuePair<string, JSONNode> pair in rootNode as JSONObject)
        {
            LanguageInfo languageInfo = new LanguageInfo(pair.Value);
            DicLanguageInfo.Add(pair.Key, languageInfo);
        }
    
        #endregion

        #region StreamingAssets에서 로드
        //string filePath = Application.streamingAssetsPath + "/JSON/LANGUAGE_INFO.json";
        //string languageInfoJSON = File.ReadAllText(filePath);
        //JSONNode rootNode = JSON.Parse(languageInfoJSON);

        //foreach (KeyValuePair<string, JSONNode> pair in rootNode as JSONObject)
        //{
        //    LanguageInfo languageInfo = new LanguageInfo(pair.Key, pair.Value);
        //    DicLanguageInfo.Add(pair.Key, languageInfo);
        //}
        #endregion

        return true;
    }

    public LanguageInfo GetText(string _key)
    {
        LanguageInfo languageInfo = null;
        DicLanguageInfo.TryGetValue(_key, out languageInfo);

        if (languageInfo == null)
        {
            Debug.LogError("1. JSON 로드 확인, 2. JSON KEY 값 확인");
            return null;
        }

        return languageInfo;
    }
}
