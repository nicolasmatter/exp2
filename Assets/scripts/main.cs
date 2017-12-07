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

	public Vector3 newPos;
	private int randomBuildCounter;
	public int rbcTarget;
	private bool isBuildingRandom;
	public int randomPositionCount;
	private List<Vector3> randomPositions = new List<Vector3>();
	public Vector3 randomPositionsRange;

	// Update is called once per frame
	//


	void Update () 
	{
		var mousePos = Input.mousePosition;
		mousePos.z = 10; // select distance = 10 units from the camera
		newPos = m_Camera.ScreenToWorldPoint (mousePos);

		if (Input.GetMouseButton (0))
		{
			SpawnHouse (newPos);
		}

		if (Input.GetKeyUp (KeyCode.R))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

		if (Input.GetKeyDown (KeyCode.Period))
		{
			randomPositionCount++;
		}
		if (Input.GetKeyDown (KeyCode.Comma) && randomPositionCount > 0)
		{
			randomPositionCount--;
		}

		if (Input.GetKey (KeyCode.Keypad1) && randomPositionsRange.x > 1)
		{
			randomPositionsRange.x--;
		}
		if (Input.GetKey (KeyCode.Keypad2))
		{
			randomPositionsRange.x++;
		}
		if (Input.GetKey (KeyCode.Keypad4) && randomPositionsRange.y > 1)
		{
			randomPositionsRange.y--;
		}
		if (Input.GetKey (KeyCode.Keypad5))
		{
			randomPositionsRange.y++;
		}
		if (Input.GetKey (KeyCode.Keypad7) && randomPositionsRange.z > 1)
		{
			randomPositionsRange.z--;
		}
		if (Input.GetKey (KeyCode.Keypad8))
		{
			randomPositionsRange.z++;
		}

		if (Input.GetKeyDown (KeyCode.P))
		{
			if (isBuildingRandom)
			{
				Debug.Log ("Just once");
			}
			else
			{
				isBuildingRandom = true;
				if (randomPositionCount > 0)
				{
					for (int i = 0; i < randomPositionCount; i++)
					{
						randomPositions.Add (new Vector3 (Random.Range (-randomPositionsRange.x, randomPositionsRange.x), Random.Range (-randomPositionsRange.y, randomPositionsRange.y), Random.Range (-randomPositionsRange.z, randomPositionsRange.z)));
					}
					StartCoroutine (BuildRandomly ());
				}
				else
				{
					Debug.Log ("not a valid value");
				}

			}
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

	private void SpawnHouse(Vector3 position)
	{
		GameObject newHouse = Instantiate (m_house, position, Quaternion.identity);
		if (!Input.GetKey (KeyCode.LeftShift))
		{
			AddHouse (newHouse.GetComponent<houses> ());
		}
		objectCount++;
	}

	private IEnumerator BuildRandomly()
	{
		yield return new WaitForFixedUpdate ();
		if (randomBuildCounter < rbcTarget)
		{
			randomBuildCounter++;
			SpawnHouse (randomPositions[Random.Range (0,randomPositions.Count)]);
			StartCoroutine (BuildRandomly ());
		}
		else
		{
			Debug.Log ("Done");
		}
	}

	void OnGUI()
	{
		var TextStyle = new GUIStyle ();
		TextStyle.normal.textColor = Color.black;
		GUI.Label (new Rect (5,5,200,80), "count: "+objectCount.ToString()+
			"\nmultiples: "+randomPositionCount.ToString()+
			"\nRangeVector:"+randomPositionsRange.x.ToString ()+" "+randomPositionsRange.y.ToString ()+" "+randomPositionsRange.z.ToString ()+
			"\nlm - add points\nw/a/s/d/mousewheel - camera " +
			"\nf - lights" +
			"\nr - reset",TextStyle);  
//		if (GUI.Button (new Rect (5, 90, 120, 20), "Random Positions"))
//		{
//			Debug.Log ("Random Positions");
//		}
	}

	public void AddHouse(houses h)
	{
		allHouses.Add (h);
	}
}
