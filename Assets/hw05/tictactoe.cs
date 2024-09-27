using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class tictactoe : MonoBehaviour
{
    private enum Player
    {
        O,
        X
    }
    private const int MagicSquareSum = 15;
    private Player currentPlayer;
    private HashSet<int>[] playerMoves = new HashSet<int>[2]
    {
        new HashSet<int>(), // O
        new HashSet<int>()  // X    
    };
    private HashSet<(int sum, Player player)> playerSums;
    private bool isEndGame;
    private int moveCounter;
    private int[] score = {0,0};

    [SerializeField] private GameObject endGamePopup;
    [SerializeField] private TextMeshProUGUI endGameMessage;
    [SerializeField] private TextMeshProUGUI PlayerOScore;
    [SerializeField] private TextMeshProUGUI PlayerXScore;

    private void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == Player.O) ? Player.X : Player.O;
    }

    private void ResetState()
    {
        currentPlayer = Player.O;
        moveCounter = 0;
        playerMoves[0] = new HashSet<int>();
        playerMoves[1] = new HashSet<int>();
        isEndGame = false;
        playerSums = new HashSet<(int, Player)>();
    }

    private void ResetUI()
    {
        GameObject[] cells = GameObject.FindGameObjectsWithTag("boardCell");
        foreach (GameObject cell in cells)
        {
            cell.GetComponent<TMP_Text>().SetText("");
        }
        endGamePopup.SetActive(false);
    }

    private void UpdateScoreUI()
    {
        PlayerOScore.text = score[0].ToString();
        PlayerXScore.text = score[1].ToString();
    }

    private bool IsWon(int sum) 
    {
        if (playerSums.Contains((sum, currentPlayer))) // isWon?
        {
            score[(int)currentPlayer]++;
            UpdateScoreUI();
            EndGame($"{currentPlayer} WON!");
            return true;
        }
        return false;
    }

    private bool IsTie()
    {
        if (moveCounter == 9)
        {
            EndGame($"It's a TIE!");
            return true;
        }
        return false;
    }

    private void AddNewMove(int magicValue)
    {
        HashSet<int> currPlayerMoves = playerMoves[(int)currentPlayer];
        foreach (int move in currPlayerMoves) // add new sums to the collection
        {
            playerSums.Add((move + magicValue, currentPlayer));
        }
        currPlayerMoves.Add(magicValue);
    }

    public void OnCellClick(int magicValue)
    {
        int sumKey = MagicSquareSum - magicValue;
        moveCounter++;

        if (isEndGame || IsWon(sumKey) || IsTie()) return; // is game ended

        AddNewMove(magicValue);
        SwitchPlayer();
        playerSums.Remove((sumKey, currentPlayer)); // remove irrelevant sums, if exist.

    }

    public void OnCellClickUI(TMP_Text cell)
    {
        if (isEndGame) return;
        if (string.IsNullOrEmpty(cell.text))
        {
            cell.text = currentPlayer.ToString();
        }
    }

    public void ResetGame()
    {
        ResetState();
        ResetUI();
    }

    public void EndGame(string message)
    {
        isEndGame = true;
        endGameMessage.text = message;
        endGamePopup.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetState();
        endGamePopup.SetActive(false);
    }

}
