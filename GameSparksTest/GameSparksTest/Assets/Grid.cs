using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {
	public GameObject tile;
	//public float tileWidth;
	//public float tileHeight;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; i++) 
		{
			
			for (int j = 0; j < 10; j++) 
			{
				Instantiate (tile, new Vector3(-4.5f+j,0,-4.5f+i), Quaternion.identity);
			
			}
		}

	}

	// Update is called once per frame
	void Update () {
	
	}

}
