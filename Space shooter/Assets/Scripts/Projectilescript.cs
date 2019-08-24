using UnityEngine;
using System.Collections;

public class Projectilescript : MonoBehaviour
{
	public int attackDamage = 10;
    private Done_GameController gameController;
    public float destroyDelay = 0.5F;
	GameObject player;
	Health playerHealth;

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
        if (other.gameObject.CompareTag("Boundary"))
        {
            return;
        }

		if (other.gameObject.CompareTag("Enemy")) {

            return;
        }

		if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<Animation>().Play("Impact");
            //Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
           
			//trekk fra other.gameObjects skadeverdi fra spillerhelse
			playerHealth.TakeDamage(attackDamage); 
			GetComponent<Collider>().enabled = false;
            StartCoroutine(Delay(destroyDelay));
            //Destroy(gameObject);
        }
		
    }
    void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag("Boundary")) {
            Destroy(gameObject);
        }
    }

    IEnumerator Delay(float delaytime)
    {
        yield return new WaitForSeconds(delaytime);
    }
}