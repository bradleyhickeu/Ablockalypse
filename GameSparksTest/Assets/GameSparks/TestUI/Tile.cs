using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tile : MonoBehaviour {
	private int ID;
	private static int numTiles = 0;
	//private string eObjectSpawn = "eSphere";
	static int ObjectType = 2;
	public GameObject sphereToPlace;
	public GameObject squareToPlace;
	// Use this for initialization
	void Start () {
		SetID (numTiles++);

	}

	public void SetID(int id){
		
		ID = id;
		Debug.Log ("tile with id " + id);
		GetComponentInChildren<TextMesh>().text = id.ToString();
		this.name = "Tile #" + ID;

	}
	// Update is called once per frame
	void Update () {

	}
	public void OnMouseDown()
	{
		AddItem (ID, ObjectType);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent <Grid>().AddItemDetails (ID, ObjectType);
	}

	public void AddItem(int tileID, int i_objType){
		Debug.Log("you clicked tile:" + ID);

		if (i_objType == 1){
			GameObject newSphere = Instantiate (sphereToPlace, GameObject.Find ("Tile #" + tileID).transform.position, Quaternion.identity)as GameObject;
			newSphere.transform.parent = transform;

		}
		if (i_objType == 2){
			GameObject newSquare = Instantiate (squareToPlace, GameObject.Find ("Tile #" + tileID).transform.position, Quaternion.identity)as GameObject;
			newSquare.transform.parent = transform;

	
		}

	}

	public void ChangeToSphere(){
		ObjectType = 1;
	}
	public void ChangeToSquare(){
		ObjectType = 2;
	}
}
