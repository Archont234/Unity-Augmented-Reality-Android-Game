using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBehaviour : MonoBehaviour {

    private bool superStarCreated = false;
    private int superStarPlaceRandom;
    public GameObject superStar;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	

        if (AndroidBehaviour.timeRemaining < 15)
        {
            if (!superStarCreated)
            {

                superStarPlaceRandom = Random.Range(1, 3);

                Vector3 superStarposition1 = new Vector3(-0.1f, 0.130f, 0.5f);
                Vector3 superStarposition2 = new Vector3(0.3f, 0.130f, 0.5f);


                if (superStarPlaceRandom == 1)
                {
                    Instantiate(superStar, superStarposition1, Quaternion.identity);
                }
                else if (superStarPlaceRandom == 2)
                {
                    Instantiate(superStar, superStarposition2, Quaternion.identity);
                }

                superStarCreated = true;
            }
        }
    }
}
