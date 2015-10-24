using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	
	public float ROTATE_SPEED = 10;
	Vector3 ROTATOR;
	private float targetRotateSpeed, rotateSpeed;
	PlayerShooter shooter;
	
	// Use this for initialization
	void Start () {
		ROTATOR = new Vector3 (0, 0, 50);
		shooter = GetComponent<PlayerShooter> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Alpha1)) {
			shooter.equipWeapon (WeaponType.Pistol);
		} else if (Input.GetKey (KeyCode.Alpha2)) {
			shooter.equipWeapon (WeaponType.Shotgun);
		} else if (Input.GetKey (KeyCode.Alpha3)) {
			shooter.equipWeapon (WeaponType.MachineGun);
		}
		
		if (Input.GetKey (KeyCode.LeftArrow) && Input.GetKey (KeyCode.RightArrow)) {
			shooter.AttemptAttack ();
			targetRotateSpeed = 0;
		} else if (Input.GetKey (KeyCode.LeftArrow)) {
			AttackLeft ();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			AttackRight();
		} else {
			targetRotateSpeed = 0;
		}

		rotateSpeed = Mathf.Lerp (rotateSpeed, targetRotateSpeed, 12 * Time.deltaTime);
		transform.Rotate (ROTATOR * Time.deltaTime * rotateSpeed);
	}
	
	void AttackLeft(){
		targetRotateSpeed = (Input.GetKey (KeyCode.RightArrow)) ? ROTATE_SPEED / 1 : ROTATE_SPEED;
		//		transform.Rotate (new Vector3 (0, 0, 50 * speed * Time.deltaTime));
		shooter.AttemptAttack ();
	}
	
	void AttackRight(){
		targetRotateSpeed = -1 * ((Input.GetKey (KeyCode.LeftArrow)) ? ROTATE_SPEED / 1 : ROTATE_SPEED);
		//		transform.Rotate (new Vector3 (0, 0, 50 * -speed * Time.deltaTime));
		shooter.AttemptAttack ();
	}
	
	void OnTriggerEnter2D(Collider2D col){
		Die ();
	}
	
	void Die(){
		Destroy (this.gameObject);
	}
}
