using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Joint内にオブジェクトが侵入した際の動作を決めるためのクラスです
/// </summary>
public class JointAction : MonoBehaviour
{
    [SerializeField] private GameObject FromRoadObject;
    private CapselAreaDetector cad;
    private void OnTriggerEnter(Collider other)
    {
        /// とおってきた道(Road)の、スクリプトを切る
        cad = FromRoadObject.GetComponent<CapselAreaDetector>();
        cad.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
