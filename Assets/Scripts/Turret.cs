using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

	public List<GameObject> enemys = new List<GameObject>();

    void OnTriggerEnter(Collider col)//enemy enter turret attackrange
    {
        if (col.tag == "Enemy")
        {
            enemys.Add(col.gameObject);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Enemy")
        {
            enemys.Remove(col.gameObject);
        }
    }

	public float attackRate = 1;
	private float timer = 0;

	public GameObject bulletPre;
	public Transform firePoint;
	public Transform head;
	public bool useLaser = false;
	public float laserDmg = 40; //laser dmg per sec
	public LineRenderer laser;
	public GameObject laserEffect;
	void Start(){
		timer = attackRate;
	}
	 

	void Update()
	{
		if (enemys.Count > 0 && enemys [0] != null) //turn turret head
		{
			Vector3 targetPosition = enemys [0].transform.position;
			targetPosition.y = head.position.y;
			head.LookAt (targetPosition);
		}
		if (useLaser == false) //bullet attack
		{
			timer += Time.deltaTime;
			if (enemys.Count > 0 && timer >= attackRate) {
				timer = 0;
				Attack ();
			} 
		} 
		else if (enemys.Count > 0) //laser attack
		{
			if (laser.enabled == false)
			{ 
				laser.enabled = true;
				laserEffect.SetActive (true); 
			}

			if (enemys [0] == null) 
			{
				UpdateEnemys ();
			}
			if (enemys.Count > 0) 
			{    
				laser.SetPositions (new Vector3[] { firePoint.position, enemys [0].transform.position });
				enemys[0].GetComponent<Enemy> ().TakeDmg (laserDmg * Time.deltaTime);
				laserEffect.transform.position = enemys [0].transform.position;
				Vector3 positionT = transform.position;
				positionT.y = enemys[0].transform.position.y;
				laserEffect.transform.LookAt (positionT);
			}
		} 
		else 
		{
			laserEffect.SetActive (false); 
			laser.enabled = false;
		}

	}


	void Attack()
	{	if (enemys [0] == null) 
		{
			UpdateEnemys ();
		}
		if (enemys.Count > 0) {
			GameObject bullet = GameObject.Instantiate (bulletPre, firePoint.position, firePoint.rotation);
			bullet.GetComponent<Bullet> ().SetTarget (enemys [0].transform);			
		} 
		else 
		{
			timer = attackRate;
		}

	}

	void UpdateEnemys()//use for enemy die
	{
		List<int> emptyIndex = new List<int> ();
		for (int index = 0; index < enemys.Count; index++) 
		{
			if (enemys [index] == null) 
			{
				emptyIndex.Add (index);
			}
		}


		for (int i = 0; i < emptyIndex.Count; i++) 
		{
			enemys.RemoveAt (emptyIndex [i]-i);
		}
	}


}
