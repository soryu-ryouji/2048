using UnityEngine.UI;

public class GameOverPanel : BasePanel
{
    public Button againBtn;
    public override void Init()
    {
        againBtn.onClick.AddListener(() => {
            GameManager.Instance.NewGame();
        });
    }
}