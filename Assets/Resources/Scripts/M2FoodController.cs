using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Type{
	Carrot,Tomato,Pepper,Cake,Radish
}


public class M2FoodController : MonoBehaviour {

	private int unitsPerPixel = 100;
	public float speed = 2f;
	public Type type = Type.Cake;
	public Image image;
	private Sprite newSprite;
	private string spritesPath = "Sprites";
	private Vector2 position;
	private Vector2 min;
	private SpriteRenderer spriteRenderer;
	private LevelManager levelManager;
	public AudioClip eatenFoodSound;

	public M2FoodController(Type newType){
		type = newType;
	}
	
	// Use this for initialization
	void Start () {
		levelManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LevelManager>();
		switch(type){
			case Type.Cake:
				speed = 5;
				break;
			case Type.Tomato:
				speed = 4;
				break;
			case Type.Radish:
				speed = 2;
				break;
			case Type.Carrot:
				speed = 6;
				break;
			case Type.Pepper:
				speed = 7;
				break;
			default:
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Get bullet position
		position = transform.position;

		//compute the food's new position
		position = new Vector2(position.x - speed * Time.deltaTime, position.y);

		//update the food's position
		transform.position = position;

		//this is the bottom-left point 
		min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		//If food left the corner, destroy it
		if(transform.position.x < min.x){
			Destroy (gameObject);
		}

	}

	/*
	void onTriggerEnter2D(Collider2D collision){
		Debug.Log("Col2");
		//Detect collision of the player with a healthy food item
		if((collision.tag == "Player")){
			Destroy(gameObject);
		}
	}*/



	void OnTriggerEnter2D(Collider2D collision){
		if (collision.gameObject.tag == "Player"){
			Destroy(gameObject);
			if((tag == "Healthy Food")){
				levelManager.changeSweetness(-5f);
			} else if ((tag == "Spicy Food")){
				levelManager.changeSweetness(-15f);
			} else if ((tag == "Sweet Food")){
				levelManager.changeSweetness(+10f);
			}
			if(null != eatenFoodSound) {
				AudioSource.PlayClipAtPoint(eatenFoodSound, transform.position);
			}
		}
	}   

}
