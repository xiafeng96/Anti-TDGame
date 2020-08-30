using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Node : MonoBehaviour {
	[HideInInspector]
	public GameObject nodeGo;
	private Renderer renderer;
	public static Vector3 newNodePos;


	void Start()
	{

		renderer = GetComponent<Renderer> ();
	}
		

	void Upgrade()
	{
		
	}

	public void BuildNode(GameObject node, GameObject xNode)
	{
		newNodePos.x = transform.position.x;
		newNodePos.y = transform.position.y + 1.4f;
		newNodePos.z = transform.position.z;
		GameObject n = Instantiate (node, newNodePos, Quaternion.identity);//GameObject n = Instantiate (node, transform.position, Quaternion.identity);
		n.transform.parent = xNode.transform;
		nodeGo = n;
	}


	void OnMouseEnter()
	{
		if(EnemySpawner.alive){
			return;
		}
			renderer.material.color = Color.red;
		
	}

	void OnMouseExit()
	{
		if(EnemySpawner.alive){
			return;
		}

		if (nodeGo != null) {
				renderer.material.color = Color.yellow;
			} 
			else 
			{
				renderer.material.color = Color.cyan;
			}
		

	
	
}
}
