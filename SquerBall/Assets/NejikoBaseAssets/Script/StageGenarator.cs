using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenarator : MonoBehaviour
{
    private const int StageChipSize = 30;
    private int currentChipIndex;

    // Inspectorにて設定
    public GameObject character; // ターゲットキャラクターの座標指定
    public GameObject[] stageChips; // ステージチッププレハブ配列 (Indexで管理)
    public int startChipIndex; // 自動生成開始インデックス　(ステージチッププレハブの為のIndex)
    public int preInstantiate; // 生成先読み個数 

    public List<GameObject> generatedStageList = new List<GameObject>(); // 生成済みステージチップの保持リスト



    // Start is called before the first frame update
    void Start()
    {
        // フィールドcurrentChipIndexの値設定
        this.currentChipIndex = this.startChipIndex - 1;
        UpdateStage(this.preInstantiate);

    }

    // Update is called once per frame
    void Update()
    {
        //キャラクターの位置から現在のステージチップのインデックスを計算 
        int charaPositinIndex = (int)(character.transform.position.z / StageChipSize);
        
        //次のステージチップに入ったらステージの更新処理を行う
        if(charaPositinIndex + preInstantiate > currentChipIndex)
        {
            UpdateStage(charaPositinIndex + preInstantiate);
        }
    }

    /// <summary>
    /// 指定のIndexまで
    /// </summary>
    /// <param name="toChipIndex"></param>
    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= this.currentChipIndex + 1)
        {
            return;
        }

        // 指定のステージチップまでを生成
        for (int i = currentChipIndex + 1; i <= toChipIndex; i++)
            {
                GameObject stageObject = GenerateStage(i);

                // 生成したステージチップを管理リストに追加
                generatedStageList.Add(stageObject);

            }

            // ステージ保持上限内になるまで古いステージを削除

        while(generatedStageList.Count > preInstantiate + 2)
        {
            DestroyOldestStage();
        }

        currentChipIndex = toChipIndex;

    }

    GameObject GenerateStage(int chipIndex)
    {
        int nextStageChip = Random.Range(0, stageChips.Length);

        GameObject stageObject = Instantiate<GameObject>(stageChips[nextStageChip], new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);
        return stageObject;
    }

    /// <summary>
    ///  一番古いステージを削除
    /// </summary>

    private void DestroyOldestStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage); // 引数にオブジェクト
     }

}
