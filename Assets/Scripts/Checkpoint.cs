using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {


	void Start () {
		
	}
		
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			col.GetComponent<PlayerControl> ().SetCheckpoint (true);
			Destroy (gameObject);
		}
	}
}
