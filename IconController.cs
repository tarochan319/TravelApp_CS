using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconController : MonoBehaviour
{
    public GameObject background; //白の背景画像

    private static IconController currentActiveIcon; //アクティブアイコンのトラッキング

    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(false);
    }

    public void OnIconTapped()
    {
        if (currentActiveIcon && currentActiveIcon != this)
        {
            currentActiveIcon.HideBackground();
        }

        ShowBackground();
        currentActiveIcon = this;
    }

    void ShowBackground()
    {
        background.SetActive(true);
    }

    void HideBackground()
    {
        background.SetActive(false);
    }
}
