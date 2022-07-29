using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowController : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;

    [SerializeField] 
    private GameObject _gameOver;
    
    [SerializeField]
    private Parallax _parallax;
    
    [SerializeField]
    private Player _player;
    private Vector3 _playerInitialPosition;

    public Text scoreText;
    private int score;
    
    #region Menu
    
    public void OpenMenu()
    {
        _menu.SetActive(true);
        
        _gameOver.SetActive(false);
        
        _parallax.StopParallax();
        
        _player.transform.localPosition = _playerInitialPosition;
        _player.enabled = false;
        
        Debug.Log("ABRIU MENU");
    }
    
    #endregion
    
    #region Game
    
    public void OpenGame()
    {
        _menu.SetActive(false);
        
        _gameOver.SetActive(false);
        
        _parallax.StartParallax();

        _player.transform.localPosition = _playerInitialPosition;
        _player.direction = Vector3.zero;
        _player.enabled = true;
        
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
        
        Debug.Log("ABRIU JOGO");
    }
    
    #endregion
    
    #region Results
    
    public void OpenResults()
    {
        _menu.SetActive(false);
        
        _gameOver.SetActive(true);
        
        _parallax.StopParallax();
        
        _player.enabled = false;
        
        Debug.Log("ABRIU RESULTADOS");
    }
    
    #endregion
    
    private static FlowController _instance;

    public static FlowController Global => _instance;

    private void Awake()
    {
        _instance = this;
        _playerInitialPosition = _player.transform.localPosition;

        OpenMenu();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
