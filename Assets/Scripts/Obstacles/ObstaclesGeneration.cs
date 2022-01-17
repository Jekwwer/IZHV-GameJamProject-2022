using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGeneration : MonoBehaviour
{
    private GameObject playerObj;
    public GameObject[] obstacles;
    public int xPos;
    public int zPos;
    public int obstacleCount;
    private int obstacleNum;
    private int obstacleDropNum;
    private int obstacleDestroyedDropNum;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        Physics.IgnoreLayerCollision(3, 6, true);

    }

    // Update is called once per frame
    void Update()
    {
        float playerZpos = playerObj.transform.position.z + 100 - 50.0f * obstacleDropNum;
        if (playerZpos >= 50.0f)
        {
            StartCoroutine(GenerateObstacles());
        }
/*        if (((playerObj.transform.position.z + 50.0f) - 50.0f * obstacleDestroyedDropNum) >= 100.0f)
        {
            StartCoroutine(DestroyObstacles());
        }*/
    }

    IEnumerator GenerateObstacles()
    {
        while (obstacleCount <= 10)
        {
            xPos = Random.Range(-3, 4);
            // First obstacles spawns farther
            if (obstacleDropNum == 0)
            {
                zPos = Random.Range(-15, 25);
            }
            else
            {
                zPos = Random.Range(-25, 25) + obstacleDropNum * 50;

            }
            // take a random obstacle
            obstacleNum = Random.Range(0, 4);
            var rotation = Random.Range(0, 12);
            Instantiate(obstacles[obstacleNum], new Vector3(xPos, 0.9f, zPos), Quaternion.AngleAxis(rotation * 15, Vector3.up));
            obstacleCount++;
        }
        obstacleDropNum++;
        obstacleCount = 0;
        yield return new WaitForSeconds(0.1f);
    }

}
