using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGeneration : MonoBehaviour
{
    public GameObject[] obstacles;
    public int xPos;
    public int zPos;
    public int obstacleCount;
    private int obstacleNum;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(3, 6, true);
        StartCoroutine(ObstacleDrop());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ObstacleDrop()
    {
        while(obstacleCount <= 10)
        {
            xPos = Random.Range(-3, 4);
            zPos = Random.Range(-15, 25);
            obstacleNum = Random.Range(0, 4);
            Instantiate(obstacles[obstacleNum], new Vector3(xPos, 0.9f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            obstacleCount++;
        }
    }
}
