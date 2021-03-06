using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
/// <summary>
/// Webに接続し、WebAPIを呼び出すクラス
/// </summary>
public class ConnectAPI : MonoBehaviour
{
    /// <summary>
    /// URLのルートパス + ?zipcode=
    /// </summary>
    const string URL = "http://localhost:8080/zipcode/ZipcodeServlet?zipcode=";


    /// <summary>
    /// DBから取得したzipcodeの情報
    /// </summary>
    ZipcodeData zipcodeData;

    /// <summary>
    /// 取得した郵便番号に関する情報を
    /// 外部から参照できるようにする
    /// </summary>
    /// <returns></returns>

    public ZipcodeData Zipcode()
    {
        return zipcodeData;
    }

    /// <summary>
    /// ネット接続用の処理 
    /// GETメソッド (JSONの取得)
    /// zipnumは入力されるzipcode
    /// </summary>
    /// <param name="zipnum"></param>
    ///<returns></returns>
   
    public IEnumerator GetZipcode(string zipnum)
    {
        // UnityWebRequest.Get(URL + zipnum)は指定したURLへGETリクエストを送る
        // UnityWebRequestURIからデータを取得するオブジェクト
        UnityWebRequest request = UnityWebRequest.Get(URL + zipnum);
       
        //リクエストを送り、レスポンスが返ってくるまで実行を待つ
        yield return request.SendWebRequest();

        // エラーが起きた場合はログを返す
        // このUnityWebRequestでシステムエラーが発生した後、trueを返します。 
        if (request.isNetworkError)
        {
            Debug.Log(request.error);
            Debug.Log(request.error);
        }
        else // 正常に接続できた場合
        {
            // デバッグ用表示
            Debug.Log("GetZipcode : " + request.downloadHandler.text);
            // JsonUtility.FromJson(json) : JSONtextデータからオブジェクトを作成します 
            // json : JSONtextデータ : request.downloadHandler.text : jsonテキスト
            zipcodeData = JsonUtility.FromJson<ZipcodeData>(request.downloadHandler.text); 
            
        }

    }
    
    

   
}
