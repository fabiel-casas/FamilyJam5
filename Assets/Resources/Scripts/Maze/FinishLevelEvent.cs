using UnityEngine;
using System.Collections;

public class FinishLevelEvent: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider collider) {
    if(collider.tag.Equals(StaticTags.PlayerTag)) {
      LevelController levelController = GameObject.FindGameObjectWithTag(StaticTags.MainCameraTag).GetComponent<LevelController>();
      levelController.LevelIsFinish();
      //TODO load next level
      Time.timeScale = 0;
    }
  }
}
