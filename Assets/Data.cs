using UnityEngine;
using System.Collections;

public class Data : MonoBehaviour {

	public static int score;
	public static int kills;

	// Use this for initialization
	void Start () {
		score = 0;
		kills = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		
		#if UNITY_EDITOR
		if(Input.GetKey (KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);		
		}
		#endif
	}

	public static void addKill(){
		kills++;
	}

	public static void addScore(int score){
		Data.score += score;
	}
}
