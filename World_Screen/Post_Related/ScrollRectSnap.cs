using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectSnap : MonoBehaviour
{
    public RectTransform content;
    public float snapPosition;

    private ScrollRect scrollRect;

    void Start()
    {
        scrollRect = GetComponent<ScrollRect>();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        float difference = Mathf.Abs(content.anchoredPosition.x - snapPosition);
        if (difference < 100f)
        {
            content.anchoredPosition = new Vector2(snapPosition, content.anchoredPosition.y);
        }
    }
}
