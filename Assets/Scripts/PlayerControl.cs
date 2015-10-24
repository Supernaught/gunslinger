using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public float rotateSpeed = 10;
	Shooter shooter;

	// Use this for initialization
	void Start () {
		shooter = GetComponent<Shooter> ();
	}
	
	// Update is called once per frame
	void Update () {
//		if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey (KeyCode.RightArrow)){
//			shooter.AttemptAttack();
		 if (Input.GetKey (KeyCode.LeftArrow)) {
			AttackLeft ();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			AttackRight();
		}
	}

	void AttackLeft(){
		float speed = (Input.GetKey (KeyCode.RightArrow)) ? rotateSpeed / 4 : rotateSpeed;
		transform.Rotate (new Vector3 (0, 0, 50 * speed * Time.deltaTime));
		shooter.AttemptAttack ();
	}

	void AttackRight(){
		float speed = (Input.GetKey (KeyCode.LeftArrow)) ? rotateSpeed / 4 : rotateSpeed;
		transform.Rotate (new Vector3 (0, 0, 50 * -speed * Time.deltaTime));
		shooter.AttemptAttack ();
	}

	void OnTriggerEnter2D(Collider2D col){
		Die ();
	}

	void Die(){
		Destroy (this.gameObject);
	}
}
