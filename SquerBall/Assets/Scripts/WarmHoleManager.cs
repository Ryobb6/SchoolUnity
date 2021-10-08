using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarmHoleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem holeEnter;
    [SerializeField] ParticleSystem holeCenter;
    [SerializeField] ParticleSystem holeOut;
    [SerializeField] bool isWarmHoleEngineStart = false;

    private void Start()
    {
        
        if (isWarmHoleEngineStart)
        {
            WarmHoleEngineStart();
        }
        else
        {
            WarmHoleEngineStop();
        }

    }


    public void WarmHoleEngineStart()
    {
        holeEnter.Play();
        holeCenter.Play();
        holeOut.Play();

        // エンジンンのスタートフラグ : 開始
        isWarmHoleEngineStart = true;
    }

    public void WarmHoleEngineStop()
    {
        holeEnter.Stop();
        holeCenter.Stop();
        holeOut.Stop();

        // エンジンンのスタートフラグ : 停止
        isWarmHoleEngineStart = false;
    }

}
