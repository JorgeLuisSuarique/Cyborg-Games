using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class menuManager : MonoBehaviour 
{
	public GameObject menuOpcion;
	public GameObject menu;
	public Slider[] volumenSliders;

	void Start () 
	{
		volumenSliders [0].value = AudioManager.instance.Volumen;
		volumenSliders [2].value = AudioManager.instance.Music;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargarScene (string nombreScene)
	{
		SceneManager.LoadScene (nombreScene);
	}
	public void Creditos (string nombreScene)
	{
		SceneManager.LoadScene (nombreScene);
	}
	public void Salir ()
	{
		Application.Quit ();
	}
	public void MenuOpcion ()
	{
		menu.SetActive (false);
		menuOpcion.SetActive (true);
	}
	public void Menu ()
	{
		menu.SetActive (true);
		menuOpcion.SetActive (false);
	}

	public void SetMuteVol (bool i)
	{
	}
	public void SetMuteMus (bool iterMute)
	{
		
	}
	public void Setvolumen (float value)
	{
		//AudioManager.instance.Setvolumen (value, AudioManager.AudioChannel.volumen);
	}
	public void Setmusica (float value)
	{
		//AudioManager.instance.Setvolumen (value, AudioManager.AudioChannel.musica);
	}
}
