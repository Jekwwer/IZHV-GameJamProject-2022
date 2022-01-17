using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float aliveTime;
    public float damage;
    public float movementSpeed;

    public GameObject enemyTriggered; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aliveTime -= 1 * Time.deltaTime;

        if (aliveTime<= 0.0f)
        {
            Destroy(this.gameObject);   
        }

        this.transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Obstacle")
        {
            enemyTriggered = other.gameObject;
            enemyTriggered.GetComponent<Obstacle>().health -= damage;
            Destroy(this.gameObject);
        }

    }
}
