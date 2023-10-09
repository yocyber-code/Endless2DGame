using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    public GameObject[] obstacles;
    public bool isGameOver = false;

    public static SpawnPointController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    private void CreateObstacle()
    {
        int randomIndex = Random.Range(0, obstacles.Count());
        Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity);
    }

    IEnumerator SpawnObstacle()
    {
        while (!isGameOver)
        {
            CreateObstacle();
            float randomTime = Random.Range(1.3f, 2.5f);
            yield return new WaitForSeconds(randomTime);
        }
    }

    public void StopSpawn()
    {
        isGameOver = true;
    }
}
