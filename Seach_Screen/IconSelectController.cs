using UnityEngine;
using UnityEngine.UI;

public class IconSetter : MonoBehaviour
{
    public Image IconImage; // アイコンを表示するImageコンポーネント

    // タイトルテキストからキーワードを取得し、該当するアイコンを設定する
    public void SetIconBasedOnTitle(string title)
    {
        // タイトルから【】内のキーワードを取得
        int startIndex = title.IndexOf("【") + 1;
        int endIndex = title.IndexOf("】");
        string keyword = title.Substring(startIndex, endIndex - startIndex);

        Sprite newIcon = null;

        // キーワードに応じてアイコンをロード
        switch (keyword)
        {
            case "食べ物":
                newIcon = Resources.Load<Sprite>("Icon/Food");
                break;
            case "泊まる":
                newIcon = Resources.Load<Sprite>("Icon/Hotel");
                break;
            // 他のキーワードに対するケースもここに追加可能
        }

        if (newIcon)
        {
            IconImage.sprite = newIcon;
        }
    }
}
