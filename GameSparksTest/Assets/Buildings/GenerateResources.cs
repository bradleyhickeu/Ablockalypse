using UnityEngine;
using System.Collections;

public class GenerateResources : MonoBehaviour {
	private GameObject controller;
	public int CostFood;
	public int CostWater;
	public int CostBlocks;

	public int BlockGenAmount;
	public int FoodGenAmount;
	public int WaterGenAmount;
	public float GenInterval =10f;
	// Use this for initialization
	void Start () {
		controller = GameObject.Find("GameControl");
		Debug.Log("invokerpeating");
		StartCoroutine("increaseResource");
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator increaseResource(){
		while (true) {
			
			Debug.Log ("increase blocks");

			yield return new WaitForSeconds (GenInterval);

			int blockResourceAmount = BlockGenAmount;
			int foodResourceAmount = FoodGenAmount;
			int waterResourceAmount = WaterGenAmount;

			controller.GetComponent<GameControl> ().ChangeBlocks (blockResourceAmount);
			controller.GetComponent<GameControl> ().ChangeFood (foodResourceAmount);
			controller.GetComponent<GameControl> ().ChangeWater (waterResourceAmount);
		}
	}

}
