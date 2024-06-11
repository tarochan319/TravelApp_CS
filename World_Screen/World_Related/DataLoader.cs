// using System.Collections;
// using UnityEngine;
// using UnityEngine.Networking;

// public class DataLoader : MonoBehaviour
// {
//     private string baseUrl = "http://localhost:5000/";

//     public PostManager postManager; // PostManagerへの参照

//     // 観光地情報を取得するメソッド
//     public void LoadTravelSpots()
//     {
//         StartCoroutine(GetTravelSpots());
//     }

//     private IEnumerator GetTravelSpots()
//     {
//         using (UnityWebRequest www = UnityWebRequest.Get(baseUrl + "/travelSpots"))
//         {
//             yield return www.SendWebRequest();

//             if (www.result == UnityWebRequest.Result.ConnectionError)
//             {
//                 Debug.Log(www.error);
//             }
//             else
//             {
//                 Debug.Log(www.downloadHandler.text);

//                 TouristSpotList spotList = JsonUtility.FromJson<TouristSpotList>(
//                     "{\"spots\":" + www.downloadHandler.text + "}"
//                 );

//                 TourismPost[] posts = ConvertToTourismPosts(spotList.spots); // データの変換処理
//                 postManager.GeneratePosts(posts); // PostManagerのメソッドを呼び出してUIを更新
//             }
//         }
//     }

//     // TouristSpotのリストをTourismPostの配列に変換する
//     private TourismPost[] ConvertToTourismPosts(List<TouristSpot> spots)
//     {
//         // ここでの変換処理を実装します。
//         // 例えば、TouristSpotのnameをTourismPostのusernameとして使う、等の変換が必要です。
//         // この例では、TourismPostのデータモデルの定義が必要となります。
//     }
// }
