using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 読み込んだデータを保持するクラス
/// </summary>
public class CharacterData
{
    int id;
    string name;
    int hp;
    int at;


    /// <summary>
    /// データリストを読み込んでフィールドにセットするコンストラクタ
    /// </summary>
    /// <param name="_dataList"></param>
    public CharacterData(string[] _dataList)
    {
        id = int.Parse(_dataList[0]);
        name = _dataList[1];
        hp = int.Parse(_dataList[2]);
        at = int.Parse(_dataList[3]);
    }

    /// <summary>
    /// Debug用　読み込んだデータの表示
    /// </summary>
    public void DebugParametaView()
    {
        Debug.Log(String.Format("{0} id:{1} hp:{2} at:{3}", name, id, hp, at));
    }
}