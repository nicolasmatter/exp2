using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class houses : MonoBehaviour {

	public main m_main;
	public GameObject person;
	public GameObject target;
	public float speed;

	private void Start()
	{
		m_main = FindObjectOfType<main> ();
		Spawn ();
	}


	public void Spawn()
	{
		GameObject spawn = Instantiate (person,transform.position,Quaternion.identity,gameObject.transform);
		target = m_main.allHouses[Random.Range (0,m_main.allHouses.Count)].gameObject;
		carrier c_person = spawn.GetComponent<carrier> ();
		c_person.Setup (target.transform.position,gameObject.GetComponent<houses> (),m_main); 
	}
}
