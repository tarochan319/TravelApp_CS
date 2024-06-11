using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultEntryController : MonoBehaviour
{
    public Image icon;
    public Text title;

    // 最初に検索結果のUIを非表示にする
    void Start()
    {
        // gameObject.SetActive(false);
    }

    // 検索結果のタイトルに基づいてアイコン名を決定する
    string GetIconNameBasedOnTitle(string title)
    {
        if (title.StartsWith("【食べ物】"))
        {
            return "icon/food";
        }
        else if (title.StartsWith("【泊まる】"))
        {
            return "icon/hotel";
        }
        else
        {
            // デフォルトのアイコン名を返す
            return "icon/Null_Image";
        }
    }

    public void SetResult(SearchFunction.SearchResult result)
    {
        gameObject.SetActive(true);

        title.text = result.title;

        // アイコン名を決定する
        string iconName = GetIconNameBasedOnTitle(result.title);

        Sprite iconSprite = Resources.Load<Sprite>(iconName);
        if (iconSprite != null)
        {
            icon.sprite = iconSprite;
        }
        else
        {
            Debug.LogWarning("Icon not found: " + iconName);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
