using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 都道府県名
    /// 表示用テキストボックス
    /// </summary>
    public Text pref;

    /// <summary>
    /// 市区町村名
    /// 表示用テキストボックス
    /// </summary>
    public Text city;

    /// <summary>
    /// 通り名
    /// 表示用テキストボックス
    /// </summary>
    public Text street;

    /// <summary>
    ///  郵便番号
    ///  入力用インプットボックス
    /// </summary>
    public InputField zipnum;

    /// <summary>
    /// API接続用管理クラス
    /// </summary>
    public ConnectAPI connectAPI;

    /// <summary>
    /// 郵便番号を入力欄から取得し文字列を返す
    /// 
    /// </summary>
    /// <returns></returns>
    public string Zipnum()
    {
        return zipnum.text;
    }

    /// <summary>
    /// 検索ボタン押下時
    /// </summary>
    public void OnsearchClick()
    {
        StartCoroutine(ConnectApiFindZipcodeData());
    }


    /// <summary>
    ///  API接続呼び出し
    ///  郵便番号情報取得後画面表示
    /// </summary>
    /// <returns></returns>
    /// <returns></returns>
    private IEnumerator ConnectApiFindZipcodeData()
    {
        // 郵便番号を取得
        // yield return でコルーチンを実行することでコルーチンの処理が終わるまで待機
        yield return StartCoroutine(connectAPI.GetZipcode(Zipnum()));

        // 画面表示
        SetText(connectAPI.Zipcode());
    
    }

    /// <summary>
    /// 受け取ったデータを画面に表示
    /// </summary>
    /// <param name="data">郵便番号を元に取得した情報</param>
    private void SetText(ZipcodeData data)
    {
        pref.text = data.address1;
        city.text = data.address2;
        street.text = data.address3;
    }
    
}
