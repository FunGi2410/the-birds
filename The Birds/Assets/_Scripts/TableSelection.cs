using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSelection : MonoBehaviour
{
    public Animator anim;
    void Start()
    {
        this.anim = GetComponent<Animator>();
    }

    public void OnStartGameLevel()
    {
        this.anim.SetTrigger("StartLevel");
    }
}
