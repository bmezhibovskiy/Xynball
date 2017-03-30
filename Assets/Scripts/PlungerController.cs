using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlungerController: MonoBehaviour {

    public float strength = 5.0f;
    public float noise = 1.0f;

    public SteamVR_TrackedController leftController;
    public SteamVR_TrackedController rightController;

    private Collision prevCollision = null;

    // Use this for initialization
    void Start() {

        leftController.PadClicked += padDown;
        rightController.PadClicked += padDown;

    }

    // Update is called once per frame
    void Update() {

    }

    private void padDown(object sender, ClickedEventArgs e) {
        hit();
    }

    void OnCollisionEnter(Collision col) {
        prevCollision = col;        

    }

    void OnCollisionExit(Collision col) {
        prevCollision = null;
    }

    void hit() {
        if(prevCollision != null) {
            Vector3 dir = transform.up;
            Rigidbody rigidbody = prevCollision.gameObject.GetComponent<Rigidbody>();
            float randomNoise = Random.Range(-noise, noise);
            rigidbody.AddForce(dir * (strength + randomNoise) * rigidbody.mass, ForceMode.Impulse);
        }
    }
}
