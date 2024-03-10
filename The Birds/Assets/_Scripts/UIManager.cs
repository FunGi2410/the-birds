using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] private TextMeshProUGUI sunScoreText;
    [SerializeField] private TextMeshProUGUI timeGameText;

    [SerializeField] private GameObject gameOverPanel;

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
    public TextMeshProUGUI TimeGameText { get => timeGameText; set => timeGameText = value; }
    public GameObject GameOverPanel { get => gameOverPanel; set => gameOverPanel = value; }

    private void Awake()
    {
        instance = this;
    }

    public void DisplayGameOverPanel()
    {
        this.GameOverPanel.SetActive(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
