using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float x;
    public float z;
    public float speed;

    private Rigidbody ballRigidbody;
    private Transform ballTransform;

    public GameObject scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0, 2) == 0 ? -1 : 1;
        z = Random.Range(0, 2) == 0 ? -1 : 1;
        speed = 5f;
        ballTransform = GetComponent<Transform>();
        ballRigidbody = GetComponent<Rigidbody>();
        ballRigidbody.velocity = new Vector3(speed * x, 0, speed * z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PaddleLeft" || collision.gameObject.name == "PaddleRight")
        {
            speed += 1f;
            x = Random.Range(0, 2) == 0 ? -1 : 1;
            z = Random.Range(0, 2) == 0 ? -1 : 1;
            ballRigidbody.velocity = new Vector3(speed * x, 0, speed * z);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        ballTransform.position = new Vector3(0, 0.5f, 0);
        speed = 5f;
        if (collider.gameObject.name == "RightGoal")
        {
            //Debug.Log("Left Scored");
            x = -1f;
            z = Random.Range(0, 2) == 0 ? -1 : 1;
            ballRigidbody.velocity = new Vector3(speed * x, 0, speed * z);
            scoreManager.GetComponent<ScoreManager>().Scored(false);
        }
        if (collider.gameObject.name == "LeftGoal")
        {
            //Debug.Log("Right Scored");
            x = 1f;
            z = Random.Range(0, 2) == 0 ? -1 : 1;
            ballRigidbody.velocity = new Vector3(speed * x, 0, speed * z);
            scoreManager.GetComponent<ScoreManager>().Scored(true);
        }
    }
}
