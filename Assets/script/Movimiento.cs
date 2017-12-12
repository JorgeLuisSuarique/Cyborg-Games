using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimiento : MonoBehaviour 
{
	// estas son las varibles del personaje.
	public int speed;
	public GameObject Ganar;
	public VidaJugador vida;
	public ControlJuego puntaje;
	static Animator anim;
	public Rigidbody player;
	public BoxCollider ignorar;
	public Transform Spawnpoint;
	public Transform Nivel2;
	public Transform Nivel3;
	public float tiempoEspera;
	public float tiepoInvul;
	public bool isInvul;
	public float t;
	public static bool termino = false;
	void Start ()
	{
		// con el Animator me permite utilisar las animaciones.
		anim = GetComponent<Animator> ();
		isInvul = false;
	}
	void Update ()
	{
		//esto me permite hacer que el personaje no se mueva por tiempo limitado.
		if (tiempoEspera > 0) {
			tiempoEspera -= Time.deltaTime;
		}
		else 
		{
			// esta funcion me permite que el personaje corra por si solo sin nesesidad de esta oprimiendo una tecla.
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		//este Input puede activar la animcio de saltar.
		if (Input.GetButtonDown ("Jump")) 
		{
			anim.SetTrigger ("Saltar");
			t= 0;
		}
		//este Input puede activar la animcio deslisarse en el suelo.
		if (Input.GetButtonDown("Vertical"))
		{
			anim.SetTrigger ("Bajar");
			t = 0;
		}
		//normal mente sale un prombla con el personaje y es cuando utiliso el MesCollider se que da statico y puede chocar con los obtaculo haciendo inutil las ainmaciones
		//pero gacia a esta funcion el MesCollider se puede ponerse en IsKinematic (que te permite dasactivarel collider y no caer el vacio) temporal mente.
		if (t < tiepoInvul) {
			t += Time.deltaTime;
			player.isKinematic = true;
			ignorar.enabled = false;
		} 
		else 
		{
			player.isKinematic = false;
			ignorar.enabled = true;
		}
		//con esta funcion hare que el puntaje se mescle con el movimiento del personage cuando corre.
		puntaje.sumarPunto (transform.position.x);
	}
	void OnCollisionEnter (Collision Other)
	{
		
		if (Other.collider.CompareTag("Obstaculos")) 
		{
			transform.position = Spawnpoint.position;
			Debug.Log ("regreso al incio");
		}
		if (Other.collider.CompareTag ("Nivel 2")) 
		{
			transform.position = Nivel2.position;
			Debug.Log ("e llegado al nivel 2");
		}
		if (Other.collider.CompareTag ("Nivel 3")) 
		{
			transform.position = Nivel3.position;
			Debug.Log ("e llegado al nivel 3");
		}

	}

	void Bajar()
	{
		if (Input.GetMouseButtonDown (0)) 
		{
			t = 0;
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Cierras"))
		{
			print ("Entra");
			vida.Applyvida (100);
		}
		if (other.CompareTag ("Recarga")) 
		{
			vida.Applyrecaga (150);
		}
		if (other.CompareTag ("Ganar")) 
		{
			Ganar.gameObject.SetActive (true);
			termino = true;
		}
	}
}
