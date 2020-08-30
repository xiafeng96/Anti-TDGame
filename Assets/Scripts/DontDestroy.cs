using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	public static DontDestroy Instance = null;

	void Start()
	{
		if (Instance != null) 
		{
			Destroy (this);
			return;
		}
		Instance = this;
		DontDestroyOnLoad (this.gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
