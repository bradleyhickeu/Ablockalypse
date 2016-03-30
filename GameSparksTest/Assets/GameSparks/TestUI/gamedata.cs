using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//public class gamedata  {

[System.Serializable]
public class gamedata {

	public List<gameItem> gameItems = new List<gameItem>();
}


[System.Serializable]
public class gameItem{
	
	public int tileID;
	public int itemType;
}

	



