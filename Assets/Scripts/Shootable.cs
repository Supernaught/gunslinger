using UnityEngine;
using System.Collections;

public class Shootable : MonoBehaviour {

	int hp = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public virtual void Hit(int damage){
		hp -= damage;

		if (hp <= 0) {
			Die();
		}
	}

	public virtual void Die(){
		Destroy (this.gameObject);
	}
}
