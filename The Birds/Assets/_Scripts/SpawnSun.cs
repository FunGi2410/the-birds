using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSun : MonoBehaviour
{
    public GameObject sunPrefab;

    private float timer = 0f;
    public Vector2 secondsBetweenSpawnMinMax;

    private float spawnAngleMax = 15f;

    //[SerializeField] private RectTransform canvasRec;


    private void Start()
    {
        //this.screenHalfHeightInWorldUnits = Camera.main.orthographicSize;
        /*this.halfHeightOfCanvas = canvasRec.rect.height / 2;
        this.halfWidthOfCanvas = canvasRec.rect.width / 2;*/
        float sunHeight = sunPrefab.GetComponent<RectTransform>().rect.height;
        UIManager.instance.HalfHeightOfCanvas += sunHeight;
    }

    private void Update()
    {
        float secondsBetweenSpawn = Random.Range(secondsBetweenSpawnMinMax.x, secondsBetweenSpawnMinMax.y);
        timer += Time.deltaTime;
        if (timer < secondsBetweenSpawn) return;
        timer = 0f;
        this.Spawn();
    }

    protected virtual void Spawn()
    {
        GameObject sun = Instantiate(sunPrefab, transform);
        float ranPosX = Random.Range(-UIManager.instance.HalfWidthOfCanvas, UIManager.instance.HalfWidthOfCanvas);
        sun.GetComponent<RectTransform>().anchoredPosition = new Vector2(ranPosX, UIManager.instance.HalfHeightOfCanvas);

        float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
        sun.transform.Rotate(Vector3.forward * spawnAngle);
    }
}
