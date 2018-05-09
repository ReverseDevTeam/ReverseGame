using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushCheck : MonoBehaviour {

	private GameObject player;

	void Start () {
		player = GameObject.FindWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D col){
		//player.GetComponent<PlayerControl> ().TakeDamage ();
		//Debug.Log ("crush");
	}
}
