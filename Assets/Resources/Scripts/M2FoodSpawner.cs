using UnityEngine;
using System.Collections;

public class M2FoodSpawner : MonoBehaviour {

	public GameObject M2FoodGO;
	public float maxSpawnRateInSeconds = 5f;
	public float minSpawnRateInSeconds = 1f;

	// Use this for initialization
	void Start () {
		Invoke ("SpawnFood", maxSpawnRateInSeconds);

		//Increase spawn rate every 30 seconds
		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}	
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnFood(){
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		GameObject aFood = (GameObject)Instantiate (M2FoodGO);
		aFood.transform.position = new Vector2 (min.x, Random.Range (max.y, min.y));

		//Schedule when to spawn next food
		ScheduleNextFoodSpawn ();
	}

	
	void ScheduleNextFoodSpawn(){
		float spawnInNSeconds;
		
		if(maxSpawnRateInSeconds > minSpawnRateInSeconds){
			// Pick a number between min and max
			spawnInNSeconds = Random.Range (minSpawnRateInSeconds, maxSpawnRateInSeconds);
		} else {
			spawnInNSeconds = minSpawnRateInSeconds;
		}
		
		
		Invoke ("SpawnFood", spawnInNSeconds);
			
	}

	//Increase difficulty
	void IncreaseSpawnRate(){
		if(maxSpawnRateInSeconds > minSpawnRateInSeconds){
			maxSpawnRateInSeconds--;
		}

		if(maxSpawnRateInSeconds == minSpawnRateInSeconds){
			CancelInvoke ("IncreaseSpawnRate");
		}
	}
}
