using UnityEngine;
using System.Collections;

public enum Type{
	Carrot,Tomato,Pepper,Cake,Radish
}

public class M2FoodController : MonoBehaviour {

	public float speed = 2f;
	public Type type = Type.Cake;
	

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//Get bullet position
		Vector2 position = transform.position;

		//compute the food's new position
		position = new Vector2(position.x - speed * Time.deltaTime, position.y);

		//update the food's position
		transform.position = position;

		//this is the bottom-left point 
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//If food left the corner, destroy it
		if(transform.position.x < min.x){
			Destroy (gameObject);
		}

	}
}
