using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    private GameObject playerObj;
    public static int coinVariationsNum = 1;
    public GameObject[] coins = new GameObject[coinVariationsNum]; // TODO DIFFERENT COINS
    public int xPos;
    public int zPos;
    public int coinsSectionCount;
    private int coinTypeNum;
    private int coinGeneratedNum;

    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        Physics.IgnoreLayerCollision(7, 3, true);
    }

    // Update is called once per frame
    void Update()
    {
        float playerZpos = playerObj.transform.position.z + 100 - 50.0f * coinGeneratedNum;
        if (playerZpos >= 50.0f)
        {
            StartCoroutine(CoinsGenerate());
        }
    }

    IEnumerator CoinsGenerate()
    {
        int coinsCount = 0;

        while ((int)(coinsCount / 5) < (int)(coinsSectionCount / 5))
        {
            xPos = Random.Range(-3, 4);
            if (coinGeneratedNum == 0)
            {
                zPos = Random.Range(-15, 25);
            }
            else
            {
                zPos = Random.Range(-25, 25) + coinGeneratedNum * 50;

            }

            for (int i = 0; i < 5; i++)
            {
                zPos += 1;
                coinTypeNum = Random.Range(0, coinVariationsNum);
                Instantiate(coins[coinTypeNum], new Vector3(xPos, 1.0f, zPos), Quaternion.AngleAxis(90, Vector3.right));
                coinsCount++;
            }
        }
        coinGeneratedNum++;
        coinsCount = 0;
        yield return new WaitForSeconds(0.1f);
    }

    // TODO Destroying
}
