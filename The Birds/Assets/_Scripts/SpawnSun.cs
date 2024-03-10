using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSun : MonoBehaviour
{
    public GameObject sunPrefab;

    private float timer = 0f;
    public Vector2 secondsBetweenSpawnMinMax;

    private float spawnAngleMax = 15f;

    private void Start()
    {
        float sunHeight = sunPrefab.GetComponent<RectTransform>().rect.height;
        UIManager.instance.HalfHeightOfCanvas += sunHeight;
    }

    private void Update()
    {
        if (!GameManager.instance.IsStartGame) return;
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
