using UnityEngine;

using System.Collections;

public class HitEnemy : MonoBehaviour
{
	private Done_GameController gameController;
	
	GameObject player;
	Health playerHealth;
	CapsuleCollider CapsuleCollider;
	public int damagevalue = 10;


	void Awake(){
	
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			playerHealth = player.GetComponent<Health> ();
		}
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
		if (other.tag == "Boundary") //|| other.tag == "Enemy")
		{
			return;
		}

		if (other.tag == "Player")
		{
			playerHealth.TakeDamage(damagevalue); 
			//	GetComponent<CapsuleCollider>().enabled = false;
			
		}
		
	}
		}
	
