using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrier : MonoBehaviour {

	public main m_main;
	public Vector3 m_target;
	public float m_speed;
	public Vector2 speed_variation = new Vector2(0,0);
	public houses m_home;

	public void Setup(Vector3 target, houses home, main m)
	{
		m_main = m;
		m_target = target;
		m_home = home;
		m_speed *= Random.Range (speed_variation.x, speed_variation.y);
	}

	private void FixedUpdate()
	{
		transform.position = Vector3.MoveTowards (transform.position, m_target, m_speed);

		if (transform.position == m_target)
		{
			transform.position = m_home.transform.position;
			m_target = m_main.allHouses[Random.Range (0,m_main.allHouses.Count)].gameObject.transform.position;
		}

//		transform.position *= Random.Range (0.999f,1.001f);
	}
}
