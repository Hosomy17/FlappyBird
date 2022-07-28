using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    [SerializeField]
    private Parallax _parallax;
    
    #region Menu
    
    public void OpenMenu()
    {
        _parallax.StopParallax();
        Debug.Log("ABRIU MENU");
    }
    
    #endregion
    
    #region Game
    
    public void OpenGame()
    {
        _parallax.StartParallax();
        Debug.Log("ABRIU JOGO");
    }
    
    #endregion
    
    #region Results
    
    public void OpenResults()
    {
        _parallax.StopParallax();
        Debug.Log("ABRIU RESULTADOS");
    }
    
    #endregion
    
    private static FlowController _instance;

    public static FlowController Global => _instance;

    private void Awake()
    {
        _instance = this;
    }
}
