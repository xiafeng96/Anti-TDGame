using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	public float speed = 4;
	public float hp = 100;
	private float allHp;
	public Slider hpSlider;
	private Transform[] positions;
	private int index = 0;
	public GameObject explosionEffect;
	public Transform endPoint;
	public float d = 0.1f;
	public float x = 0.1f;
	public float y = 0.1f;
	public float z = 0.1f;
	public static int DiedEnemyTutorial;
	//public GameObject blockStart;
	[SerializeField]//
	private Text hpValue;

	// Use this for initialization
	void Start () {
		hp = hp * (float)(1+(PlayerPrefs.GetInt ("HpSkill")*0.20));
		speed = speed * (float)(1+PlayerPrefs.GetInt ("SpeedSkill")*0.20);

		positions = Waypoint.positions;
		allHp = hp;
		DiedEnemyTutorial = 0;


	}
	
	// Update is called once per frame
	void Update () {
		
		Move();
	}

	void Move()
	{	if (index > positions.Length - 1) return;
		transform.Translate((positions [index].position - transform.position).normalized * Time.deltaTime * speed);
		if (Vector3.Distance(positions [index].position, transform.transform.position) < 0.5f)
		{
			index++;
		}
		Vector3 enddir = endPoint.position - transform.position;
		d = enddir.magnitude;
		x = endPoint.position.x;
		y = endPoint.position.y;
		z = endPoint.position.z;
		if (enddir.magnitude <= 1) //index > positions.Length - 1
		{
			ReachDestination ();
		}
	}


	void ReachDestination()
	{
		GameObject.Destroy (this.gameObject);
		GameManager.Instance.Win();
	}




	void OnDestroy()
	{
		EnemySpawner.CountEnemyAlive--;
	}

	public void TakeDmg(float dmg)
	{
		if (hp <= 0)
			return;
		hp -= dmg;
		hpSlider.value = hp / allHp;
		if (hp <= 0) 
		{
			Enemydie ();
		}
		hpValue.text = "HP : " + hp.ToString("0.0") + "/" + allHp ;
	}

	public void Enemydie()
	{
		GameObject effect = GameObject.Instantiate (explosionEffect, transform.position, transform.rotation);
		Destroy (effect,1.5f);
		Destroy (this.gameObject);
		DiedEnemyTutorial = DiedEnemyTutorial + 1;
		EnemySpawner.restEnemyNumber--;
		//blockStart.SetActive (false);
		EnemySpawner.alive = false;

	}
}
