using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class SnapScrolling : MonoBehaviour, IEndDragHandler, IDragHandler
{
    public RectTransform panel;
    public RectTransform center;
    private float[] points;
    private bool dragging = false;
    private int btnDistance;
    private int startButtonIndex = 0;

    void Start()
    {
        int btnLength = panel.childCount;
        points = new float[btnLength];
        startButtonIndex = 0; // startButtonIndex を0で初期化

        if (btnLength > 1) // 子オブジェクトが2つ以上あることを確認
        {
            btnDistance = (int)
                Mathf.Abs(
                    panel.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y
                        - panel.GetChild(1).GetComponent<RectTransform>().anchoredPosition.y
                );
        }
        else
        {
            // エラーハンドリング: 子オブジェクトが1つしかない、またはない場合
            Debug.LogError("Not enough child objects in panel to determine btnDistance");
            return; // 早期リターン
        }

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = startButtonIndex * btnDistance * -1;
            Debug.Log("Point " + i + ": " + points[i]); // 各ポイントの値をログに出力
            startButtonIndex++;
        }
    }

    public void OnDrag(PointerEventData data) { }

    public void OnEndDrag(PointerEventData data)
    {
        Debug.Log("ドラッグ終了の検知！");
        dragging = false;
    }

    void Update()
    {
        if (!dragging)
        {
            LerpToButton(GetNearestPoint());
        }
    }

    void LerpToButton(int positionIndex)
    {
        float newY = Mathf.Lerp(
            panel.anchoredPosition.y,
            points[positionIndex],
            Time.deltaTime * 10f
        );
        Vector2 newPosition = new Vector2(panel.anchoredPosition.x, newY);
        panel.anchoredPosition = newPosition;
    }

    int GetNearestPoint()
    {
        float minDistance = Mathf.Infinity;
        int nearestIndex = 0;

        for (int i = 0; i < points.Length; i++)
        {
            float distance = Mathf.Abs(
                center.transform.position.y - panel.GetChild(i).transform.position.y
            );
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }
}
