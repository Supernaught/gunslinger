using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	bool spawning;
	Vector3 limitMin, limitMax;

	public GameObject[] enemy;
	public float spawnDelayMin, spawnDelayMax;

	void Start () {
		spawning = true;

		limitMin = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, Camera.main.transform.position.y));
		limitMax = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.y));
	
		Spawn ();
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Spawn ();
		}
	}

	void Spawn(){
		float x, y;

		if (Random.Range (0, 2) == 1) {
			x = Random.Range (limitMin.x, limitMax.x);

			if(Random.Range (0,2) == 1){
				y = limitMin.y;
			} else {
				y = limitMax.y;
			}
		} else {
			y = Random.Range (limitMin.y, limitMax.y);

			if(Random.Range (0,2) == 1){
				x = limitMin.x;	
			} else {
				x = limitMax.x;
			}
		}


		Instantiate (enemy [0], new Vector3 (x * 1.2f, y * 1.2f, 0), Quaternion.identity);	

		if (spawning) {
			Invoke ("Spawn", Random.Range (spawnDelayMin, spawnDelayMax));
		}
	}
}
