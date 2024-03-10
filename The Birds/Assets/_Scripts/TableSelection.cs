using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableSelection : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private bool isActive = true;
    void Start()
    {
        this.anim = GetComponent<Animator>();
    }

    public void OnStartGameLevel()
    {
        this.anim.SetTrigger("StartLevel");
    }

    public void SetActiveObject()
    {
        this.isActive = !this.isActive;
        this.gameObject.SetActive(this.isActive);
    }
}
