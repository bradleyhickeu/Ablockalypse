using UnityEngine;
using System.Collections;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

public class Grid : MonoBehaviour {
	public GameObject tile;
	public gamedata myData = new gamedata();
	private string tempData;
	//public float tileWidth;
	//public float tileHeight;
	// Use this for initialization
	void Start () {
		DrawGrid ();

	}

	// Update is called once per frame
	void Update () {
	
	}
	public void AddItemDetails(int tileID, int itemType ){

		gameItem gi = new gameItem ();
		gi.itemType = itemType;
		gi.tileID = tileID;
		myData.gameItems.Add (gi);
		for (int i = 0; i < myData.gameItems.Count; i++) {
			Debug.Log ("itemtype: " + myData.gameItems [i].itemType +" id: "+ myData.gameItems [i].tileID );
		}

	
	}

	void DrawGrid(){
		for (int i = 0; i < 10; i++) 
		{

			for (int j = 0; j < 10; j++) 
			{
				Instantiate (tile, new Vector3(-4.5f+j,0,-4.5f+i), Quaternion.identity);

			}
		}
	}



	public void DisplayList(){
		for (int i = 0; i < myData.gameItems.Count; i++) {
			Debug.Log ("itemtype: " + myData.gameItems [i].itemType +" id: "+ myData.gameItems [i].tileID );
		}
	}



	public void SaveData()
	{
		//Debug.Log ("saving..");
		tempData = JsonUtility.ToJson (myData);
		Debug.Log (tempData);
		//PlayerPrefs.SetString ("mydata", tempData);
		new LogEventRequest ()
			.SetEventKey ("EVT_SAVE_STATE")
				.SetEventAttribute ("ATTR_GAME_STATE", tempData)
				.Send (handle_log_event_response);

	}




	public void  LoadData()
	{
		//string data = PlayerPrefs.GetString ("mydata");
		new LogEventRequest ()
			.SetEventKey ("EVT_LOAD_STATE")
				.Send (handle_load_state_response);
	


	}




	private void handle_load_state_response(LogEventResponse response)
	{
		tempData = response.ScriptData.GetString ("result"); 
		myData = JsonUtility.FromJson<gamedata> (tempData);
		
		for (int i = 0; i < myData.gameItems.Count; i++) {
			Debug.Log ("creating item of type " + myData.gameItems [i].itemType + " at " + myData.gameItems [i].tileID);
			CreateItem (myData.gameItems [i].tileID, myData.gameItems [i].itemType);
		}
		Debug.Log ("loading.." + tempData);
	}


	private void handle_log_event_response(LogEventResponse response)
	{
		//check if this appropriate 
		Debug.Log ("handlelog" + tempData);

	}


	public void CreateItem(int iID,int iType )
	{
		
		Debug.Log ("SECOND creating item of type " + iType + " at " + iID);
		//create a reference point to create specific items to desired tile by matching ID's
		GameObject CITile = GameObject.Find ("Tile #" + iID);
		//Add item of type iType to tile of id iID
		CITile.GetComponent<Tile>().AddItem(iID, iType, true);

	}

}
