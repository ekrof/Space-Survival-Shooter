using UnityEngine;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public float hazardCount = 20.0F;
	public float spawnWait;
	public float startWait;
	public float waveWait = 0.75F;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText quitText;

	private bool restart;
	public int score;
	private float startTime;
	public float spawnRamp = 0.5F;
	public float waveWaitRamp = 0.0005F;
	public float waveWaitStart = 0.75F;

	void Start ()
	{
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		quitText.text = "";
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		startTime = Time.time; 
	}
	
	void Update ()
	{
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
			if (Input.GetKeyDown (KeyCode.Q))
			{
				Application.LoadLevel(0);
			}
		}
		hazardCount = (Time.time - startTime) * spawnRamp;
		if (waveWait > 0.05) {
			waveWait = waveWaitStart - (Time.time - startTime) * waveWaitRamp;
		} 
	}
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

		}
	}
	
	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
        restartText.text = "Press 'R' to restart";
		quitText.text = "Press 'Q' to quit";
		restart = true;
    }
}