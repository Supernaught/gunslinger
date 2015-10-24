using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	int score = 100;

	void Start () {
	
	}
	
	void Update () {
			
	}

	void OnDestroy(){
		Data.addKill ();
		Data.addScore (score);
	}
}
