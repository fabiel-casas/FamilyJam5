using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float initialSweetness = 0f;
	private float sweetness;
	public float maxSweetness = 200f;
	public Image sweetnessBar;

	// Use this for initialization
	void Start () {
		sweetness = initialSweetness;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeSweetness(float amount){
		if(sweetness + amount > maxSweetness){
			sweetness = maxSweetness;
			maxSweetnessReached();
		} else if(sweetness + amount < 0){
			sweetness = 0;
		} else {
			sweetness += amount;
		}
		updateSweetnessBar();
	}

	void updateSweetnessBar(){
		if(sweetnessBar != null)
			sweetnessBar.fillAmount = sweetness / maxSweetness;
	}

	void maxSweetnessReached(){
    PlayerPrefs.SetString("middle2", "complete");
    StartCoroutine(WaitAndPrint(2.0F));
		Debug.Log("Made it!!!!!!!!!!!");
  }

  IEnumerator WaitAndPrint(float waitTime) {
    yield return new WaitForSeconds(waitTime);
    Application.LoadLevel(1);
  }

}
