using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchPanelController : MonoBehaviour
{
    public GameObject Simple;
    public GameObject Details;

    public Button SimpleButton;
    public Button DetailsButton;

    void Start()
    {
        // ボタンAが押されたときの処理
        SimpleButton.onClick.AddListener(() =>
        {
            Simple.SetActive(true);
            Details.SetActive(false);
        });

        // ボタンBが押されたときの処理
        DetailsButton.onClick.AddListener(() =>
        {
            Details.SetActive(true);
            Simple.SetActive(false);
        });
    }
}
