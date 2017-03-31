using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour {

    public string scene;
    public Image indicator;
    private Color originalColor;
	// Use this for initialization
	void Start () {
        originalColor = indicator.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void highlight() {
        indicator.color = Color.Lerp(originalColor, Color.red, 0.5f);
    }

    public void unhighlight() {
         indicator.color = originalColor;
    }

    public void go() {
        SceneManager.LoadScene(scene);
    }
}
