using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour {

	public string scene;
	public float speed;
	public GameObject story;

	void Update () {
		story.transform.Translate (0, speed * Time.deltaTime, 0);
		if (story.transform.position.y >= 920 || Input.GetKeyDown(KeyCode.Escape))
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
	}
}
