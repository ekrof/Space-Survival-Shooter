using UnityEngine;

using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	private Done_GameController gameController;

	GameObject player;
	Health playerHealth;
//	CapsuleCollider CapsuleCollider;

	void Awake(){
		
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<Health> ();
	}
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log("Cannot find 'GameController' script");
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}
		
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		} 
		
		if (other.tag == "Player")
		{
			playerHealth.TakeDamage(10); 
			Instantiate(explosion, transform.position, transform.rotation);
		//	GetComponent<CapsuleCollider>().enabled = false;

		}Destroy(gameObject); 

	}
	

	}
