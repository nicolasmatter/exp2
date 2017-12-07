using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public GameObject pivot;
	public float angle;
	public float distance;
	private float t;
	private float q;

	void Update()
	{
		if (Input.GetKey (KeyCode.A))
		{
			t += Time.deltaTime;
			transform.RotateAround (pivot.transform.position,Vector3.down,Mathf.Lerp(0.5f,angle,t));
		}	
		if (Input.GetKeyUp (KeyCode.A))
		{
			t = 0;
		}
		if (Input.GetKey (KeyCode.D))
		{
			t += Time.deltaTime;
			transform.RotateAround (pivot.transform.position,Vector3.up,Mathf.Lerp(0.5f,angle,t));
		}	
		if (Input.GetKeyUp (KeyCode.D))
		{
			t = 0;
		}
		if (Input.GetKey (KeyCode.W))
		{
			q += Time.deltaTime;
			transform.RotateAround (pivot.transform.position,Vector3.left,Mathf.Lerp(0.5f,angle,q));
		}	
		if (Input.GetKeyUp (KeyCode.W))
		{
			q = 0;
		}
		if (Input.GetKey (KeyCode.S))
		{
			q += Time.deltaTime;
			transform.RotateAround (pivot.transform.position,Vector3.right,Mathf.Lerp(0.5f,angle,q));
		}	
		if (Input.GetKeyUp (KeyCode.S))
		{
			q = 0;
		}

		distance = Mathf.Clamp (Vector3.Distance (transform.position, pivot.transform.position), 1f,100f)/10f;

		if (Input.GetAxis ("Mouse ScrollWheel")>0f)
		{
			transform.position = Vector3.MoveTowards (transform.position, pivot.transform.position, Input.GetAxis ("Mouse ScrollWheel")*distance);
		}
		if (Input.GetAxis ("Mouse ScrollWheel")<0f)
		{
			transform.position = Vector3.MoveTowards (transform.position, -pivot.transform.position, Input.GetAxis ("Mouse ScrollWheel")*distance);
		}
	}
}
