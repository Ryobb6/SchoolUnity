using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class CSVReader : MonoBehaviour
{
    // リンク https://docs.google.com/spreadsheets/d/121fsll0Qx3UcPNGFqrD0G6F3QoHJ2XsrG8D2MAq1sU4/edit?usp=sharing
    const string SHEET_ID = "121fsll0Qx3UcPNGFqrD0G6F3QoHJ2XsrG8D2MAq1sU4"; // シートID(上記URLのd/~/editの~部分)
    const string SHEET_NAME = "シート1"; // シートの下に書いているシート名

    // コルーチンの開始
    public void OnClickLoadingButton()
    {
        StartCoroutine(Method(SHEET_NAME));
    }

    // コルーチンの定義
    IEnumerator Method(string _SHEET_NAME)
    {
        // GetRequestの送信 1.request インスタンスの作成
        UnityWebRequest request = UnityWebRequest.Get("https://docs.google.com/spreadsheets/d/" + SHEET_ID + "/gviz/tq?tqx=out:csv&sheet=" + _SHEET_NAME);
        // 2.requestインスタンスの送信
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            List<string[]> characterDataArrayList = ConvertToArrayListFrom(request.downloadHandler.text);
            foreach (string[] characterDataArray in characterDataArrayList)
            {
                CharacterData characterData = new CharacterData(characterDataArray);
                characterData.DebugParametaView();
            }
        }
    }

    /// <summary>
    /// Downloadhandlerにて取得した文字列を文字列型配列リストに変換する
    /// </summary>
    /// <param name="_text"></param>
    /// <returns></returns>
    private List<string[]> ConvertToArrayListFrom(string _text)
    {
        List<string[]> characterDataArrayList = new List<string[]>();
        StringReader reader = new StringReader(_text);
        reader.ReadLine();  // 1行目はラベルなので外す（1行読み込んでなにもしない）
        while (reader.Peek() != -1) 　// Peek(): 使用できる文字がないか、ストリームがシークをサポートしていない場合は - 1
        {
            string line = reader.ReadLine();      // 一行ずつ読み込み
            string[] elements = line.Split(',');    // 行のセルは,で区切られる
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == "\"\"")
                {
                    continue;                       // 空白は除去
                }
                elements[i] = elements[i].TrimStart('"').TrimEnd('"');
            }
            characterDataArrayList.Add(elements);
        }
        return characterDataArrayList;
    }
}