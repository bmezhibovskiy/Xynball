using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController: MonoBehaviour {

    public ScoreController score;
    private GameObject currentBall;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if(currentBall != null) {
            float currentScore = score.getScore();
            if(currentBall.transform.position.y > -0.15f) {
                float potentialScore = currentBall.transform.position.z;
                if(currentScore < potentialScore) {
                    score.addToScore(potentialScore - currentScore);
                }
            }
        }
    }

    void OnCollisionEnter(Collision col) {
        if(col.gameObject.tag == "Ball") {
            currentBall = col.gameObject;
        }

    }
}
