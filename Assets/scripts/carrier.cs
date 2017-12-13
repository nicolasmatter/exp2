using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrier : MonoBehaviour {

	public main m_main;
	public Vector3 m_target;
	public float m_speed;
	public Vector2 speed_variation = new Vector2(0,0);
	public houses m_home;

	private Vector3 alternateTarget;
	private bool lookingForAlternate;

	public void Setup(Vector3 target, houses home, main m)
	{
		m_main = m;
		m_target = target;
		m_home = home;
		m_speed *= Random.Range (speed_variation.x, speed_variation.y);
		lookingForAlternate = false;
	}

	private void FixedUpdate()
	{
		if (!m_main.isPaused)
		{
			if (!lookingForAlternate)
			{
				transform.position = Vector3.MoveTowards (transform.position, m_target, m_speed);

				if (transform.position == m_target)
				{
					transform.position = m_home.transform.position;
					m_target = m_main.allHouses [Random.Range (0, m_main.allHouses.Count)].gameObject.transform.position;
				}
			}
			else
			{
				transform.position = Vector3.MoveTowards (transform.position, alternateTarget, m_speed);

				if (transform.position == alternateTarget)
				{
					transform.position = m_home.transform.position;
					m_target = m_main.allHouses [Random.Range (0, m_main.allHouses.Count)].gameObject.transform.position;
				}
			}

			if (Input.GetMouseButtonDown (1))
			{
				if (lookingForAlternate)
				{
					lookingForAlternate = false;
					m_speed /= 2;
				}
				else
				{	
					alternateTarget = m_main.newPos;
					lookingForAlternate = true;
					m_speed *= 2;
				}
			}
		}


//		transform.position *= Random.Range (0.999f,1.001f);
	}
}
