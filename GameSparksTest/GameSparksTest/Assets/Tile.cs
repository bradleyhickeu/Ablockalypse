using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tile : MonoBehaviour {
	private int ID;
	private static int numTiles = 0;
	//private enum eObjectSpawn {eSphere, eSquare};
	private string SelectedItem;
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
		Debug.Log("you clicked tile:" + ID);
		if (SelectedItem == "sphere"){
			Instantiate (sphereToPlace, this.transform.position, Quaternion.identity);
		//GameObject GridObj = GameObject.FindGameObjectWithTag ("Grid");
		//GameObject obj = instantiate(Grid.GetComponent<Grid>
		}
		if (SelectedItem == "square") {
			Instantiate (squareToPlace, this.transform.position, Quaternion.identity);
		}
	}

	public void changeObjectSphere()
	{
		Debug.Log ("changetosphere");
		SelectedItem = "sphere";
	}

	public void changeObjectSquare()
	{
		Debug.Log ("changetosquare");
		SelectedItem = "square";
	}
}
