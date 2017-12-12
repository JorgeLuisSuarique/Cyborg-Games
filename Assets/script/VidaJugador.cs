using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaJugador : MonoBehaviour 
{
	public float vida;
	public float maximaVida;
	public Image barraVida;
	public Transform player;
	public Transform Spawnpoint;
	public GameObject LeanderBoard;

	private void Start ()
	{
		maximaVida = vida;
		ActualizeUI ();
	}
	public void Applyvida (int Ivida)
	{
		vida = vida - Ivida;
		ActualizeUI ();
		if(vida <= 0)
		{
			LeanderBoard.gameObject.SetActive (true);
			/*player.transform.position = Spawnpoint.position;
			vida = maximaVida;*/
		}
	}
	//este metodo te permite regenerar la vida
	public void Applyrecaga (int Rvida)
	{
		vida = vida + Rvida;
		ActualizeUI ();
	}

	/*void OnTriggerEnter(Collider Rvida)
	{
		if (Rvida.CompareTag("Recarga")
		{
			gameObject.SetActive(false);
		}
	}*/
	public void ActualizeUI ()
	{
		barraVida.fillAmount = (vida / maximaVida);
	}
}
