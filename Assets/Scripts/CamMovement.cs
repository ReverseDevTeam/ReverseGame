using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour {

	public GameObject player;
	private float x;

	void Start () {
		
	}

	void Update () {
		x = player.transform.position.x;
		transform.position = new Vector3(x, -4.71f, -5f);
	}
}
