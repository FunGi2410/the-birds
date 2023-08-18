using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBarManager : MonoBehaviour
{
    public List<GameObject> targetPosInBars;
    public List<GameObject> selectedCards;
    public int curMaxSlot;

    Vector3 nextToPos = new Vector3(107.3f, 0f);

    public static InBarManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;

        CardInBar.ChangePosCard += this.ChangePosCard;
    }

    public void AddTargetPos()
    {
        if (this.targetPosInBars.Count > this.curMaxSlot) return;
        //GameObject targetPos = Instantiate(this.targetPosInBars[0], this.gameObject.transform);
        GameObject targetPos = new GameObject();
        targetPos.transform.parent = this.gameObject.transform;
        targetPos.transform.position = this.targetPosInBars[this.targetPosInBars.Count - 1].transform.position + this.nextToPos;
        print(this.targetPosInBars[this.targetPosInBars.Count - 1]);
        this.targetPosInBars.Add(targetPos);
    }

    public void ChangePosCard()
    {
        for (int i = 0; i < this.selectedCards.Count; i++)
        {
            this.selectedCards[i].GetComponent<CardInBar>().MoveEvent(this.targetPosInBars[i].transform);
        }
    }
}
