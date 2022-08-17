using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallMove : MonoBehaviour {

	float[] MovementDirections = new float[2];

	private Rigidbody BallRigidbody;

	System.Random random;
	float BallMovement_X;
	float BallMovement_Z;

	// Use this for initialization
	void Start () {
		//gameObject.GetComponent<Renderer>().material.color = Color.red;
		BallRigidbody = this.GetComponent<Rigidbody>();

		MovementDirections[0] = -0.005f;
		MovementDirections[1] = 0.005f;

		random = new System.Random();

		BallMovement_X = MovementDirections[random.Next(0, MovementDirections.Length)];
		BallMovement_Z = MovementDirections[random.Next(0, MovementDirections.Length)];
	}
	
	// Update is called once per frame
	void Update () {

		if(AndroidBehaviour.timerIsRunning)
        {
			transform.position = new Vector3(
			transform.position.x + BallMovement_X,
			transform.position.y,
			transform.position.z + BallMovement_Z);
		}
		
		if(AndroidBehaviour.timeRemaining == 0)
        {
			this.gameObject.SetActive(false);
		}
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "WallEast" || collision.gameObject.tag == "WallWest")
        {
			BallMovement_X *= -1; 
		}


		if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "WallSouth" || collision.gameObject.tag == "WallNorth")
		{
			BallMovement_Z *= -1;
		}

		if (collision.gameObject.tag == "EnemyBall")
		{
			BallMovement_X *= -1;
			BallMovement_Z *= -1;
		}
	}
}
