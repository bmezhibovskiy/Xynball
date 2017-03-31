using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    public SteamVR_TrackedController controller;
    public LineRenderer lineRenderer;

    private LevelSelectorController currentSelector = null;

    private float range = 100f;

	// Use this for initialization
	void Start () {
        controller.TriggerClicked += triggerDown;
    }
	
	// Update is called once per frame
	void Update () {              

        RaycastHit hitInfo;
        if(Physics.Raycast(transform.position, transform.forward, out hitInfo)) {
            if(currentSelector != null) {
                currentSelector.unhighlight();
                currentSelector = null;
                range = 100f;
            }
            currentSelector = hitInfo.collider.gameObject.GetComponent<LevelSelectorController>();
            if(currentSelector != null) {
                range = hitInfo.distance;
                currentSelector.highlight();
            }     
        }
        else {
            currentSelector.unhighlight();
            currentSelector = null;
            range = 100f;
        }

        lineRenderer.SetPosition(lineRenderer.numPositions - 1, Vector3.forward * range);


    }

    void triggerDown(object sender, ClickedEventArgs e) {
        if(currentSelector != null) {
            currentSelector.go();
        }
    }
}
