using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] bool vsAI;
    // Niz koji vodi racuna o odigranim poljima (index = red * 3 + kolona)
    private int[] playedFields = new int[9];
    int movesLeft;
    [SerializeField] public int playerOnMove;
    bool checkForWin;
    //int clickedButtonIndex;
    ClickHandler clickHandler;
    void Awake()
    {
        clickHandler = FindObjectOfType<ClickHandler>();
    }
    void Start()
    {
        playerOnMove = 1;
        movesLeft = 9;
        RestartPlayedFields();
    }
    void Update()
    {
        if (movesLeft == 0 || checkForWin)
        {
            EndGame();
            movesLeft--;
            checkForWin = false;
        }
    }
    public void SetPlayedFieldAt(int index, int playerOnMove)
    {
        playedFields[index] = playerOnMove;
    }
    public int GetColumn(int lastPlayedFieldsIndex)
    {
        return lastPlayedFieldsIndex % 3;
    }
    public int GetRow(int lastPlayedFieldsIndex)
    {
        return (lastPlayedFieldsIndex / 3) * 3;
    }
    public bool CheckForWin(int playerOnMove, int lastPlayedFieldsIndex)
    {
        Debug.Log("CheckingForWin...");
        /* Provjerava red*/
        int counter = 3;
        for (int i = GetRow(lastPlayedFieldsIndex), j = GetRow(lastPlayedFieldsIndex) + 3; i < j; i++)
        {

            if (playedFields[i] == playerOnMove)
                counter--;

        }
        if (counter == 0)
            return true;
        counter = 3;
        /* Provjerava kolonu */
        for (int i = GetColumn(lastPlayedFieldsIndex); (i < 9); i += 3)
        {
            if (playedFields[i] == playerOnMove)
                counter--;
        }
        if (counter == 0)
            return true;
        /* Provjerava glavnu diagonalu*/
        counter = 3;
        for (int i = 0; (i < 9); i += 4)
        {
            if (playedFields[i] == playerOnMove)
                counter--;

        }
        if (counter == 0)
            return true;
        /* Provjerava sporednu diagonalu*/
        counter = 3;
        for (int i = 2; (i < 7); i += 2)
        {
            if (playedFields[i] == playerOnMove)
                counter--;
        }
        if (counter == 0)
            return true;
        return false;
    }
    public void RestartPlayedFields()
    {
        Debug.Log("Restart playing fields...");
        for (int i = 0; i < 9; i++)
        {
            Debug.Log("Looped " + i);
            playedFields[i] = 0;
            clickHandler.HandleButtonClick(0, i);
        }
    }
    private void ChangePlayer(int lastPlayer)
    {
        if (lastPlayer == 1)
            playerOnMove++;
        else
            playerOnMove--;
    }

    // public void ButtonClicked(int playerOnMove)
    // {
    //     public int clickedButtonIndex;
    // Debug.Log(clickedButtonIndex);
    //     if (playedFields[clickedButtonIndex] == 0)

    //}
    public void ButtonClicked(int playedFieldsIndex)
    {
        if (playedFields[playedFieldsIndex] == 0)
        {
            clickHandler.HandleButtonClick(playerOnMove, playedFieldsIndex);
            PlayedAMove(playedFieldsIndex);
        }
    }
    public void PlayedAMove(int clickedButtonIndex)
    {
        clickHandler.HandleButtonClick(playerOnMove, clickedButtonIndex);
        Debug.Log(" before "); printPlayedFiedls();
        SetPlayedFieldAt(clickedButtonIndex, playerOnMove);
        Debug.Log(" after "); printPlayedFiedls();
        Debug.Log("Clicked button index: " + clickedButtonIndex);
        movesLeft--; Debug.Log("Moves left " + movesLeft);
        checkForWin = CheckForWin(playerOnMove, clickedButtonIndex);

        ChangePlayer(playerOnMove);
    }
    public void EndGame()
    {
        Debug.Log("Game ended!");
        Debug.Log("Disabeling buttons");
        clickHandler.disableButtons();
        // TODO : Load next scene
    }
    public void printPlayedFiedls()
    {
        string temp = "";
        for (int i = 0; i < 9; i++)
            temp += playedFields[i].ToString();
        Debug.Log(temp);
    }

}
