using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] private CanvasGroup cGroup;
    public GameObject redScoreScreen;
    [SerializeField] private GameObject blueScoreScreen;
    [SerializeField] private GameObject redWinScreen;
    [SerializeField] private GameObject blueWinScreen;

    // Start is called before the first frame update
    void Start()
    {
        EndGameManager.endManager.RegisterPanelController(this);
    }

    public void ActivateRedScoreScreen()
    {
        cGroup.alpha = 0;
        redScoreScreen.SetActive(true);
    }
    public void ActivateBlueScoreScreen()
    {
        cGroup.alpha = 0;
        blueScoreScreen.SetActive(true);
    }

    public void ActivateRedWinScreen()
    {
        cGroup.alpha = 1;
        redWinScreen.SetActive(true);
    }

    public void ActivateBlueWinScreen()
    {
        cGroup.alpha = 1;
        blueWinScreen.SetActive(true);
    }


}
