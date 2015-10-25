using UnityEngine;
using System.Collections;

public class M2FoodSpawner : MonoBehaviour {

	private string prefabsPath = "Prefabs/M2";
	private int unitsPerPixel = 100;
	public GameObject M2FoodGO;
	public float maxSpawnRateInSeconds = 5f;
	public float minSpawnRateInSeconds = 0.1f;
	public int pepperChance = 20;
	public int cakeChance = 10;
	public int healthyChance = 70;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnFood", maxSpawnRateInSeconds);

		//Increase spawn rate every 30 seconds
		InvokeRepeating ("IncreaseSpawnRate", 0f, 3f);
	}	
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnFood(){

		GameObject aFood;
		int randomValue = Random.Range(1, 100);
		
		if(randomValue < pepperChance){ //Chance to spawn Pepper
			aFood = (GameObject)Instantiate (Resources.Load(prefabsPath + "/Pepper"));
		} else if(randomValue < pepperChance + cakeChance){ //Chance to spawn Cake
			aFood = (GameObject)Instantiate (Resources.Load(prefabsPath + "/Cake"));
		} else { // if(randomValue < cakeChance){ //Chance to spawn Healthy food
			int randomVegetable = Random.Range(1, 4);
			Debug.Log(randomVegetable);
			switch(randomVegetable){
			case 1:
				aFood = (GameObject)Instantiate (Resources.Load(prefabsPath + "/Tomato"));
				break;
			case 2:
				aFood = (GameObject)Instantiate (Resources.Load(prefabsPath + "/Carrot"));
				break;
			case 3:
				aFood = (GameObject)Instantiate (Resources.Load(prefabsPath + "/Radish"));
				break;
			default:
				aFood = (GameObject)Instantiate (Resources.Load(prefabsPath + "/Radish"));
				break;
			}
		}

		aFood.transform.localScale = new Vector2(2, 2);
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		Vector2 mid = new Vector2(0, aFood.GetComponent<Renderer>().bounds.size.y/2);
		min = min + mid;
		max = max - mid;

		aFood.transform.position = new Vector2 (min.x, Random.Range (max.y, min.y));

		float rotationAngle = Random.Range(0, 360);
		aFood.transform.Rotate(0f, 0f, rotationAngle);

		//Schedule when to spawn next food
		ScheduleNextFoodSpawn ();
	}

	
	void ScheduleNextFoodSpawn(){
		float spawnInNSeconds;
		
		if(maxSpawnRateInSeconds > minSpawnRateInSeconds){
			// Pick a number between min and max
			spawnInNSeconds = Random.Range(minSpawnRateInSeconds, maxSpawnRateInSeconds);
		} else {
			spawnInNSeconds = minSpawnRateInSeconds;
		}
		
		
		Invoke ("SpawnFood", spawnInNSeconds);
			
	}

	//Increase difficulty
	void IncreaseSpawnRate(){
		if(maxSpawnRateInSeconds > minSpawnRateInSeconds){
			maxSpawnRateInSeconds = maxSpawnRateInSeconds - 0.2f;
		}

		if(maxSpawnRateInSeconds == minSpawnRateInSeconds){
			CancelInvoke ("IncreaseSpawnRate");
		}
	}
}
