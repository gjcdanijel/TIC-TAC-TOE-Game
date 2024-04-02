using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class GameFinish : MonoBehaviour
{
    GameObject gameFinishCanvas;
    public GameObject textObject;
    private TextMeshProUGUI finishText;
    void Awake()
    {

        gameFinishCanvas = GameObject.Find("GameFinishCanvas");
        finishText = GetComponent<TextMeshProUGUI>();
    }
    public void hideFinishWindow()
    {

        Debug.Log("Hiding finish window." + gameFinishCanvas.name);
        gameFinishCanvas.SetActive(false);
    }

    public void showFinishWindow(int playerOnMove)
    {
        Debug.Log("Showing finish window.");
        gameFinishCanvas.SetActive(true);
        setFinishText(playerOnMove);
    }
    public void setFinishText(int playerOnMove)
    {
        if (playerOnMove != 0)
            finishText.text = "Player " + playerOnMove + " won!";
        else
            finishText.text = "Draw!";
    }
}
