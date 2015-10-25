using UnityEngine;
using System.Collections;

public class GiftController : MonoBehaviour {

  public AudioClip soundGift;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider collider) {
    if(collider.tag.Equals(StaticTags.PlayerTag)) {
      LevelController.CountGift();
      if(null != soundGift) {
        AudioSource.PlayClipAtPoint(soundGift, transform.position);
      }
      Destroy(gameObject);
    }
  }

}
