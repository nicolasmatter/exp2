using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public GameObject pivot;
	public float angle;

	void Update()
	{
		if (Input.GetKey (KeyCode.A))
		{
			transform.RotateAround (pivot.transform.position,Vector3.down,angle);
		}	
		if (Input.GetKey (KeyCode.D))
		{
			transform.RotateAround (pivot.transform.position,Vector3.up,angle);
		}	
		if (Input.GetKey (KeyCode.W))
		{
			transform.RotateAround (pivot.transform.position,Vector3.left,angle);
		}	
		if (Input.GetKey (KeyCode.S))
		{
			transform.RotateAround (pivot.transform.position,Vector3.right,angle);
		}	
//		if (Input.GetKey (KeyCode.Q))
//		{
//			transform.RotateAround (pivot.transform.position,Vector3.forward,angle);
//		}	
//		if (Input.GetKey (KeyCode.E))
//		{
//			transform.RotateAround (pivot.transform.position,Vector3.back,angle);
//		}	

		if (Input.GetAxis ("Mouse ScrollWheel")>0f)
		{
			Debug.Log (Input.GetAxis ("Mouse ScrollWheel"));
			transform.position = Vector3.MoveTowards (transform.position, pivot.transform.position, Input.GetAxis ("Mouse ScrollWheel"));
		}
		if (Input.GetAxis ("Mouse ScrollWheel")<0f)
		{
			Debug.Log (Input.GetAxis ("Mouse ScrollWheel"));
			transform.position = Vector3.MoveTowards (transform.position, -pivot.transform.position, Input.GetAxis ("Mouse ScrollWheel"));
		}
	}
}
