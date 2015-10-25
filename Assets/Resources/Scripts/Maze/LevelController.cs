using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {

  public Text countGift;
  public Text textMessage;
  public Text countDown;
  public int totalTime = 600;

  private static int gift_count = 0;
  private static int number_gift = 0;
  private bool endGame = false;

	// Use this for initialization
	void Start () {
    gift_count = 0;
    GiftController[] gifList = FindObjectsOfType<GiftController>();
    number_gift = gifList.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
    countGift.text = "Gift: " + gift_count + "/" + number_gift;
    CountDown();
	}

  public static void CountGift() {
    gift_count++;
  }

  public void LevelIsFinish() {
    if(number_gift <= gift_count) {
      textMessage.text = "Has completado el nivel";
      endGame = true;
      Time.timeScale = 0;
    }
  }

  private void CountDown() {
    if(endGame) {
      return;
    }
    float time = Time.time;
    float restTime = totalTime - time;
    int minutes = (int)restTime / 60;
    int seconds = (int)restTime % 60;
    countDown.text = zeroLeft(minutes) + ":" + zeroLeft(seconds);
    if(restTime <= 0) {
      endGame = true;
    }
    if(restTime <= 60) {
      countDown.color = Color.red;
    }
  }

  private string zeroLeft(int value) {
    if(value < 10) {
      return "0" + value;
    }
    return ""+value;
  }
}
