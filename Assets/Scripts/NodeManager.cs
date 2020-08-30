using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NodeManager : MonoBehaviour {
	public NodeData waypoint; 
	public GameObject nodePoint;
	public GameObject nodeWhere;
	public static int TutorialNodeBuild;

	void Start()
	{
		TutorialNodeBuild = 0;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			Ray raytest = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hittest;
			if (Physics.Raycast (raytest, out hittest, 1000, LayerMask.GetMask ("Water")))
				return;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;


				bool isCollider = Physics.Raycast(ray,out hit,1000,LayerMask.GetMask("Node"));
				if(EnemySpawner.alive){
					return;
				}
				if (isCollider) {
				Node node = hit.collider.GetComponent<Node> ();
				if (node.nodeGo == null) {
					node.BuildNode (nodePoint, nodeWhere);//new node
					TutorialNodeBuild = TutorialNodeBuild + 1;
					Debug.Log ("TutorialNodeBuild" + TutorialNodeBuild);
					}
					else {
					return;//Destroy (node.nodeGo);
					}
				}
		}



	}
}
