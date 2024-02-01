using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardInBar : MonoBehaviour, IPointerDownHandler
{
    public float speed;
    public Transform posCardSelect;

    public GameObject canvas;

    bool isReturn = false;

    [SerializeField] private GameObject cardInGame;

    public static UnityAction ChangePosCard;
    //public static UnityAction StateCardSelect;

    private void Start()
    {
        StartCoroutine(MoveToTarget(InBarManager.Instance.targetPosInBars[InBarManager.Instance.targetPosInBars.Count - 1].transform));
        InBarManager.Instance.AddTargetPos();

        this.canvas = GameObject.FindGameObjectWithTag("Canvas");

        GameManager.startGame += this.DesCardBarAndInitCardGame;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.isReturn) return;
        this.isReturn = true;

        Destroy(InBarManager.Instance.targetPosInBars[InBarManager.Instance.targetPosInBars.Count - 1]);
        InBarManager.Instance.targetPosInBars.RemoveAt(InBarManager.Instance.targetPosInBars.Count - 1);
        
        StartCoroutine(MoveToTarget(this.posCardSelect));
    }

    public void DesCardBarAndInitCardGame()
    {
        // Init card in game
        GameObject cardGameInstance = Instantiate(this.cardInGame, this.canvas.transform);
        cardGameInstance.transform.position = this.transform.position;
        // Destroy card in bar
        Destroy(this.gameObject);
    }

    public void MoveEvent(Transform target)
    {
        StartCoroutine(MoveToTarget(target));
    }

    IEnumerator MoveToTarget(Transform posTarget)
    {
        while (true)
        {
            //print(this.gameObject.name);
            /*Vector2 dir = posTarget.position - this.gameObject.transform.position;
            print(dir.sqrMagnitude);*/
            //print(Vector3.Distance(transform.position, posTarget.position));
            if (Vector3.Distance(transform.position, posTarget.position) < 0.001f/*Mathf.Abs(dir.sqrMagnitude) < 200f*/)
            {
                StopCoroutine("MoveToTarget");
                //print("stop coroudtine");
                //this.cardSelectInBarInstance = Instantiate(this.gameObject, this.canvas.transform);
                //this.gameObject.transform.position = new Vector2(posTarget.position.x, posTarget.position.y);

                if (this.isReturn)
                {
                    Destroy(this.gameObject);
                    GameManager.startGame -= this.DesCardBarAndInitCardGame;
                    InBarManager.Instance.selectedCards.Remove(this.gameObject);
                    ChangePosCard?.Invoke();

                    this.posCardSelect.GetComponent<CardSelect>().SetStateCard();
                    //StateCardSelect?.Invoke();
                }
                break;
            }

            transform.position = Vector3.MoveTowards(transform.position, posTarget.position, this.speed);

            yield return new WaitForSeconds(0.01f);
        }
    }
}
