using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject draggingObj;
    public GameObject currentContaiter;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlaceObject()
    {
        if (this.draggingObj != null && this.currentContaiter != null)
        {
            GameObject objPlace = Instantiate(this.draggingObj.GetComponent<ObjectDragging>().card.objectGame, this.currentContaiter.transform);
            objPlace.transform.localPosition = Vector2.zero;
            this.currentContaiter.GetComponent<ObjectContainer>().isFull = true;
            this.currentContaiter.GetComponent<Collider2D>().enabled = false;
        }
    }
}
