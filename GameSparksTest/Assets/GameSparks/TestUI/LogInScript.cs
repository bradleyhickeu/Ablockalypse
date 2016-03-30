using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using UnityEngine.SceneManagement;

public class LogInScript : MonoBehaviour {
	public Text statusText;
	// Use this for initialization
	void Start () {
		//GS.Initialise(new pla
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GS_Auth_User(){
		new AuthenticationRequest()
			.SetPassword("gabs")
			.SetUserName("gabs")
			.Send((response)=>{
				statusText.text="username:" + response.DisplayName;
			});
	}

	public void GS_Auth_User_Next_Scene(){
		new AuthenticationRequest()
			.SetPassword("gabs")
			.SetUserName("gabs")
			.Send((response)=>{
				statusText.text="username:" + response.DisplayName;
				NextScene ();
			});
		
	}

	public void NextScene(){
		if (NiceSceneTransition.instance != null) {
			NiceSceneTransition.instance.LoadScene ("TileScene");
		/*} else {
			SceneManager.LoadScene ("TileScene");*/
		}
	}
}
