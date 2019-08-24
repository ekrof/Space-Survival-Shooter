using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Button start;
	public int level = 1;



	// Use this for initialization
	void Start () {

if (start != null) {
			start = start.GetComponent<Button> ();
		}
	}

	public void StartLevel(){

		Application.LoadLevel (level);
	
	}
}
