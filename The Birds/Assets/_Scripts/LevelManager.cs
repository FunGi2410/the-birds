using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int curNumberLevel;
    private RewardCard rewardCard;
    private PlayerManager playerManager;
    private Transform canvasTransform;

    private void Start()
    {
        this.rewardCard = GameObject.FindGameObjectWithTag("RewardCard").GetComponent<RewardCard>();
        this.playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
        this.canvasTransform = GameObject.FindGameObjectWithTag("Canvas").transform;

    }

    public int CurNumberLevel { get => curNumberLevel; set => curNumberLevel = value; }

    public void WinLevel()
    {
        // Init reward card
        GameObject rewardCardIntance = Instantiate(this.rewardCard.GetRewardCard(this.CurNumberLevel), this.canvasTransform);
        rewardCardIntance.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        // Unlock card in collection
        this.playerManager.UnlockNewPlantCard(this.CurNumberLevel);
    }
}
