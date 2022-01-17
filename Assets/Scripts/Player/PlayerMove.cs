using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float leftRightMovementSpeed = 4.0f;
    public float zPos;
    private float acceleratedTimes = 0;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zPos = this.transform.position.z - acceleratedTimes * 25.0f;

        // Constant straight moving
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.World);

        // Left/Right moving contlols
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightMovementSpeed);
            }
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightMovementSpeed);
            }
        }

        if ((this.transform.position.z - (acceleratedTimes * 25.0f)) > 25.0f)
        {
            StartCoroutine(Accelerate());
            acceleratedTimes++;
        }
    }
    IEnumerator Accelerate()
    {
        if (movementSpeed <= 15.0f)
        {
            animator.speed *= 1.02f;
            movementSpeed *= 1.1f;
            leftRightMovementSpeed *= 1.05f;
        }
    yield return new WaitForSeconds(0.1f);
    }
}