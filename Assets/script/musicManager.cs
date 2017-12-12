using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour 
{
	public AudioClip menuTheme;
	public AudioClip mainTheme;

	void Start()
	{
		AudioManager.instance.PlayMusic (menuTheme, 2);
	}
	void Update ()
	{
		if (Input.GetKey (KeyCode.Space)) 
		{
			AudioManager.instance.PlayMusic (mainTheme, 3);
		}
	}
}
