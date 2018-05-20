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
//		loadBar.SetActive (true);
//		StartCoroutine (loadSceneAsync (sceneName));
		Color col;
		ColorUtility.TryParseHtmlString("#e67e22", out col);
		Initiate.Fade(sceneName, col, 1.0f);
	}

//	IEnumerator loadSceneAsync(string sceneName)
//	{
//		AsyncOperation loadScene = SceneManager.LoadSceneAsync (sceneName);
//
//		while (!loadScene.isDone) 
//		{
//			float progress = Mathf.Clamp01 (loadScene.progress / .9f);
//			slider.value = progress;
//			percent.text = Mathf.RoundToInt(progress) * 100f + "%";
////			Initiate.Fade(sceneName, Color.blue, 0.5f);
//			yield return null;
//		}
//	}
}
