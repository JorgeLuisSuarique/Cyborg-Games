using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ControlJuego : MonoBehaviour 
{
	public Text CounterText;
	public float punto;
	public Text puntuacion;
	int Punto = 0;
	//int timePuntuacion = 10;
	bool gameInPlay = true;
	public InputField NombreJugador;
	public void sumarPunto (float go)
	{
		if (Movimiento.termino == false) 
		{
			punto = Mathf.Round (punto + go);
			punto = Mathf.Abs (punto);
			puntuacion.text = punto.ToString ();
		}
		/*if (Time.deltaTime)
		{
			
		}*/
	}
	void EndGame()
	{
		gameInPlay = false;
	}
	public void Iniciales ()
	{
		GetComponent<LeanderBoard> ().CheckForScore (Punto, NombreJugador.text);
	}
	void Update () 
	{
		if (!gameInPlay)
		{
			return;
		}
	}


}
