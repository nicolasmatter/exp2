using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrierTwo : MonoBehaviour {

	public mainTwo m_main;
	public Vector3 m_startPosition;
	public Vector3 m_target;
	private float m_speed = 1;
	public Vector2 speed_variation = new Vector2(0,0);

	private Vector3 alternateTarget;

	public void Setup(mainTwo m)
	{
		m_main = m;
		Reset ();
	}

	private void Reset()
	{
		transform.position = m_main.randomPositions [Random.Range (0, m_main.randomPositions.Count)].position;
		m_startPosition = transform.position;
		m_speed = Random.Range (speed_variation.x, speed_variation.y);
		m_target = m_main.randomPositions [Random.Range (0, m_main.randomPositions.Count)].position;
	}


	private void FixedUpdate()
	{
		if (!m_main.isPaused)
		{
			transform.position = Vector3.MoveTowards (transform.position, m_target, m_speed);

			if (transform.position == m_target)
			{
				Reset ();
			}
		}
	}
}
