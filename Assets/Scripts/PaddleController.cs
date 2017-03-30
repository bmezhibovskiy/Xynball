using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController: MonoBehaviour {

    public bool isRight;
    public float range;
    public SteamVR_TrackedController controller;

    private ConfigurableJoint joint;

    private void triggerDown(object sender, ClickedEventArgs e) {
        joint.targetRotation = Quaternion.AngleAxis(range, transform.up);
    }

    private void triggerUp(object sender, ClickedEventArgs e) {
        joint.targetRotation = Quaternion.AngleAxis(-range, transform.up);
    }

    // Use this for initialization
    void Start() {

        if(isRight) {
            range = -range;
        }

        joint = GetComponent<ConfigurableJoint>();

        joint.targetRotation = Quaternion.AngleAxis(-range, transform.up);

        controller.TriggerClicked += triggerDown;
        controller.TriggerUnclicked += triggerUp;
    }



    // Update is called once per frame
    void Update() {

    }



}
