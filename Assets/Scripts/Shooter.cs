using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject bullet;
	public float attackSpeed = 0.08f;

	private bool canAtk;

	// Use this for initialization
	void Start () {
		canAtk = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AttemptAttack(){
		if (canAtk) {
			Attack ();
		}
	}

	void Attack(){
		Invoke ("EnableAttack", attackSpeed);
		Instantiate (bullet, transform.position, Quaternion.Euler (transform.rotation.eulerAngles));
		canAtk = false;
	}

	void EnableAttack(){
		canAtk = true;
	}
}
