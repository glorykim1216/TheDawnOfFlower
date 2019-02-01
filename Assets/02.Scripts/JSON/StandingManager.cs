// 언어 JSON 파싱

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using System.IO;

public class StandingManager : MonoSingleton<StandingManager>
{
    Dictionary<string, StandingInfo> DicStandingInfo = new Dictionary<string, StandingInfo>();

    public bool LoadJson()
    {
        #region Resources에서 로드
        TextAsset standingInfoJSON = Resources.Load<TextAsset>("JSON/Standing_Info");

        JSONNode rootNode = JSON.Parse(standingInfoJSON.text);

        foreach (KeyValuePair<string, JSONNode> pair in rootNode as JSONObject)
        {
            StandingInfo standingInfo = new StandingInfo(pair.Key, pair.Value);
            DicStandingInfo.Add(pair.Key, standingInfo);
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

    public StandingInfo GetInfo(string _key)
    {
        StandingInfo standingInfo = null;
        DicStandingInfo.TryGetValue(_key, out standingInfo);

        if (standingInfo == null)
        {
            Debug.LogError("1. JSON 로드 확인, 2. JSON KEY 값 확인");
            return null;
        }

        return standingInfo;
    }
}
