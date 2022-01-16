using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGeneration : MonoBehaviour
{
    public GameObject obstacle;
    public int xPos;
    public int zPos;
    public int obstacleCount;

    // Start is called before the first frame update
    void Start()
    {
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
            xPos = Random.Range(-4, 4);
            zPos = Random.Range(-25, 25);
            Instantiate(obstacle, new Vector3(xPos, 1.0f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.01f);
            obstacleCount++;

        }
    }
}
