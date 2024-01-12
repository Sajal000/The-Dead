using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class spawner : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text timeText;
    public float timeLeft = 60; 
    public List <GameObject> spherePrefabs = new List<GameObject>();
    public List<int> spawnBalls = new List<int>();

    public int points = 0;

    void Start()
    {
        for (int i = 0; i < spherePrefabs.Count; i++)
        {
            SpawnSphere(i);
        }
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("youLose");
        }
        timeText.text = "Time: " + timeLeft.ToString("0.0");
    }

    public void SpawnSphere(int prefabIndex)
    {

        //int randomIndex = Random.Range(0, spherePrefabs.Count);
        GameObject selectedSpherePrefab = spherePrefabs[prefabIndex];


        int spawnPointX = Random.Range(-10, 10);
        int spawnPointY = Random.Range(10, 20);
        int spawnPointZ = Random.Range(-10, 10);

        Vector3 spawnPosition = new Vector3(spawnPointX, spawnPointY, spawnPointZ);
        GameObject spawnedSphere = Instantiate(selectedSpherePrefab, spawnPosition, Quaternion.identity);

        spehereCollisonHandler collisionHandler = spawnedSphere.AddComponent<spehereCollisonHandler>();
        collisionHandler.spawner = this;
        collisionHandler.sphereColorTag = selectedSpherePrefab.tag;

        spawnBalls.Add(prefabIndex);
    }

    public void IncreasePoints()
    {
        points++;
        scoreText.text = "Score: " + points.ToString();
        Debug.Log("Points: " + points);

        if (points == 4)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("youWin");
        }

    }
}
