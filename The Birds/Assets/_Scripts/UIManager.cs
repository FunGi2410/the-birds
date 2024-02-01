using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI sunScoreText;

    private float halfHeightOfCanvas;
    private float halfWidthOfCanvas;

    [SerializeField] private RectTransform canvasRec;

    private void Start()
    {
        //this.screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        this.HalfHeightOfCanvas = canvasRec.rect.height / 2;
        this.HalfWidthOfCanvas = canvasRec.rect.width / 2;
    }

    public TextMeshProUGUI SunScoreText { get => sunScoreText; set => sunScoreText = value; }
    public float HalfHeightOfCanvas { get => halfHeightOfCanvas; set => halfHeightOfCanvas = value; }
    public float HalfWidthOfCanvas { get => halfWidthOfCanvas; set => halfWidthOfCanvas = value; }

    private void Awake()
    {
        instance = this;
    }
}
