using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float rotateSpeed;
	private Shooter shooter;

	// Use this for initialization
	void Start () {
		shooter = GetComponent<Shooter> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey (KeyCode.RightArrow)){
			shooter.AttemptAttack();
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			AttackLeft ();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			AttackRight();
		}
	}

	void AttackLeft(){
		transform.Rotate (new Vector3 (0, 0, 50 * rotateSpeed * Time.deltaTime));
		shooter.AttemptAttack ();
	}

	void AttackRight(){
		transform.Rotate (new Vector3 (0, 0, 50 * -rotateSpeed * Time.deltaTime));
		shooter.AttemptAttack ();
	}
}
