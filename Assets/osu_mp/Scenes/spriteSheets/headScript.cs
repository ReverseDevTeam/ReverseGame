using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headScript : MonoBehaviour
{

	private Animator anim;
	private AudioSource audSrc;
	private GameObject gh;

	private audioControl audCtl;
	// Use this for initialization
	void Start ()
	{
		gh = GameObject.Find("GameHandler");
		anim = this.GetComponent<Animator>();
		anim.SetBool("isScared", false);

		audSrc = this.GetComponent<AudioSource>();
		audCtl = gh.GetComponent<audioControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setScared(bool x)
	{
		if (x)
		{
			if (anim.GetBool("isScared") == false)
			{
				if (Random.Range(0f, 1f) >= .5f)
				{
					audCtl.playSound("manScream");
				}
				else
				{
					audCtl.playSound("womanScream");
				}
				gh.GetComponent<HeadsGameHandler>().currScaredHeads++;
			}
			anim.SetBool("isScared", true);
		}
		else
		{
			if (anim.GetBool("isScared"))
			{
				gh.GetComponent<HeadsGameHandler>().currScaredHeads--;
				anim.SetBool("isScared", false);
			}
				
		}

	}

	public bool getScared()
	{
		return anim.GetBool("isScared");
	}
}
