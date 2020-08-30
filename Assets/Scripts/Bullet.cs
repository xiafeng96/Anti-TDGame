﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float dmg = 50;
	public float speed = 20;

	public GameObject explosionEffectPrefab;

	public float distanceArriveTarget = 1.2f;

	private Transform target;
	public void SetTarget(Transform _target)
	{
		this.target = _target;
	}

	void Update()
	{
		if (target == null) 
		{
			Die ();
			return;
		}
		transform.LookAt (target.position);
		transform.Translate (Vector3.forward * speed * Time.deltaTime);

		Vector3 dir = target.position - transform.position;
		if (dir.magnitude <= distanceArriveTarget) //bullet hits target
		{
			target.GetComponent<Enemy> ().TakeDmg (dmg);
			Die ();
		}
	}

	void Die()//bullet die
	{
		GameObject effect = GameObject.Instantiate (explosionEffectPrefab, transform.position, transform.rotation);
		Destroy (effect, 1);
		Destroy (this.gameObject);	
	}

} 
