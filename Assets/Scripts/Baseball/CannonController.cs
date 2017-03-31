using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

    public GameObject ballTemplate;
    public float strength = 100f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.frameCount % 200 == 0) {
            GameObject ball = Instantiate(ballTemplate);
            Rigidbody ballRB = ball.GetComponent<Rigidbody>();
            ball.transform.position = transform.position;
            ballRB.AddForce(transform.forward * strength, ForceMode.Impulse);
            Destroy(ball, 20f);
        }
	}
}
