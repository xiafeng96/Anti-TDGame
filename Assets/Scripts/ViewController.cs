using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {

	public float speed = 1;
	public float ScrollWheel = 60;
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");
		float mouse = Input.GetAxis ("Mouse ScrollWheel");
		if (h * speed > 0 && this.transform.localPosition.x < 25) 
		{transform.Translate (new Vector3 (h, mouse * ScrollWheel, v) * Time.deltaTime * speed, Space.World);}
		if (h * speed < 0 && this.transform.localPosition.x > -15) 
		{transform.Translate (new Vector3 (h, mouse * ScrollWheel, v) * Time.deltaTime * speed, Space.World);}
		if (v * speed < 0 && this.transform.localPosition.z > -15) 
		{transform.Translate (new Vector3 (h, mouse * ScrollWheel, v) * Time.deltaTime * speed, Space.World);}
		if (v * speed > 0 && this.transform.localPosition.z < 30) 
		{transform.Translate (new Vector3 (h, mouse * ScrollWheel, v) * Time.deltaTime * speed, Space.World);}
		if (mouse * speed * ScrollWheel > 0 && this.transform.localPosition.y < 60) 
		{transform.Translate (new Vector3 (h, mouse * ScrollWheel, v) * Time.deltaTime * speed, Space.World);}
		if (mouse * speed * ScrollWheel < 0 && this.transform.localPosition.y > 20) 
		{transform.Translate (new Vector3 (h, mouse * ScrollWheel, v) * Time.deltaTime * speed, Space.World);}


	}
}
