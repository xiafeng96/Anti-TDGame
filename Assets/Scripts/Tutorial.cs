using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
	public GameObject FirstStep;
	public GameObject FirstStepBlock;
	public GameObject SecondStep;
	public GameObject SecondStepBlock1;
	public GameObject SecondStepBlock2;
	public GameObject SecondStepBlock3;
	public GameObject TrdStep;
	public GameObject TrdStepBlock;
	public GameObject FourthStep;
	public GameObject FourthStepBlock;
	public GameObject FivethStep;
	public GameObject FivethStepBlock;
	public GameObject SixthStep;
	public GameObject SixthStepBlock;
	public GameObject SeventhStep;
	public GameObject SeventhStepBlock;
	public GameObject EighthStep;
	public GameObject EighthStepBlock;
	public GameObject NinethStep;

	private int TutorialStep;


	// Use this for initialization
	void Start () {
		TutorialStep = 0;
		if (!PlayerPrefs.HasKey ("CleanTutorial")) 
		{
			FirstStep.SetActive (true);
			FirstStepBlock.SetActive (true);
		}
	}


	
	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey ("AlreadyPlayTutorial1"))
			return;
		if (!PlayerPrefs.HasKey ("CleanTutorial")) 
		{		
			if (Input.GetMouseButtonDown (0) && TutorialStep == 0) {
				FirstStep.SetActive (false);
				FirstStepBlock.SetActive (false);
				SecondStep.SetActive (true);
				SecondStepBlock1.SetActive (true);
				TutorialStep = 1;
				Debug.Log (TutorialStep);
			} else if (NodeManager.TutorialNodeBuild == 1) {
				SecondStepBlock1.SetActive (false);
				SecondStepBlock2.SetActive (true);
				TutorialStep = 2;
			} else if (NodeManager.TutorialNodeBuild == 2) {
				SecondStepBlock2.SetActive (false);
				SecondStepBlock3.SetActive (true);
				TutorialStep = 3;
			} else if (NodeManager.TutorialNodeBuild == 3) {
				SecondStepBlock3.SetActive (false);
				SecondStep.SetActive (false);
				TrdStep.SetActive (true);
				TrdStepBlock.SetActive (true);
				TutorialStep = 4;
			} else if (TutorialStep == 4 && NodeManager.TutorialNodeBuild == 4) {
				TrdStepBlock.SetActive (false);
				TrdStep.SetActive (false);
				FourthStep.SetActive (true);
				FourthStepBlock.SetActive (true);
				TutorialStep = 5;
			} else if (TutorialStep == 5 && EnemySpawner.StartTutorial == 1) {
				FourthStep.SetActive (false);
				FourthStepBlock.SetActive (false);
				FivethStepBlock.SetActive (true);
				FivethStep.SetActive (true);
				TutorialStep = 6;
				Debug.Log ("TutorialStep" + TutorialStep);
			} else if (TutorialStep == 6 && Enemy.DiedEnemyTutorial == 1) {
				FivethStepBlock.SetActive (false);
				FivethStep.SetActive (false);
				SixthStepBlock.SetActive (true);
				SixthStep.SetActive (true);
				TutorialStep = 7;
				Debug.Log ("TutorialStep" + TutorialStep);
			}
			else if (Input.GetMouseButtonDown (0) && TutorialStep == 7) {
				SixthStepBlock.SetActive (false);
				SixthStep.SetActive (false);
				SeventhStep.SetActive (true);
				SeventhStepBlock.SetActive (true);
				TutorialStep = 8;
				Debug.Log ("TutorialStep" + TutorialStep);
			}

		} 
		else 
		{
			SeventhStep.SetActive (false);
			SeventhStepBlock.SetActive (false);
			EighthStep.SetActive (true);
		}

		if (PlayerPrefs.GetInt ("FirstWin") == 1) 
		{
			EighthStep.SetActive (false);
			NinethStep.SetActive (true);
			PlayerPrefs.SetInt ("AlreadyPlayTutorial1", 1);
		}



	}
}
