using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float movespeed;
	public int damage = 1;

	// Use this for initialization
	void Start () {
		Destroy (this, 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * movespeed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D col){
		Shootable shootable = col.gameObject.GetComponent<Shootable> ();
		if (shootable) {
			shootable.Hit(damage);
			Die ();
		}
	}

	public virtual void Die(){
		Destroy (this.gameObject);
	}
}
