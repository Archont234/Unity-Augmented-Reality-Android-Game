using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeParticles : MonoBehaviour {

    private Rigidbody particleRigidbody;
    // Use this for initialization
    void Start()
    {
        particleRigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            particleRigidbody.useGravity = false;
            particleRigidbody.detectCollisions = false;
            particleRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            Invoke("Destroy", 2);
        }

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
