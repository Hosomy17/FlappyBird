using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    public void GameOver()
    {
        FlowController.Global.OpenResults();
    }
    

    public void IncreaseScore()
    {
        score++;
        
    }
}
