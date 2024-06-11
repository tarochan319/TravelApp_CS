using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImageSwipe : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public List<Sprite> images; // 切り替える画像のリスト
    public List<string> titles; // タイトルをリスト化
    public List<string> texts; // テキストをリスト化
    public Image displayImage; // 表示するImageコンポーネント
    private int index = 0; // 現在の画像のインデックス
    public Text titleText; // タイトルををオブジェクト化
    public Text contentText; // テキストをオブジェクト化

    void Start()
    {
        // 初期状態の設定
        displayImage.sprite = images[index];
        titleText.text = titles[index];
        contentText.text = texts[index];
    }

    public void OnDrag(PointerEventData eventData)
    {
        // スワイプの距離に応じて画像を切り替える処理をここに書く
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // スワイプ終了時の処理をここに書く
        float difference = eventData.pressPosition.x - eventData.position.x;
        if (Mathf.Abs(difference) > 20)
        {
            if (difference > 0)
                ChangeImage(1); // 左へスワイプ
            else
                ChangeImage(-1); // 右へスワイプ
        }
    }

    public void ChangeImage(int diff)
    {
        index += diff;
        if (index < 0)
            index = images.Count - 1; // 最初の画像より前に行こうとしたら最後の画像に
        else if (index >= images.Count)
            index = 0; // 最後の画像より先に行こうとしたら最初の画像に

        displayImage.sprite = images[index]; // 画像を切り替える
        titleText.text = titles[index]; // タイトルを切り替える
        contentText.text = texts[index]; // テキストを切り替える
    }
}
