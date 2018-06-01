using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGameMulti : MonoBehaviour
{

	public GameObject nm;
	// Use this for initialization
	void Start () {
		nm = GameObject.Find("NetworkManager");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Destroy(nm);
			SceneManager.LoadScene("main_menu");
		}
	}
}
