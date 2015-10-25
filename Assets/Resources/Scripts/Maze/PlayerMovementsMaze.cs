using UnityEngine;
using System.Collections;

public class PlayerMovementsMaze : MonoBehaviour {

  #region PUBLIC_VARIABLES
  public float speed = 5;
  #endregion

  #region PPROTECTED_VARIABLES
  protected Rigidbody mRigidBody;
  #endregion

  // Use this for initialization
  void Start () {
    if(mRigidBody == null) {
      mRigidBody = GetComponent<Rigidbody>();
    }
	}
	
	// Update is called once per frame
	void Update () {
    float horizontal = Input.GetAxis("Horizontal");    float vertical = Input.GetAxis("Vertical");
    Vector3 direction = new Vector3(horizontal, vertical, 0);
    mRigidBody.AddRelativeForce(direction * speed);
  }
}
