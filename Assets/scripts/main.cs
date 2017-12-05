using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour {

	public GameObject m_house;
	public int objectCount;
	public Camera m_Camera;
	public List<houses> allHouses;

	public Material h_Material;
	public Material p_Material;
	private int activeMaterialSet;


	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton (0))
		{
			var mousePos = Input.mousePosition;
			mousePos.z = 10; // select distance = 10 units from the camera
			Vector3 newPos = m_Camera.ScreenToWorldPoint (mousePos);
			GameObject newHouse = Instantiate (m_house,newPos, Quaternion.identity);
			if(!Input.GetKey (KeyCode.LeftShift))
			{
			AddHouse (newHouse.GetComponent<houses> ());
			}
			objectCount++;
		}

		if (Input.GetKeyUp (KeyCode.R))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

		if (Input.GetKeyDown (KeyCode.F))
		{
			activeMaterialSet++;
			switch (activeMaterialSet)
			{
			case 0:
				h_Material.color = Color.gray;
				p_Material.color = Color.gray;
				m_Camera.backgroundColor = Color.white;
				break;
			case 1:
				h_Material.color = Color.white;
				p_Material.color = Color.white;
				m_Camera.backgroundColor = Color.black;
				break;
			case 2:
				h_Material.color = Color.black;
				p_Material.color = Color.black;
				m_Camera.backgroundColor = Color.gray;
				activeMaterialSet = -1;
				break;

			}
		}
	}

	void OnGUI()
	{
		var TextStyle = new GUIStyle ();
		TextStyle.normal.textColor = Color.black;
		GUI.Label (new Rect (5,5,200,80), "count: "+objectCount.ToString()+"\nlm - add points\nw/a/s/d/mousewheel - camera \nf - lights\nr - reset",TextStyle);  
	}

	public void AddHouse(houses h)
	{
		allHouses.Add (h);
	}
}
