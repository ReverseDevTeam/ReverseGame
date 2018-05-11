using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float rotateSpeed;

	void Update () {
		transform.Rotate (Vector3.back * (rotateSpeed * Time.deltaTime));
	}
}
