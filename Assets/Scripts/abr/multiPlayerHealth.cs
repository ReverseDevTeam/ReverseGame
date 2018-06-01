using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multiPlayerHealth : MonoBehaviour {

	public const int maxHealth = 3;
	public int currentHealth = maxHealth;

	public void TakeDamage(int amount)
	{
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
			/*Destroy(gameObject);
			gameObject.GetComponent<PlayerControlNetwork> ().TargetEnableDedCam ();*/
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
