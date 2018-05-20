using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadsGameHandler : MonoBehaviour
{
	public List<GameObject> heads;
	private float tSinceLastScare;
	public GameObject dedScreen;

	public int currScaredHeads;
	
	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 1;
		heads = GameObject.FindGameObjectsWithTag("head").ToList();
		currScaredHeads = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		tSinceLastScare += Time.deltaTime;
		if (tSinceLastScare >= 1)
		{
			tSinceLastScare = 0;
			heads[Random.Range(0, 7)].GetComponent<headScript>().setScared(true);
		}

		if (currScaredHeads == heads.Count)
		{
			dedScreen.SetActive(true);
			Time.timeScale = 0;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("main_menu");
		}
	}
}
