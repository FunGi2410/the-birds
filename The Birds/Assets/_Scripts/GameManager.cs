using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject draggingObj;
    public GameObject currentContaiter;
    public static GameManager instance;

    public static UnityAction startGame;

    [SerializeField] private const int ONESUNSCORE = 25;
    [SerializeField] private int sunScore;

    public int SunScore { get => sunScore; set => sunScore = value; }

    private void Awake()
    {
        instance = this;
    }

    public void AddSun()
    {
        this.SunScore += ONESUNSCORE;
        UIManager.instance.SunScoreText.text = this.SunScore.ToString();
    }

    public void SubSun(int priceSun)
    {
        this.SunScore -= priceSun;
        UIManager.instance.SunScoreText.text = this.SunScore.ToString();
    }

    public bool PlaceObject()
    {
        if (this.draggingObj != null && this.currentContaiter != null)
        {
            GameObject objPlace = Instantiate(this.draggingObj.GetComponent<ObjectDragging>().card.objectGame, this.currentContaiter.transform);
            objPlace.transform.localPosition = Vector2.zero;
            this.currentContaiter.GetComponent<ObjectContainer>().isFull = true;
            this.currentContaiter.GetComponent<Collider2D>().enabled = false;
            return true;
        }
        return false;
    }

    public void OnStartGame()
    {
        startGame?.Invoke();
    }
}
