using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject failUi;
	public GameObject winUi;
	public GameObject SkillUi;
	public static GameManager Instance;
	//public EnemySpawner enemySpawner;
	//public GameObject wayPoint;
	public Text gameSituation;
	public GameObject EditTextSet;
	//private int skillpointtotal;

	void Awake()
	{
		Instance = this;
		//skillpoint = PlayerPrefs.GetInt ("SkillPoint");
		//skillpointtotal = PlayerPrefs.GetInt ("SkillPointTotal");
		//enemySpawner = GetComponent<EnemySpawner> ();
		//PlayerPrefs.SetInt("EnemTotal",2);
		//Debug.Log (skillpoint);

	}

	void Start()
	{


	}

	void Update()
	{
		if (EnemySpawner.restEnemyNumber == 0) 
		{
			Failed ();
		}
		gameSituation.text = "剩余人员: " + EnemySpawner.restEnemyNumber + " / " + EnemySpawner.totalEnemyNumber;
		/*Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayhit;
		if (Physics.Raycast (ray, out rayhit)) {
			Debug.Log (rayhit.transform.name);}*/
		
	
	}

	public void onButtonClean()
	{
		PlayerPrefs.SetInt("RestEnemy", EnemySpawner.restEnemyNumber);
		PlayerPrefs.SetInt ("CleanTutorial", 1);
		if (GameObject.Find ("Enemy1(Clone)") != null) 
		{	
			PlayerPrefs.SetInt("RestEnemy", EnemySpawner.restEnemyNumber-1);
			if (EnemySpawner.restEnemyNumber == 1) 
			{
				Failed ();
				return;
			}
		}
		PlayerPrefs.SetInt ("CleanTutorial", 1);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}
		
	public void onSkillTree()
	{
		Destroy (EditTextSet);
		PlayerPrefs.SetInt("RestEnemy",0);
		SceneManager.LoadScene ("SkillTree");
	}


	public void Win()
	{
		Destroy (EditTextSet);
		Scene scene = SceneManager.GetActiveScene ();
		//enemySpawner.Stop();
		winUi.SetActive (true);
		if (scene.name == "Level1") 
		{
			if (PlayerPrefs.GetInt ("Level1Clear" )==0) 
			{
				PlayerPrefs.SetInt ("Level1Clear",1);
				SkillUi.SetActive (true);
				PlayerPrefs.SetInt ("FirstWin",1);
				/*SkillTree.SkillPoint = SkillTree.SkillPoint++;
				skillpointtotal = skillpointtotal++;
				PlayerPrefs.SetInt ("SkillPoint",skillpointtotal);
				//PlayerPrefs.SetInt ("SkillPointTotal",skillpoint);
			
				//Debug.Log ("skillpoint = " + skillpoint);
				Debug.Log ("skillpointtotal = " + skillpointtotal);
				Debug.Log ("Pref skillpointtotal = " + PlayerPrefs.GetInt ("SkillPointTotal"));

				Debug.Log ("Pref SkillPoint = " + PlayerPrefs.GetInt ("SkillPoint"));*/
			}
		}

		if (scene.name == "Level2") 
		{
			if (PlayerPrefs.GetInt ("Level2Clear")==0) 
			{
				PlayerPrefs.SetInt ("Level2Clear",1);
				SkillUi.SetActive (true);
				/*SkillTree.SkillPoint = SkillTree.SkillPoint++;
				skillpointtotal = skillpointtotal++;
				PlayerPrefs.SetInt ("SkillPoint",skillpointtotal);
				//PlayerPrefs.SetInt ("SkillPointTotal",skillpoint);*/

				//Debug.Log (skillpoint);
			}
		}

		if (scene.name == "Level3") 
		{
			if (PlayerPrefs.GetInt ("Level3Clear" )==0) 
			{
				PlayerPrefs.SetInt ("Level3Clear",1);
				SkillUi.SetActive (true);
				/*SkillTree.SkillPoint = SkillTree.SkillPoint++;
				skillpointtotal = skillpointtotal++;
				PlayerPrefs.SetInt ("SkillPoint",skillpointtotal);
				//PlayerPrefs.SetInt ("SkillPointTotal",skillpoint);*/

				//Debug.Log (skillpoint);
			}
		}




	}

	public static void RemoveAllChildren(GameObject parent)
	{
		Transform transform;
		for(int i = 0;i < parent.transform.childCount; i++)
		{
			transform = parent.transform.GetChild(i);
			GameObject.Destroy(transform.gameObject);
		}
	}

	public void Failed() 
	{
		failUi.SetActive (true);
	}

	public void OnButtonRetry()
	{
		PlayerPrefs.SetInt("RestEnemy",0);
		Destroy (EditTextSet);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void OnButtonMenu()
	{
		PlayerPrefs.SetInt("RestEnemy",0);
		Destroy (EditTextSet);
		SceneManager.LoadScene ("MainMenu");
	}

	public void OnButtonNext1()
	{
		PlayerPrefs.SetInt("RestEnemy",0);
		Destroy (EditTextSet);
		SceneManager.LoadScene ("Level2");
	}

	public void OnButtonNext2()
	{
		PlayerPrefs.SetInt("RestEnemy",0);
		Destroy (EditTextSet);
		SceneManager.LoadScene ("Level3");
	}
		



}
