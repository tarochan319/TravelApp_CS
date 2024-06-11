using UnityEngine;
using UnityEngine.UI;

public class ArrowButton : MonoBehaviour
{
    public ImageSwipe imageSwipe;
    public int direction; // 1 for right, -1 for left

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => imageSwipe.ChangeImage(direction));
    }
}
