using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioControl : MonoBehaviour {

    private AudioSource source;
    public List<AudioClip> audioClipList;

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playSound(string soundName)
    {
        foreach(AudioClip clip in audioClipList)
        {
            if(clip.name == soundName)
            {
                source.clip = clip;
                source.Play();
            }
        }
    }
}
