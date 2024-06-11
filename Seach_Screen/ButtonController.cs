using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button simpleButton;
    public Button detailsButton;
    public Image simpleBackground;
    public Image detailsBackground;

    void Start()
    {
        simpleBackground.gameObject.SetActive(false); // 最初は非表示にする
        detailsBackground.gameObject.SetActive(false); // 最初は非表示にする
        simpleButton.onClick.AddListener(OnSimpleButtonClick); // Simpleボタンが押された時のイベントリスナーを追加
        detailsButton.onClick.AddListener(OnDetailsButtonClick); // Detailsボタンが押された時のイベントリスナーを追加
    }

    void OnSimpleButtonClick()
    {
        simpleBackground.gameObject.SetActive(true); // Simple背景を表示
        detailsBackground.gameObject.SetActive(false); // Details背景を非表示にする
    }

    void OnDetailsButtonClick()
    {
        simpleBackground.gameObject.SetActive(false); // Simple背景を非表示にする
        detailsBackground.gameObject.SetActive(true); // Details背景を表示
    }
}
