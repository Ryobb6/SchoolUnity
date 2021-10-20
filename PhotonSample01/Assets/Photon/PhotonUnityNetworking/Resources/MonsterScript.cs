using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    private Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up"))
        {
            OnButtonForword();
        }
        else
        {
            animator.SetBool("walk", false);
        }

        if (Input.GetKey("right"))
        {
            OnButtonRotateR();
        }

        if (Input.GetKey("left"))
        {
            OnButtonRotateL();
        }
    }

    public void OnButtonForword()
    {
        transform.position += transform.forward * 0.05f;
        animator.SetBool("walk", true);
    }

    public void OnButtonRotateR()
    {
        transform.Rotate(0, 10, 0);
    }

    public void OnButtonRotateL()
    {
        transform.Rotate(0, -10, 0);
    }




}