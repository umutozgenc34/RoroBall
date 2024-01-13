using System.Collections.Generic;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
    public static EndGameManager endManager;
    public bool redWin;
    public bool blueWin;

    private PanelController panelController;
    private Ball winCondition;


    private void Awake()
    {
        endManager = this;
    }
    void Start()
    {

    }
  
    
    public void ResolveGame()
    {

        if (winCondition.scoreRed >= winCondition.maxScore)
        {
            RedWinGame();
        }
        else if (winCondition.scoreBlue >= winCondition.maxScore)
        {
            BlueWinGame();
        }
    }
    public void RedScore()
    {
        panelController.ActivateRedScoreScreen();
    }

    public void BlueScore()
    {
        panelController.ActivateBlueScoreScreen();
    }
    public void RedWinGame()
    {
        panelController.ActivateRedWinScreen();
    }
    public void BlueWinGame()
    {
        panelController.ActivateBlueWinScreen();
    }

    public void RegisterPanelController(PanelController pC)
    {
        panelController = pC;
    }

    public void RegisterWinCondition(Ball wC)
    {
        winCondition = wC;
    }
}