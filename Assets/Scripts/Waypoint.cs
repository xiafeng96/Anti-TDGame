using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {
	public static Transform[] positions;
	// Use this for initialization
	private LineRenderer lineRenderer;
	public GameObject StartPoint;
	public int lineIndex;
	private int l;

	void Start()
	{
		lineIndex = 0;
		lineRenderer = gameObject.GetComponent<LineRenderer>();

		//lineRenderer.startColor = Color.red;    //
		//lineRenderer.endColor = Color.red;      //
		lineRenderer.startWidth = .5f;        //
		lineRenderer.endWidth = .5f;          //
		lineRenderer.useWorldSpace = true;     //

		//lineRenderer.SetSize = 5;
		//lineRenderer.positionCount = 5;
		lineRenderer.SetPosition(0, StartPoint.transform.position);
		/*lineRenderer.SetPosition(1, new Vector3(200, -60));
		lineRenderer.SetPosition(2, new Vector3(100, 100));
		lineRenderer.SetPosition(3, new Vector3(0, 60));
		lineRenderer.SetPosition(4, new Vector3(-100, 120));*/

		//		AddPosition(new Vector3(200, 20));
		//		AddPosition(new Vector3(300, 0));
	}



	public void DrawLine(Vector3 node)
	{
		lineIndex = transform.childCount;
		lineRenderer.numPositions = lineIndex + 1;

		lineRenderer.SetPosition(lineIndex, node);
	}




	// Update is called once per frame
    void Update () {
		positions = new Transform[transform.childCount];
		l = positions.Length - 1;

		for (int i = 0; i < positions.Length; i++) 
		{
			
			positions [i] = transform.GetChild (i);
		}

		//if(positions != null)
		//{
			foreach (Transform k in positions) 
			{
				DrawLine (k.position);
			}

		//}


	}
}
