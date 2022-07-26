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
    
    [SerializeField]
    private Spawner _spawner;

    [SerializeField]
    private Text _scoreText;
    
    [SerializeField]
    private Text _highScoreText;
    
    private int _score;
    
    #region Menu
    
    public void OpenMenu()
    {
        _menu.SetActive(true);
        
        _gameOver.SetActive(false);
        
        _parallax.StopParallax();

        _spawner.enabled = false;
        
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
        
        _spawner.enabled = true;
        
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

        _score = 0;
        _scoreText.text = _score.ToString();
        
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
        
        _spawner.enabled = false;
        
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            pipes[i].enabled = false;
        }

        var highScore = PlayerPrefs.GetInt("HighScore", 0);

        highScore = (highScore >= _score) ? highScore : _score;
        PlayerPrefs.SetInt("HighScore", highScore);

        _highScoreText.text = highScore.ToString();
        
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
        _score++;
        _scoreText.text = _score.ToString();
    }
}
