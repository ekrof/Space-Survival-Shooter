using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class urlscript : MonoBehaviour {

public Button url;

	void Start () {
		
		url = url.GetComponent<Button> ();
		
	}

	public void OnMouseDown()
	{

		Application.OpenURL("Https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial");
	}
	
}
