// LanguageManager 파싱 할 정보를 담는 클래스

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class StandingInfo
{
    List<string> backgroundList = new List<string>();
    List<string> s1List = new List<string>();
    List<string> s1DirectionList = new List<string>();
    List<float> s1ScaleList = new List<float>();
    List<string> s1EffectList = new List<string>();
    List<string> s2List = new List<string>();
    List<string> s2DirectionList = new List<string>();
    List<float> s2ScaleList = new List<float>();
    List<string> s2EffectList = new List<string>();
    List<string> s3List = new List<string>();
    List<string> s3DirectionList = new List<string>();
    List<float> s3ScaleList = new List<float>();
    List<string> s3EffectList = new List<string>();
    List<string> sound1List = new List<string>();
    List<string> sound2List = new List<string>();

    public List<string> BACKGROUND_LIST { get { return backgroundList; } }
    public List<string> S1_LIST { get { return s1List; } }
    public List<string> S1_DIRECTION_LIST { get { return s1DirectionList; } }
    public List<float> S1_SCALE_LIST { get { return s1ScaleList; } }
    public List<string> S1_EFFECT_LIST { get { return s1EffectList; } }
    public List<string> S2_LIST { get { return s2List; } }
    public List<string> S2_DIRECTION_LIST { get { return s2DirectionList; } }
    public List<float> S2_SCALE_LIST { get { return s2ScaleList; } }
    public List<string> S2_EFFECT_LIST { get { return s2EffectList; } }
    public List<string> S3_LIST { get { return s3List; } }
    public List<string> S3_DIRECTION_LIST { get { return s3DirectionList; } }
    public List<float> S3_SCALE_LIST { get { return s3ScaleList; } }
    public List<string> S3_EFFECT_LIST { get { return s3EffectList; } }
    public List<string> SOUND1_LIST { get { return sound1List; } }
    public List<string> SOUND2_LIST { get { return sound2List; } }

    public StandingInfo(JSONNode _nodeData)
    {
        JSONArray arrTemp = _nodeData["Background"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                backgroundList.Add(arrTemp[i]);
            }
        }

        arrTemp = _nodeData["S1"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s1List.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S1_Direction"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s1DirectionList.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S1_Scale"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s1ScaleList.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S1_Effect"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s1EffectList.Add(arrTemp[i]);
            }
        }

        arrTemp = _nodeData["S2"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s2List.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S2_Direction"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s2DirectionList.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S2_Scale"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s2ScaleList.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S2_Effect"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s2EffectList.Add(arrTemp[i]);
            }
        }

        arrTemp = _nodeData["S3"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s3List.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S3_Direction"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s3DirectionList.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S3_Scale"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s3ScaleList.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["S3_Effect"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                s3EffectList.Add(arrTemp[i]);
            }
        }

        arrTemp = _nodeData["Sound1"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                sound1List.Add(arrTemp[i]);
            }
        }
        arrTemp = _nodeData["Sound2"].AsArray;
        if (arrTemp != null)
        {
            for (int i = 0; i < arrTemp.Count; i++)
            {
                sound2List.Add(arrTemp[i]);
            }
        }
    }
}
