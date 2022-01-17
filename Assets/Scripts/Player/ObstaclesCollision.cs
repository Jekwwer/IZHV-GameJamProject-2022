using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ObstaclesCollision : MonoBehaviour
{
    private GameObject playerObj;
    private float timer = 0;
    private bool timerReached = false;
    private bool startTimer = false;

    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");

        Physics.IgnoreLayerCollision(0, 8, true);
    }

    // Update is called once per frame
    void Update()
    {
        // Timer for gameover screen
        if (startTimer)
        {
            // Move player up for preventing coins collecting
            playerObj.transform.Translate(0, 10, 0);
            if (!timerReached)
            {
                gameOverScreen.SetActive(true);
                timer += Time.deltaTime;
            }

            if (!timerReached && timer > 3.5f)
            {
                gameOverScreen.SetActive(false);
                timerReached = true;
                ResetGame();
                startTimer = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
            startTimer = true;
        }
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        CollectableControl.coinCount = 0;
    }
}
