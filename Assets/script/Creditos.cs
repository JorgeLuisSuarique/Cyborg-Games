using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Creditos : MonoBehaviour 
{
	public void CreditosScene (string nombreScene)
	{
		SceneManager.LoadScene (nombreScene);
	}
}
