using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

  public Transform target;
  public float distance = 5;
  public float movementSpeed = 0.1f;

	// Use this for initialization
	void Start () {
    target = GameObject.FindGameObjectWithTag(StaticTags.PlayerTag).GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
    if(target != null) {      
      transform.position = Vector3.Lerp(transform.position, target.position, movementSpeed) + new Vector3(0, 0, -distance);
    }
	}
}
