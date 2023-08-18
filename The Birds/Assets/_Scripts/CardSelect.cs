using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardSelect : MonoBehaviour, IPointerDownHandler
{
    public GameObject objectDrag;

    public GameObject cardInBar;

    public Canvas canvas;

    bool isChoosed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (InBarManager.Instance.targetPosInBars.Count <= InBarManager.Instance.curMaxSlot && !this.isChoosed)
        {
            this.isChoosed = true;
            GameObject cardInBarInstance = Instantiate(this.cardInBar, this.canvas.transform);
            cardInBarInstance.transform.position = this.transform.position;
            cardInBarInstance.GetComponent<CardInBar>().posCardSelect = this.gameObject.transform;

            InBarManager.Instance.selectedCards.Add(cardInBarInstance);
            cardInBarInstance.name = "Card " + (InBarManager.Instance.selectedCards.Count).ToString();

            // Blur card when selected
            Image imgObj = this.gameObject.transform.GetChild(1).GetComponent<Image>();
            var tmpColor = imgObj.color;
            tmpColor.a = 0.3f;
            imgObj.color = tmpColor;
        }
    }
}
