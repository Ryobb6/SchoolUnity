using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public List<GameObject> texts = new List<GameObject>();
    public List<GameObject> gameObjects = new List<GameObject>();
    private List<float> diffList = new List<float>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            Vector3 diff = gameObject.transform.position - this.transform.position;
            diffList.Add(diff.magnitude);

        }
    }
}
