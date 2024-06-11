using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    // シーン遷移のメソッド
    public void GoToSelectScene()
    {
        SceneManager.LoadScene("Select_Screen");
    }

    public void GoToWorld()
    {
        SceneManager.LoadScene("World");
    }

    public void GoToSearch()
    {
        SceneManager.LoadScene("Search_Screen");
    }
}
