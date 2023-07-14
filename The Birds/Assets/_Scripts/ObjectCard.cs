using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject objectDrag;
    public GameObject objectGame;
    public Canvas canvas;
    private GameObject objectDragInstance;
    public GameManager gameManager;

    private void Start()
    {
        this.gameManager = GameManager.instance;
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.objectDragInstance.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
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
