using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float movespeed;

	// Use this for initialization
	void Start () {
		Destroy (this, 5);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.up * movespeed * Time.deltaTime;
	}
}
