using UnityEngine;
using System.Collections;

public class GiftController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider collider) {
    if(collider.tag.Equals(StaticTags.PlayerTag)) {
      LevelController.CountGift();
      Destroy(gameObject);
    }
  }

}
