using UnityEngine;
using System.Collections;

public class BoltHit : MonoBehaviour {

	public int damagePerShot = 50;


	void OnTriggerEnter(Collider other)
{
		if (other.tag == "Boundary" || other.tag == "Player") {
			return;

		} 
		if (other.gameObject.CompareTag ("Enemy")) {

			var enemyHp = other.gameObject.GetComponent<EnemyHealth>();
			enemyHp.EnemyTakeDamage(damagePerShot);



		} 

	}

	}

