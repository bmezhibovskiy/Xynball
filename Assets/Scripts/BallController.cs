using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public GameObject plunger;
    public float str = 50.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnCollisionEnter(Collision col) { 
        if(col.gameObject == plunger) {
            Vector3 dir = (this.transform.position - col.gameObject.transform.position).normalized;
            Rigidbody rigidbody = this.GetComponent<Rigidbody>();
            rigidbody.AddForce(dir * str * rigidbody.mass, ForceMode.Force);
        }
    }



}
