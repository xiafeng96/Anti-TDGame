using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class SkillButtonIntro : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
	public GameObject HpIntro;
	public GameObject SpeedIntro;
	public GameObject MemberIntro;

	public GameObject SpeedLockIntro;
	public GameObject MemberLockIntro;
	public GameObject UndeadLockIntro;
	public GameObject BulletShieldLockIntro;
	public GameObject AutoMarkLockIntro;



	void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
	{
		if (this.name == "Hp") 
		{
			HpIntro.SetActive (true);
			return;
		}
		if (this.name == "Speed") 
		{
			SpeedIntro.SetActive (true);
			return;
		}
		if (this.name == "Member") 
		{
			MemberIntro.SetActive (true);
			return;
		}




		if (this.name == "SpeedLock") 
		{
			SpeedLockIntro.SetActive (true);
			return;
		}
		if (this.name == "MemberLock") 
		{
			MemberLockIntro.SetActive (true);
			return;
		}
		if (this.name == "UndeadLock") 
		{
			UndeadLockIntro.SetActive (true);
			return;
		}
		if (this.name == "BulletShieldLock") 
		{
			BulletShieldLockIntro.SetActive (true);
			return;
		}
		if (this.name == "AutoMarkLock") 
		{
			AutoMarkLockIntro.SetActive (true);
			return;
		}



	}

	void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
	{
		if (this.name == "Hp") 
		{
			HpIntro.SetActive (false);
			return;
		}
		if (this.name == "Speed") 
		{
			SpeedIntro.SetActive (false);
			return;
		}
		if (this.name == "Member") 
		{
			MemberIntro.SetActive (false);
			return;
		}


		if (this.name == "SpeedLock") 
		{
			SpeedLockIntro.SetActive (false);
			return;
		}
		if (this.name == "MemberLock") 
		{
			MemberLockIntro.SetActive (false);
			return;
		}
		if (this.name == "UndeadLock") 
		{
			UndeadLockIntro.SetActive (false);
			return;
		}
		if (this.name == "BulletShieldLock") 
		{
			BulletShieldLockIntro.SetActive (false);
			return;
		}
		if (this.name == "AutoMarkLock") 
		{
			AutoMarkLockIntro.SetActive (false);
			return;
		}

	}
}
