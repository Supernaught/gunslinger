using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject bullet;
	public float attackSpeed = 0.08f;

	private bool canAtk;

	// Use this for initialization
	public virtual void Start () {
		canAtk = true;
	}
	
	public void AttemptAttack(){
		if (canAtk) {
			Attack ();
		}
	}

	void Attack(){
		Invoke ("EnableAttack", attackSpeed);
		canAtk = false;

		Fire ();
	}

	void EnableAttack(){
		canAtk = true;
	}

	public virtual void Fire(){
		Instantiate (bullet, transform.position + (transform.up * 0.7f), Quaternion.Euler (transform.rotation.eulerAngles));
	}
}
