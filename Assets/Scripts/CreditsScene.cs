using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScene : MonoBehaviour {

	public float speed;
	private GameObject credit;

	void Start () {
		credit = GameObject.Find ("CreditsTxt");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, speed * Time.deltaTime, 0);
	}

	void OnEnable () {
		transform.position = new Vector2 (360, -250);
	}
}
