using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Webへの接続処理全てを担うクラス
/// </summary>
public class ConnectManager
{
    /// <summary>
    ///  接続するGASのルートパス(GASへリクエストを送る形)
    ///  URL : https://script.google.com/macros/s/AKfycbxEyr_2YmHVipfh9rYQWyKUjOG2k_tE3Q-5j7-2_nZUEXX2UIHHrDpZgupagOohdBJJ/exec
    ///  Deploy ID : AKfycbxEyr_2YmHVipfh9rYQWyKUjOG2k_tE3Q-5j7-2_nZUEXX2UIHHrDpZgupagOohdBJJ
    /// </summary>
    const string ROOTPATH = "https://script.google.com/macros/s/AKfycbxEyr_2YmHVipfh9rYQWyKUjOG2k_tE3Q-5j7-2_nZUEXX2UIHHrDpZgupagOohdBJJ/exec";

    /// <summary>
    /// GASからのJSONを、受け取る為の、文字列
    /// Web接続はコルーチンで行うが、コルーチンはIEnumerator型以外の戻り値を返せないため、取得結果をフィールド変数に入れたりしておく必要がある
    /// </summary>
    string getText = "";

    // 取得結果を他のインスタンスから引き出すためのプロパティ
    public string GetText
    {
        get { return getText; }
    }

    // お約束① Webとの通信はコルーチンの中で行う
    //お約束① Webとの通信はコルーチンの中で行う
    //(サーバーからのレスポンスを待たなければいけないため)
    public IEnumerator SampleWebConnectionPost()
    {
        //【Getとの相違点①】postしたデータをサーバ側から引き出すには、「リクエストパラメータ」の設定が必要となる。
　　 //Unityでは、WWWform型インスタンスを新規作成し、その「AddField(”その情報を引き出すためのキー”,Postしたい情報)」メソッドを
       // 使うことでリクエストパラメータを設定できる。

        int sampleNumber = 1;
        WWWForm form = new WWWForm();
        form.AddField("number", sampleNumber);

        //お約束②UnityWebRequest型の変数を宣言。
        //【Getとの相違点②】
        //newしたUnityWebRequestインスタンスから
        //「Post(データをPostしたいURL,それに使いたいWWWform)」メソッドを呼び出し、
        //そのコルーチンでアクセスしたいURLの文字列と、先ほど作ったWWWform型インスタンスを引数として渡す

        UnityWebRequest request = UnityWebRequest.Post(ROOTPATH + "getranking", form);


        //お約束③UnityWebRequest内のフィールド「downloadHandler」に、DownloadHandler型にキャストしたDownloadHandlerBuffer型インスタンスを
        //newして代入(受け取ったレスポンスの情報はこのインスタンスに入る)
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();


        // お約束④：（サンプルプログラムではPostメソッドで特定の形式 のファイルを受け取る必要がないため、リクエストヘッダは定義しない）
        // お約束⑤：レスポンスが返ってくるまで実行を待つ
        yield return request.SendWebRequest();
        
        // お約束⑥：エラーが起きた場合はログを返す 何かエラーが発生した際は、
        //UnityWebRequest型インスタンスの「isXXError」系フィールドにtrueが入る。
        //それを条件式に使うことでエラーを検出する
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            Debug.Log(request.responseCode);
        }
        //正常に接続できた場合
        else
        {
            //お約束⑦：UnityWebRequest.downloadHandlerから取得したレスポンスを取り出す
            //今回受け取っているのは文字列なので、「text」フィールドから文字列型で取り出せる
        getText = request.downloadHandler.text;
        }
    }


}

