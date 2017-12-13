using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainTwo : MonoBehaviour {

	// This script is for random generated structures only
	// no mouse input to create
	// all points will be spawned on this mainScript

	public mainTwo m_main;
	public GameObject m_carrier;
	public int objectCount;
	public Camera m_Camera;

	//Material Change
//	public Material h_Material;
	public Material p_Material;
	private int activeMaterialSet;

	//Random Creation
	public Vector3 newPos;
	private int randomBuildCounter;
	public int rbcTarget;
	private bool isBuildingRandom;
	public int randomPositionCount;
	public List<Vector3> randomPositions = new List<Vector3>();
	public Vector3 randomPositionsRange;

	//Pause function
	public bool isPaused;

	void Start()
	{
		if (m_main == null)
		{
			m_main = this.gameObject.GetComponent<mainTwo> ();
		}
	}

	void Update () 
	{

		if (Input.GetKeyUp (KeyCode.R))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene().name);
		}

		if (Input.GetKey (KeyCode.Period))
		{
			randomPositionCount++;
		}
		if (Input.GetKey (KeyCode.Comma) && randomPositionCount > 0)
		{
			randomPositionCount--;
		}

		if (Input.GetKey (KeyCode.Alpha1) && randomPositionsRange.x > 1)
		{
			randomPositionsRange.x--;
		}
		if (Input.GetKey (KeyCode.Alpha2))
		{
			randomPositionsRange.x++;
		}
		if (Input.GetKey (KeyCode.Alpha3) && randomPositionsRange.y > 1)
		{
			randomPositionsRange.y--;
		}
		if (Input.GetKey (KeyCode.Alpha4))
		{
			randomPositionsRange.y++;
		}
		if (Input.GetKey (KeyCode.Alpha5) && randomPositionsRange.z > 1)
		{
			randomPositionsRange.z--;
		}
		if (Input.GetKey (KeyCode.Alpha6))
		{
			randomPositionsRange.z++;
		}
		if (Input.GetKey (KeyCode.Alpha7) && rbcTarget > 100)
		{
			rbcTarget -= 20;
		}
		if (Input.GetKey (KeyCode.Alpha8))
		{
			rbcTarget += 20;
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
				p_Material.color = Color.gray;
				m_Camera.backgroundColor = Color.white;
				break;
			case 1:
				p_Material.color = Color.white;
				m_Camera.backgroundColor = Color.black;
				break;
			case 2:
				p_Material.color = Color.black;
				m_Camera.backgroundColor = Color.gray;
				activeMaterialSet = -1;
				break;

			}
		}

		if (Input.GetKeyDown (KeyCode.T))
		{
			if (isPaused)
			{
				isPaused = false;
			}
			else
			{
				isPaused = true;
			}
		}
	}



	private IEnumerator BuildRandomly()
	{
		yield return new WaitForFixedUpdate ();
		if (randomBuildCounter < rbcTarget)
		{
			randomBuildCounter++;
			GameObject spawn = Instantiate (m_carrier, transform.position, Quaternion.identity, gameObject.transform);
			Vector3 position = randomPositions [Random.Range (0, randomPositions.Count)];
			carrierTwo c_Two = spawn.GetComponent<carrierTwo> ();
			c_Two.Setup (position,m_main);
			objectCount++;
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
		GUI.Label (new Rect (5,5,200,80), "count: "+objectCount.ToString()+"/"+rbcTarget.ToString ()+
			"\ntargets: "+randomPositionCount.ToString()+
			"\nRangeVector:"+randomPositionsRange.x.ToString ()+" "+randomPositionsRange.y.ToString ()+" "+randomPositionsRange.z.ToString ()+
			"\nlm - add points\nw/a/s/d/mousewheel - camera " +
			"\nf - lights" +
			"\nr - reset",TextStyle);  
		if (!isBuildingRandom)
		{
			GUI.Label (new Rect(Screen.width/2f-100f,Screen.height/2f-40f,200,80),"press p to start" +
				"\ncomma/period - change position count"+
				"\n1/2/3/4/5/6 - change size"+
				"\n7/8 - change count",TextStyle);
		}
	}

}
