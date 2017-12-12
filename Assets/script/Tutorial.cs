using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Tutorial : MonoBehaviour 
{
	public void tutorialScene (string nombreScene)
	{
		SceneManager.LoadScene (nombreScene);
	}
}
