using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : BasePanel
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TileBoard board;
    public TextMeshProUGUI maximText;

    public string[] maxims = {
        "Never, never, never give up.",
        "Genius is one percent inspiration and ninety-nine percent perspiration.",
        "Success seems to be connected with action. Successful people keep moving. They make mistakes, but they don't quit.",
        "He that can have patience can have what he will.",
        "Action is the foundational key to all success.",
        "Great works are performed not by strength but by perseverance.",
    };
    public override void Init()
    {
        var index = Random.Range(0, maxims.Length);
        maximText.text = maxims[index];
    }
}
