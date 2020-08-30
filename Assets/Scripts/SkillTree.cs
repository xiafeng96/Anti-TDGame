using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkillTree : MonoBehaviour {

	public static int HpSkill;
	public static int SpeedSkill;
	public static int MemberSkill;
	public static int EnemyMember;
	public static int SkillPoint;
	public Text HpSkillText;
	public Text SpeedSkillText;
	public Text MemberSkillText;
	public Text SkillPointText;
	public int SkillPointTotal;
	private int SkillUsed;

	public GameObject SpeedLock;
	public GameObject MemberLock;
	public GameObject UndeadLock;
	public GameObject BulletShieldLock;
	public GameObject AutoLock;

	public Animator SkillTreeOut;

	void Awake()
	{
		
	}

	// Use this for initialization
	void Start () {
		//SkillPointTotal = PlayerPrefs.GetInt("SkillPointTotal");

		HpSkill = PlayerPrefs.GetInt("HpSkill");
		SpeedSkill = PlayerPrefs.GetInt("SpeedSkill");
		MemberSkill = PlayerPrefs.GetInt("MemberSkill");
		//SkillPoint = PlayerPrefs.GetInt("SkillPoint");
		//SkillPoint = SkillPointTotal; //For Test
		SkillPointTotal = PlayerPrefs.GetInt("Level1Clear")+PlayerPrefs.GetInt("Level2Clear")+PlayerPrefs.GetInt("Level3Clear");

	}

	private IEnumerator LoadMainMenu()
	{
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("MainMenu");
	}

	public void onMainMenu()
	{
		SkillTreeOut.SetTrigger("SkillTreeOut");
		StartCoroutine(LoadMainMenu ());
		//SceneManager.LoadScene ("MainMenu");
	}




	void Update()
	{
		PlayerPrefs.SetInt ("HpSkill", HpSkill);
		PlayerPrefs.SetInt ("SpeedSkill", SpeedSkill);
		PlayerPrefs.SetInt ("MemberSkill", MemberSkill);

		SkillUsed = HpSkill + SpeedSkill + MemberSkill;
		SkillPoint = SkillPointTotal - SkillUsed;

		HpSkillText.text = PlayerPrefs.GetInt("HpSkill").ToString() + "/5";
		SpeedSkillText.text = PlayerPrefs.GetInt("SpeedSkill").ToString()+ "/5";
		MemberSkillText.text =PlayerPrefs.GetInt("MemberSkill").ToString()+ "/5";
		SkillPointText.text =SkillPoint.ToString();
		EnemyMember = 2 + MemberSkill;



		if (PlayerPrefs.GetInt ("HpSkill")>0) {	
			SpeedLock.SetActive (false);
			MemberLock.SetActive (false);
		} 
		else
		{
			SpeedLock.SetActive (true);
			MemberLock.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("SpeedSkill")>2) {
			UndeadLock.SetActive (false);
		}
		else
		{
			UndeadLock.SetActive (true);
		}

		if(PlayerPrefs.GetInt("MemberSkill")>2)
		{
			BulletShieldLock.SetActive (false);
		}
		else
		{
			BulletShieldLock.SetActive (true);
		}


	}


	public void onHpSkill()
	{
		if (SkillPoint > 0) 
		{
			if (PlayerPrefs.GetInt ("HpSkill") > 4)
				return;
			SkillUsed = SkillUsed--;
			PlayerPrefs.SetInt ("HpSkill", HpSkill++);
			Debug.Log (PlayerPrefs.GetInt("HpSkill"));

		}
	
	}


	public void onSpeedSkill()
	{
		if (PlayerPrefs.GetInt ("HpSkill") < 1)
			return;
		if (PlayerPrefs.GetInt ("SpeedSkill") > 4)
			return;

		if (SkillPoint > 0) 
		{
			SkillUsed = SkillUsed--;
			PlayerPrefs.SetInt ("SpeedSkill", SpeedSkill++);
			//PlayerPrefs.SetInt ("SkillPoint", SkillPoint--);
			Debug.Log (PlayerPrefs.GetInt("SpeedSkill"));
	
		}

	}

	public void onMemberSkill()
	{
		if (PlayerPrefs.GetInt ("HpSkill") < 1)
			return;
		if (PlayerPrefs.GetInt ("MemberSkill") > 4)
			return;

		if (SkillPoint > 0) 
		{
			SkillUsed = SkillUsed--;
			PlayerPrefs.SetInt ("MemberSkill", MemberSkill++);
			//PlayerPrefs.SetInt ("SkillPoint", SkillPoint--);
			Debug.Log (PlayerPrefs.GetInt("MemberSkill"));

		}

	}

	public void onResetSkill()
	{
		PlayerPrefs.SetInt ("HpSkill", 0);
		PlayerPrefs.SetInt ("SpeedSkill", 0);
		PlayerPrefs.SetInt ("MemberSkill", 0);
		PlayerPrefs.SetInt ("SkillPoint", SkillPointTotal);
		HpSkill = 0;
		SpeedSkill = 0;
		MemberSkill = 0;
		SkillUsed=0;
		SkillPoint = PlayerPrefs.GetInt ("SkillPoint");
		Debug.Log (PlayerPrefs.GetInt("HpSkill"));
		Debug.Log (PlayerPrefs.GetInt("SpeedSkill"));

	}



}
