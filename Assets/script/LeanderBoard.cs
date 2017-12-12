using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.IO;

public class LeanderBoard : MonoBehaviour 
{
	public Text[] Score;
	int [] ScoreValues;
	string [] ScoreNames;
	// Use this for initialization
	void Start () 
	{
		ScoreValues = new int[Score.Length];
		ScoreNames = new string[Score.Length];
		for (int x = 0; x < Score.Length; x++)
		{
			ScoreValues [x] = PlayerPrefs.GetInt ("ScoreValues" + x);
			ScoreNames [x] = PlayerPrefs.GetString ("ScoreNames" + x);
		}
		DrawScore ();
	}
	void ScoreSave ()
	{
		for (int x = 0; x < Score.Length; x++)
		{
			PlayerPrefs.SetInt ("ScoreValues" + x,ScoreValues [x]);
			PlayerPrefs.SetString ("ScoreNames" + x,ScoreNames [x]);
		}
	}
	public void CheckForScore (int _value, string _nombre)
	{
		for (int x = 0; x < Score.Length; x++) 
		{
			if (_value > ScoreValues [x])
			{
				for(int y = Score.Length - 1; y > x; y--)
				{
					ScoreValues [y] = ScoreValues [y - 1];
					ScoreNames [y] = ScoreNames [y - 1];
				}
				ScoreValues [x] = _value;
				ScoreNames [x] = _nombre;
				DrawScore ();
				ScoreSave ();
				break;
			}
		}
	}
	void DrawScore()
	{
		for (int x = 0; x < Score.Length; x++)
		{
			Score [x].text = ScoreNames[x] + ":" + ScoreValues [x].ToString ();
		}
	}
	// Update is called once per frame
	void Update () 
	{
		
	}
}
