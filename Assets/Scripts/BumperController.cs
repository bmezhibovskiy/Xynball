using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController: MonoBehaviour {

    public float strength = 1.0f;
    public Material activeMaterial;
    public ScoreController score;
    private Material mat1;
    
    // Use this for initialization
    void Start() {
        mat1 = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update() {

    }

    void OnCollisionEnter(Collision col) {
        GameObject other = col.gameObject;
        Rigidbody otherRB = other.GetComponent<Rigidbody>();
        if(otherRB != null) {
            Vector3 dir = (other.transform.position - transform.position).normalized;
            otherRB.AddForce(dir * strength, ForceMode.Impulse);

            score.addToScore(1);

            StartCoroutine(ChangeMaterial());
        }
    }

    private IEnumerator ChangeMaterial() {
        GetComponent<MeshRenderer>().material = activeMaterial;

        yield return new WaitForSeconds(0.25f);

        GetComponent<MeshRenderer>().material = mat1;
    }

    private void AddToScore() {

    }

}
