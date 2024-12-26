using UnityEngine;
using System.Collections;
using System;

public class GameManager : HyDSingleton<GameManager>
{

    public static bool GameIsOver = false;

    public GameOver gameOverUI;
    public GameObject completeLevelUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameOver();
    }

    private void LoadGameOver()
    {
        if (gameOverUI != null) return;
        this.gameOverUI = GameObject.FindAnyObjectByType<GameOver>();
    }

    protected override void Start()
    {
        GameIsOver = false;
    }

    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
            
        }
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.gameObject.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }

}
