using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PostManager : MonoBehaviour
{
    public GameObject postPrefab; // 投稿内容を表示するPrefab
    public Transform contentArea; // 投稿内容を追加するエリア

    public Image postImage;
    public InputField postText;

    public void PostContent()
    {
        GameObject newPost = Instantiate(postPrefab, contentArea);

        Image image = newPost.GetComponentInChildren<Image>(); // Prefab内のImageコンポーネントを取得
        TMP_Text text = newPost.GetComponentInChildren<TMP_Text>(); // Prefab内のTextMesh Proコンポーネントを取得

        image.sprite = postImage.sprite;
        text.text = postText.text;

        // 投稿後、入力内容をクリアするなどの処理を追加
        postImage.sprite = null;
        postText.text = "";
    }
}
