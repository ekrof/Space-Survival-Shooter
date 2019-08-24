using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	public int startingHealth = 100;            // The amount of health the enemy starts the game with.
	public int currentHealth;                   // The current health the enemy has.
	public int scoreValue = 20;                 // The amount added to the player's score when the enemy dies.
	public GameObject EnemyExplosion;
	public GameObject HitExplosion;


	//powerups
	public GameObject powerup1;
		public GameObject powerup2;
			public GameObject powerup3;


	public Done_GameController GameController;

	
	bool isDead;                                // Whether the enemy is dead.



	void Start ()
	{

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			GameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (GameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}



	void Awake ()
	{
		//gameController = test.GetComponent <Done_GameController> ();
		currentHealth = startingHealth;
		isDead = false;

	}

	void Update(){
	}

	public void EnemyTakeDamage (int amount)
	{
		if (isDead) {
			return;
		}

		currentHealth -= amount;
		if (HitExplosion != null) {
			Instantiate (HitExplosion, transform.position, transform.rotation);
		}


	/*	if (isHit) {

			GetComponentInChildren<Renderer>().material.SetColor ("_EmissionColor", Color.black);
*/


	

		// If the current health is less than or equal to zero...
		if (currentHealth <= 0) {

			Death ();

			GameController.AddScore (scoreValue);
		
	
		} 
			 
	}
				

	void Death()
	{
		isDead = true;
		if (EnemyExplosion != null){
			Instantiate (EnemyExplosion, transform.position, transform.rotation);	

			int roll = Random.Range(0,50);
			
			if (roll == 0){
				Instantiate(powerup1, transform.position, transform.rotation);
			}
			else if (roll < 6){
				Instantiate(powerup2, transform.position, transform.rotation);
			}
			else if (roll < 11){
				Instantiate(powerup3, transform.position, transform.rotation);
			}
		Destroy(gameObject);



	}


}
}
