using UnityEngine;

public class GhostBehaviour : MonoBehaviour {

	float[] MovementDirections = new float[2];


	System.Random random;
	float GhostMovement_X;
	float GhostMovement_Z;



	// Use this for initialization
	void Start () {

		if (LevelSelect.Level == "Easy" || LevelSelect.Level == "Medium")
			this.gameObject.SetActive(false);


		MovementDirections[0] = -0.005f;
		MovementDirections[1] = 0.005f;

		random = new System.Random();

		GhostMovement_X = MovementDirections[random.Next(0, MovementDirections.Length)];
		GhostMovement_Z = MovementDirections[random.Next(0, MovementDirections.Length)];
	}

	// Update is called once per frame

	void Update () {

		if(AndroidBehaviour.timeRemaining == 0)
			this.gameObject.SetActive(false);


		transform.Rotate(new Vector3(0, 75, 0) * Time.deltaTime);

			if (AndroidBehaviour.timerIsRunning)
		{

			transform.position = new Vector3(
			transform.position.x + GhostMovement_X,
			transform.position.y,
			transform.position.z + GhostMovement_Z);

		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "WallEast" || collision.gameObject.tag == "WallWest")
		{
			GhostMovement_X *= -1;
		}


		if (collision.gameObject.tag == "WallSouth" || collision.gameObject.tag == "WallNorth")
		{
			GhostMovement_Z *= -1;
		}
	}
}
