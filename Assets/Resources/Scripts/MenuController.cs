using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
  
  public GameObject middle_complete1;
  public GameObject middle_complete2;
  public GameObject image_complete;

  // Use this for initialization
  void Start () {
  }
	
	// Update is called once per frame
	void Update () {
    string middle1 = PlayerPrefs.GetString("middle1");
    string middle2 = PlayerPrefs.GetString("middle2");
    if(middle1.Equals("complete") && middle2.Equals("complete")) {
      image_complete.SetActive(true);
    }else {
      if(middle1.Equals("complete")) {
        middle_complete1.SetActive(true);
      }
      if(middle2.Equals("complete")) {
        middle_complete2.SetActive(true);
      }
    }
    if(Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.A)) {
      Application.LoadLevel(2);
    }
    if(Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.B)) {
      Application.LoadLevel(3);
    }
  }
}
