using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardInBar : MonoBehaviour, IPointerDownHandler
{
    //private Transform posTargetInBar;
    public float speed;
    //public Canvas canvas;

    public Transform posCardSelect;

    bool isReturn = false;

    public static UnityAction ChangePosCard;
    //public static UnityAction StateCardSelect;

    private void Start()
    {
        //this.canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        //this.posTargetInBar = GameObject.FindGameObjectWithTag("TargetPosInBar").GetComponent<Transform>();
        //this.posTargetInBar = InBarManager.Instance.targetPosInBars[InBarManager.Instance.targetPosInBars.Count - 1].transform;
        //this.posTargetInBar.position = InBarManager.Instance.targetPosInBars[InBarManager.Instance.targetPosInBars.Count - 1].transform.position;
        
        StartCoroutine(MoveToTarget(InBarManager.Instance.targetPosInBars[InBarManager.Instance.targetPosInBars.Count - 1].transform));
        InBarManager.Instance.AddTargetPos();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.isReturn) return;
        this.isReturn = true;

        Destroy(InBarManager.Instance.targetPosInBars[InBarManager.Instance.targetPosInBars.Count - 1]);
        InBarManager.Instance.targetPosInBars.RemoveAt(InBarManager.Instance.targetPosInBars.Count - 1);
        
        StartCoroutine(MoveToTarget(this.posCardSelect));
    }

    public void MoveEvent(Transform target)
    {
        StartCoroutine(MoveToTarget(target));
    }

    IEnumerator MoveToTarget(Transform posTarget)
    {
        while (this.gameObject.transform.position != posTarget.position)
        {
            print(this.gameObject.name);
            Vector2 dir = posTarget.position - this.gameObject.transform.position;
            print(dir.sqrMagnitude);
            if (Mathf.Abs(dir.sqrMagnitude) < 200f)
            {
                /*StopCoroutine("MoveToTarget");
                print("stop coroudtine");*/
                //this.cardSelectInBarInstance = Instantiate(this.gameObject, this.canvas.transform);
                this.gameObject.transform.position = new Vector2(posTarget.position.x, posTarget.position.y);
                if (this.isReturn)
                {
                    Destroy(this.gameObject);
                    InBarManager.Instance.selectedCards.Remove(this.gameObject);
                    ChangePosCard?.Invoke();

                    this.posCardSelect.GetComponent<CardSelect>().SetStateCard();
                    //StateCardSelect?.Invoke();
                }
            }
            
            dir = dir.normalized;
            this.gameObject.transform.Translate(dir * this.speed);
            //transform.Translate(dir * this.speed * 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
