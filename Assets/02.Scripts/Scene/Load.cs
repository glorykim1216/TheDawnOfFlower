using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    void Awake()
    {
        GameManager.Instance.InitGameManager();
    }
}
