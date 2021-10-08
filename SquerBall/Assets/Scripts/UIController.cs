using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public List<Text> texts = new List<Text>();
    public List<GameObject> gameObjects = new List<GameObject>();
    private List<Vector3> diffList = new List<Vector3>();
    void Start()
    {
        foreach(GameObject gameObject in gameObjects)
        {
            Vector3 diff = gameObject.transform.position - this.transform.position;
            diffList.Add(diff);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
