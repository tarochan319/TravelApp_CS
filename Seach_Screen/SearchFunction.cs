using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SearchFunction : MonoBehaviour
{
    public InputField inputField;
    public GameObject entryPrefab;
    public Transform entryContainer;

    [System.Serializable]
    public class SearchResult
    {
        public string id;
        public string keyword;
        public string title;
        public string created_at;
    }

    private string baseURL = "http://localhost:5000"; // サーバーアドレス

    public void OnSearchButtonClick()
    {
        string keyword = inputField.text;
        StartCoroutine(GetDataFromServer(keyword));
    }

    IEnumerator GetDataFromServer(string keyword)
    {
        string url = baseURL + "/search?keyword=" + UnityWebRequest.EscapeURL(keyword);

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Request succeeded."); // Debug log here

            string responseText = request.downloadHandler.text;
            Debug.Log("Response: " + responseText); // Debug log here

            // レスポンスが空の配列でない場合だけパースを行う
            if (!string.IsNullOrEmpty(responseText) && responseText != "[]")
            {
                string json = "{\"items\":" + responseText + "}";
                TemporaryWrapper wrapper = new TemporaryWrapper();
                JsonUtility.FromJsonOverwrite(json, wrapper);

                SearchResult[] results = wrapper.items;

                // 結果をUIに表示
                foreach (SearchResult result in results)
                {
                    GameObject resultEntryObject = Instantiate(entryPrefab, entryContainer);
                    ResultEntryController resultEntry =
                        resultEntryObject.GetComponent<ResultEntryController>();
                    resultEntry.SetResult(result);
                }
            }
            else
            {
                Debug.Log("No results found.");
            }
        }
    }

    [System.Serializable]
    public class TemporaryWrapper
    {
        public SearchResult[] items;
    }

    public void OnEndEdit()
    {
        string keyword = inputField.text; // Get the search keyword
        StartCoroutine(GetDataFromServer(keyword)); // Perform the search
    }
}
