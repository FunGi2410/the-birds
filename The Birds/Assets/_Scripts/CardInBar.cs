using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardInBar : MonoBehaviour, IPointerDownHandler
{
    private Transform posTarget;
    public float speed;
    public Canvas canvas;

    public Transform posCardSelect;

    bool isReturn = false;

    private void Start()
    {
        this.canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        this.posTarget = GameObject.FindGameObjectWithTag("TargetPosInBar").GetComponent<Transform>();

        
        this.posTarget.position = PosInBarManager.Instance.targetPosInBars[PosInBarManager.Instance.targetPosInBars.Count - 1].transform.position;
        PosInBarManager.Instance.AddTargetPos();
        StartCoroutine(MoveToTarget(this.posTarget));
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.isReturn = true;
        StartCoroutine(MoveToTarget(this.posCardSelect));
    }

    IEnumerator MoveToTarget(Transform posTarget)
    {
        while (this.gameObject.transform.position != posTarget.position)
        {
            Vector2 dir = posTarget.position - this.gameObject.transform.position;
            if (Mathf.Abs(dir.sqrMagnitude) < 100f)
            {
                StopCoroutine("MoveToBarSelect");
                print("stop coroudtine");
                //this.cardSelectInBarInstance = Instantiate(this.gameObject, this.canvas.transform);
                this.gameObject.transform.position = new Vector2(posTarget.position.x, posTarget.position.y);
                if (this.isReturn)
                {
                    Destroy(this.gameObject);
                }
            }
            
            dir = dir.normalized;
            this.gameObject.transform.Translate(dir * this.speed);
            //transform.Translate(dir * this.speed * 0.01f);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
