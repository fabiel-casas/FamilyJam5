using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	private int rotation;
	public int direction = 1;
	public float speed = 0.1f;

	private float newRotationValue;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		newRotationValue = (transform.eulerAngles.x+(speed*direction))%360 * Time.deltaTime;
		transform.Rotate(0f, 0f, newRotationValue);

	}
}
