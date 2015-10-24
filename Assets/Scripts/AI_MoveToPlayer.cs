using UnityEngine;
using System.Collections;

public class AI_MoveToPlayer : MonoBehaviour {
	GameObject player;
	Rigidbody2D rb;
	bool moveToPlayer;
	float rotateSpeed;
	public float moveSpeed;

	void Start () {
		moveToPlayer = true;
		rb = GetComponent<Rigidbody2D>();
		player = GameObject.Find ("Player");

		rotateSpeed = Random.Range (1, 10);
		moveSpeed = Random.Range (4f, 7f);
	}
	
	void Update () {
		if(player && moveToPlayer){
			RotateToTarget(player.transform.position);
			rb.velocity = transform.right * moveSpeed;
		}
	}

	void RotateToTarget(Vector3 target){
		Vector3 dir = target - transform.position; 
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
	}
}