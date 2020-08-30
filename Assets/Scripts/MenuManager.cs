using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public GameObject Level2Lock;
	public GameObject Level3Lock;
	public Animator LevelMenuAnim;
	public Animator MainMenuAnim;
	// Use this for initialization
	void Awake()
	{
		Screen.SetResolution (1115,909, false);
	}

	void Start () {
		/*LevelMenuIn = LevelMenuAnim.GetComponent<Animator> ("LevelMenu");
		LevelMenuOut = LevelMenuAnim.GetComponent<Animator> ("LevelMenuOut");
		MainMenuIn = MainMenuAnim.GetComponent<Animator> ("MainMenuIn");
		MainMenuOut = MainMenuAnim.GetComponent<Animator> ("MainMenuOut");*/

		SkillTree.EnemyMember = 2 + PlayerPrefs.GetInt("MemberSkill");

	}
		
	public void onStartGame()
	{
		MainMenuAnim.SetBool("isMainMenuOut",true);
		LevelMenuAnim.SetBool ("isLevelMenuIn", true);
	}

	public void onBack()
	{
		MainMenuAnim.SetBool("isMainMenuOut",false);
		LevelMenuAnim.SetBool ("isLevelMenuIn", false);
	}

	public void onSkillTree()
	{
		SceneManager.LoadScene ("SkillTree");
	}

	public void onQuitGame()
	{
		Application.Quit ();
	}

	public void onLevel1()
	{
		SceneManager.LoadScene ("Level1");
	}
	public void onLevel2()
	{
		SceneManager.LoadScene ("Level2");
	}
	public void onLevel3()
	{
		SceneManager.LoadScene ("Level3");
	}

	public void onResetAll()
	{
		PlayerPrefs.SetInt ("Level1Clear", 0);
		PlayerPrefs.SetInt ("Level2Clear", 0);
		PlayerPrefs.SetInt ("Level3Clear", 0);
		PlayerPrefs.SetInt ("HpSkill", 0);
		PlayerPrefs.SetInt ("SpeedSkill", 0);
		PlayerPrefs.SetInt ("MemberSkill", 0);
		Debug.Log (PlayerPrefs.GetInt ("Level1Clear"));
		PlayerPrefs.DeleteKey ("AlreadyPlayTutorial1");
		PlayerPrefs.DeleteKey ("CleanTutorial");
		PlayerPrefs.DeleteKey ("FirstWin");
		PlayerPrefs.SetInt ("RestEnemy", 0);
	}

	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerPrefs.GetInt ("Level1Clear") == 1) {
			Level2Lock.SetActive (false);
		} 
		else 
		{
			Level2Lock.SetActive (true);
		}
		if (PlayerPrefs.GetInt ("Level2Clear" )==1) 
		{
			Level3Lock.SetActive (false);
		}
		else 
		{
			Level3Lock.SetActive (true);
		}
	}
}
