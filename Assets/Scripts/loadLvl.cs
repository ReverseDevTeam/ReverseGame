using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadLvl : MonoBehaviour {

	public Text percent;
	public Slider slider;
	public GameObject loadBar;

	void Start () {

	}

	void Update () {
		
	}

	public void loadScene(string sceneName)
	{
		loadBar.SetActive (true);
		StartCoroutine (loadSceneAsync (sceneName));
	}

	IEnumerator loadSceneAsync(string sceneName)
	{
		AsyncOperation loadScene = SceneManager.LoadSceneAsync (sceneName);

		while (!loadScene.isDone) 
		{
			float progress = Mathf.Clamp01 (loadScene.progress / .9f);
			slider.value = progress;
			percent.text = progress * 100f + "%";
			yield return null;
		}
	}
}
