using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public static int CountEnemyAlive = 0;
	//public Wave[] waves;
	public Transform start;
	//public float waveRate = 1;
	public static bool onTrriger = false;
	public static bool onPause = false;
	public static float onPauseTimeScale;
	public static bool onTwice = false;
	private Coroutine coroutine;
	public static int EnemyNumber;
	public static int restEnemyNumber;
	public static int totalEnemyNumber;
	public static bool alive;
	public GameObject enemyPrefab;
	public static int StartTutorial;

	void Awake()
	{
		EnemyNumber = SkillTree.EnemyMember;
		StartTutorial = 0;
	}
	void Start()
	{   Time.timeScale = 1;
		
		onTrriger = false;
		onPause = false;
		restEnemyNumber = EnemyNumber;
		if (PlayerPrefs.GetInt ("RestEnemy") != 0) 
		{
			//Debug.Log (PlayerPrefs.GetInt ("RestEnemy"));
			restEnemyNumber = PlayerPrefs.GetInt ("RestEnemy");
		}
		totalEnemyNumber = EnemyNumber;
		alive = false;
	}



	public void OnStart()
	{
		StartTutorial = StartTutorial + 1;
		onTrriger = !onTrriger;
		if (!alive) {
			GameObject.Instantiate (enemyPrefab, start.position, Quaternion.identity);
			alive = true;
		} 
	}

	public void OnPause(bool onValueChanged)
	{
		onPause = !onPause;
		if (onPause) {
			onPauseTimeScale = Time.timeScale;
			Time.timeScale = 0;
			return;
		} 
		else 
		{
			Time.timeScale = onPauseTimeScale;
			return;
		}



	}

	public void OnSpeed(bool onValueChanged)
	{
		onTwice = !onTwice;
		if (Time.timeScale == 1) {
			Time.timeScale = 2;
			return;
		} 
		else if(Time.timeScale == 2)
		{
			Time.timeScale = 1;
			return;
		}



	}


	/*public void Stop()
	{
		StopCoroutine (coroutine);
	}*/


	/*IEnumerator SpawnEnemy()
	{
		foreach(Wave wave in waves)
		{
			for (int i = 0; i < wave.count; i++) {
				GameObject.Instantiate (wave.enemyPrefab, start.position, Quaternion.identity);
				CountEnemyAlive++;
				if(i != wave.count - 1)
					yield return new WaitForSeconds (wave.rate);
			}
			while (CountEnemyAlive > 0) {
				yield return 0;
			}
			yield return new WaitForSeconds (waveRate);
		}
		while (CountEnemyAlive > 0) 
		{
			yield return 0;
		}

		GameManager.Instance.Failed();
	
	}*/


}
