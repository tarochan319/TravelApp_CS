using UnityEngine;
using UnityEngine.UI;
using NativeGalleryNamespace;

public class GalleryAccess : MonoBehaviour
{
    public Image triggerImage;  // トリガーとなる画像
    public Image displayImage;  // 実際に読み込んだ画像を表示するためのオブジェクト

    public void PickImage()
    {
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery(
            (path) =>
            {
                if (path != null)
                {
                    Texture2D texture = new Texture2D(2, 2);
                    if (texture.LoadImage(System.IO.File.ReadAllBytes(path)))
                    {
                        Sprite sprite = Sprite.Create(
                            texture,
                            new Rect(0, 0, texture.width, texture.height),
                            new Vector2(0.5f, 0.5f)
                        );

                        // 読み込んだ画像を表示するオブジェクトに取得画像をセット
                        displayImage.sprite = sprite;

                        // 画像を表示するオブジェクトをアクティブにする
                        displayImage.gameObject.SetActive(true);
                    }
                    else
                    {
                        Debug.LogError("Failed to load image from path: " + path);
                    }
                }
            }
        );

        if (permission == NativeGallery.Permission.Denied)
        {
            // ユーザーに許可を求める等の処理
            Debug.LogWarning("User denied gallery access!");
        }
    }
}
