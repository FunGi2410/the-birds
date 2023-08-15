using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject objectDrag;
    public GameObject objectGame;
    private GameObject objectDragInstance;
    public GameManager gameManager;
    public Canvas canvas;

    private void Start()
    {
        this.gameManager = GameManager.instance;
        this.canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.objectDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //print("On Clicked");
        this.objectDragInstance = Instantiate(this.objectDrag, this.canvas.transform);
        this.objectDragInstance.transform.position = Input.mousePosition;
        this.objectDragInstance.GetComponent<ObjectDragging>().card = this;

        this.gameManager.draggingObj = this.objectDragInstance;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.gameManager.PlaceObject();
        this.gameManager.draggingObj = null;
        Destroy(this.objectDragInstance);
    }
}
