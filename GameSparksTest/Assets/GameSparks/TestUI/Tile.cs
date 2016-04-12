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
	//public GameObject sphereDetails;
	private GameObject controller;
	void Start () {
		SetID (numTiles++);
		controller = GameObject.Find("GameControl");



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
		AddItem (ID, ObjectType, false);
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent <Grid>().AddItemDetails (ID, ObjectType);
	}

	public void AddItem(int tileID, int i_objType, bool LoadState){
		Debug.Log("you clicked tile:" + ID);

		//object for sphere
		if (i_objType == 1){
			//check and compare cost of object to current resource amounts
			if (!LoadState && sphereToPlace.GetComponent<GenerateResources> ().CostFood <= controller.GetComponent<GameControl> ().returnFood () && sphereToPlace.GetComponent<GenerateResources> ().CostWater <= controller.GetComponent<GameControl> ().returnWater () && sphereToPlace.GetComponent<GenerateResources> ().CostBlocks <= controller.GetComponent<GameControl> ().returnBlocks ()) {
				//reduce resources by cost of object
				controller.GetComponent<GameControl> ().ReduceFood (sphereToPlace.GetComponent<GenerateResources> ().CostFood);
				controller.GetComponent<GameControl> ().ReduceWater (sphereToPlace.GetComponent<GenerateResources> ().CostWater);
				controller.GetComponent<GameControl> ().ReduceBlocks (sphereToPlace.GetComponent<GenerateResources> ().CostBlocks);

				//create the new object at tile location
				GameObject newSphere = Instantiate (sphereToPlace, GameObject.Find ("Tile #" + tileID).transform.position, Quaternion.identity)as GameObject;
				//attach the object to the parent tile
				newSphere.transform.parent = transform;
				//check if loading from server
			} else if (LoadState) {
				GameObject newSphere = Instantiate (sphereToPlace, GameObject.Find ("Tile #" + tileID).transform.position, Quaternion.identity)as GameObject;
				//attach the object to the parent tile
				newSphere.transform.parent = transform;
			}


		}
		if (i_objType == 2){
			//check and compare cost of object to current resource amounts
			if (!LoadState && squareToPlace.GetComponent<GenerateResources> ().CostFood <= controller.GetComponent<GameControl> ().returnFood () && squareToPlace.GetComponent<GenerateResources> ().CostWater <= controller.GetComponent<GameControl> ().returnWater () && squareToPlace.GetComponent<GenerateResources> ().CostBlocks <= controller.GetComponent<GameControl> ().returnBlocks ()) {
				//reduce resources by cost of object
				controller.GetComponent<GameControl> ().ReduceFood (squareToPlace.GetComponent<GenerateResources> ().CostFood);
				controller.GetComponent<GameControl> ().ReduceWater (squareToPlace.GetComponent<GenerateResources> ().CostWater);
				controller.GetComponent<GameControl> ().ReduceBlocks (squareToPlace.GetComponent<GenerateResources> ().CostBlocks);

				//create the new object at tile location
				GameObject newSquare = Instantiate (squareToPlace, GameObject.Find ("Tile #" + tileID).transform.position, Quaternion.identity)as GameObject;
				//attach the object to the parent tile
				newSquare.transform.parent = transform;
				//check if loading from server
			} else if (LoadState){
				//create the new object at tile location
				GameObject newSquare = Instantiate (squareToPlace, GameObject.Find ("Tile #" + tileID).transform.position, Quaternion.identity)as GameObject;
				//attach the object to the parent tile
				newSquare.transform.parent = transform;
			}


	
		}

	}

	public void ChangeToSphere(){
		ObjectType = 1;
	}
	public void ChangeToSquare(){
		ObjectType = 2;
	}
}
