using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;
using GameSparks.Platforms;

public class SaveStateAccess : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

public void GS_Post_Save_State_Event()
{
	new LogEventRequest()
		.SetEventKey("EVT_SAVE_STATE")
		.SetEventAttribute("ATTR_GAME_STATE","1,2,3")
		.Send(handle_log_event_response);	
}


private void handle_log_event_response(LogEventResponse response)
{
	//stuff goes here…		
}

public void GS_Post_Load_State_Event()
{
	new LogEventRequest()
		.SetEventKey("EVT_LOAD_STATE")
		.Send(handle_load_state_response);

}

private void handle_load_state_response(LogEventResponse response)
{
	Debug.Log( response.ScriptData.GetString("result"));
}
}