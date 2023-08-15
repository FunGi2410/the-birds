using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosInBarManager : MonoBehaviour
{
    public List<GameObject> targetPosInBars;
    public int curMaxSlot;

    Vector3 nextToPos = new Vector3(107.3f, 0f);

    public static PosInBarManager Instance { get; private set; }
    void Awake()
    {
        Instance = this;
    }

    public void AddTargetPos()
    {
        if (this.targetPosInBars.Count > this.curMaxSlot) return;
        GameObject targetPos = Instantiate(this.targetPosInBars[0], this.gameObject.transform);
        targetPos.transform.position = this.targetPosInBars[this.targetPosInBars.Count - 1].transform.position + this.nextToPos;
        this.targetPosInBars.Add(targetPos);
    }
}
