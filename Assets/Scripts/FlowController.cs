using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    private static FlowController _instance;

    public static FlowController Global => _instance;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenMenu()
    {
        Debug.Log("ABRIU MENU");
    }

    public void OpenGame()
    {
        Debug.Log("ABRIU JOGO");
    }

    public void OpenResults()
    {
        Debug.Log("ABRIU RESULTADOS");
    }
}
