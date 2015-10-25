using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
    PlayerPrefs.SetString("middle1", "incomplete");
    PlayerPrefs.SetString("middle2", "incomplete");
  }
	
	// Update is called once per frame
	void Update () {
    if(Input.anyKey) {
      Application.LoadLevel(1);
    }
	}
}
