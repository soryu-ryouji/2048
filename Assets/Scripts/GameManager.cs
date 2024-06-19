using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private GamePanel gamePanel;

    private int score;
    public int Score => score;

    private void Awake()
    {
        if (Instance != null) {
            DestroyImmediate(gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        gamePanel = UIManager.Instance.ShowPanel<GamePanel>();
        NewGame();
    }

    public void NewGame()
    {
        UIManager.Instance.HidePanel<GameOverPanel>();
        // reset score
        SetScore(0);
        gamePanel.bestScoreText.text = LoadHiscore().ToString();

        // update board state
        gamePanel.board.ClearBoard();
        gamePanel.board.CreateTile(2);
        gamePanel.board.enabled = true;
    }

    public void GameOver()
    {
        gamePanel.board.enabled = false;
        UIManager.Instance.ShowPanel<GameOverPanel>();
    }

    public void IncreaseScore(int points)
    {
        SetScore(score + points);
    }

    private void SetScore(int score)
    {
        this.score = score;
        gamePanel.scoreText.text = score.ToString();

        SaveHiscore();
    }

    private void SaveHiscore()
    {
        int hiscore = LoadHiscore();

        if (score > hiscore) {
            PlayerPrefs.SetInt("hiscore", score);
        }
    }

    private int LoadHiscore()
    {
        return PlayerPrefs.GetInt("hiscore", 0);
    }

}