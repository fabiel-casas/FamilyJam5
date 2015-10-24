using UnityEngine;
using System.Collections;

public class M2PlayerControl : MonoBehaviour {

	public float playerWidth;
	public float playerHeight;
	public float speed;

	private float x;
	private float y;
	private Vector2 direction;
	private Vector2 min;
	private Vector2 max;
	private Vector2 position;

	// Use this for initialization
	void Start () {
		playerWidth = this.gameObject.renderer.bounds.size.x/100;
		playerHeight = this.gameObject.renderer.bounds.size.y/100;

		Debug.Log("X: " + this.gameObject.renderer.bounds.size.x);
		Debug.Log("Y: " + this.gameObject.renderer.bounds.size.y);
	}
	
	// Update is called once per frame
	void Update () {
		float tempX = x;
		float tempY = y;
		x = Input.GetAxisRaw ("Horizontal"); // -1 Left, 0 Still, 1 Right 
		y = Input.GetAxisRaw ("Vertical"); // -1 Down, 0 Still, 1 Up 

		//Debug.Log("X: " + tempX + " newX: " + x + " Y: " + tempY + " newY: " + y);

		direction = new Vector2(x, y).normalized; //Get direction vector

		Move(direction); //Set player position
	}


	public void Move (Vector2 direction){
		//Find limits
		min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0)); //Find screen limits
		max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1)); //Find screen limits

		//Set the center of the character X
		max.x = max.x - playerWidth/2;
		min.x = min.x + playerWidth/2;

		//Set the center of the character Y
		min.y = min.y + playerHeight/2;
		min.y = min.y + playerHeight/2;

		//Get current position
		position = transform.position;

		// Move to new position
		position += direction * speed * Time.deltaTime;

		// Restrict player position inside screen
		position.x = Mathf.Clamp(position.x, min.x, max.x);
		position.y = Mathf.Clamp(position.y, min.y, max.y);

		//Update player position
		transform.position = position;

	}
}
