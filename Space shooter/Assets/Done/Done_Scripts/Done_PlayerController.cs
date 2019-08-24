using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}
public class Done_PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Done_Boundary boundary;
	
	public GameObject shot;

	public Transform shotSpawn;
	public float fireRate;
	public float weaponLoss;
	public int weapon = 1;
	
	private float nextFire;
	public int getHealthValue = 60;
	Health playerhealth;


	public AudioSource pow1;
	public AudioSource pow2;
	public AudioSource pow3;


	void Awake(){
		
		playerhealth = GetComponent<Health> ();
	}

	void OnTriggerEnter(Collider other)

	{

		if (other.tag == "Powerup1") { 
			//weaponLoss = Time.time + 10;
			pow1.Play();
			playerhealth.GetHealth(getHealthValue);
			Destroy(other.gameObject);
		}
			
		if (other.tag == "Powerup2") {
			weapon = 2;		
			//yield return new WaitForSeconds (wait);
			pow2.Play();
			weaponLoss = Time.time + 5;
			Destroy(other.gameObject);
				
		}

		 if (other.tag == "Powerup3") {
			weapon = 3;	
			pow3.Play();
			weaponLoss = Time.time + 3;
			Destroy(other.gameObject);

		}	
		}



	void Update (){
			
		if (Time.time > weaponLoss && weapon!=1) {
			weapon = 1;
		}

		if (Input.GetButton ("Fire1")| Input.GetButton("Jump") && Time.time > nextFire) {

			switch (weapon) {

			case 3:
                    //rapidfire
				weapon = 3;
				nextFire = Time.time + fireRate * 0.1F;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
				break;
			case 2:
                    //Triplebolt
				weapon = 2;
				nextFire = Time.time + fireRate;
				shotSpawn.transform.Rotate (0, -20, 0);
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				shotSpawn.transform.Rotate (0, 40, 0);
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				shotSpawn.transform.Rotate (0, -20, 0);
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
				break;
			case 1:
                    //health
				weapon = 1;
				nextFire = Time.time + fireRate;
				Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
				GetComponent<AudioSource> ().Play ();
				break;
			default:
				print ("Incorrect weapon");
				break;
			}
		}
	}


	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().velocity = movement * speed;
		
		GetComponent<Rigidbody>().position = new Vector3
		(
			Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
			0.0f, 
			Mathf.Clamp (GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
	}


}
