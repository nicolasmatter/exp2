using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

	public GameObject pivot;
	public float angle;
	public float distance;
	public float t;
	public bool t_reset;
	private Vector3 activeXDirection; 
	public float q;
	public bool q_reset;
	private Vector3 activeYDirection;

	void Update()
	{
		if (Input.GetKey (KeyCode.A))
		{
			t_reset = false;
			t = Mathf.Clamp (t + Time.deltaTime, 0, 2);
			RotateAround (Vector3.down,t);
		}	

		if (Input.GetKey (KeyCode.D))
		{
			t_reset = false;
			t = Mathf.Clamp (t + Time.deltaTime, 0, 2);
			RotateAround (Vector3.up,t);
		}	

		if (Input.GetKeyUp (KeyCode.A))
		{
			t_reset = true;
			activeXDirection = Vector3.down;
		}

		if (Input.GetKeyUp (KeyCode.D))
		{
			t_reset = true;
			activeXDirection = Vector3.up;
		}

		if (t_reset)
		{
			if (t > 0)
			{
				t = Mathf.Clamp (t - Time.deltaTime, 0, 2);
				RotateAround (activeXDirection, t);
			}
			else
			{
				t = 0;
				t_reset = false;
			}
		}

		if (Input.GetKey (KeyCode.W))
		{
			q = Mathf.Clamp (q + Time.deltaTime, 0, 2);
			RotateAround (Vector3.left,q);
		}	

		if (Input.GetKey (KeyCode.S))
		{
			q = Mathf.Clamp (q + Time.deltaTime, 0, 2);
			RotateAround (Vector3.right,q);
		}	
		if (Input.GetKeyUp (KeyCode.W))
		{
			q_reset = true;
			activeYDirection = Vector3.left;
		}

		if (Input.GetKeyUp (KeyCode.S))
		{
			q_reset = true;
			activeYDirection = Vector3.right;
		}

		if (q_reset)
		{
			if (q > 0)
			{
				q = Mathf.Clamp (q - Time.deltaTime, 0, 2);
				RotateAround (activeYDirection, q);
			}
			else
			{
				q = 0;
				q_reset = false;
			}
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

	private void RotateAround(Vector3 direction, float speedValue)
	{
		transform.RotateAround (pivot.transform.position,direction,Mathf.Lerp(0.5f,angle,speedValue));
	}
}
