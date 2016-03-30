using UnityEngine;
using System.Collections;
using GameSparks.Api;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using GameSparks.Core;

public class LogInRequest : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void checkConnection()
    {
        GS.GameSparksAvailable = (available) =>
        {
            if (available)
            {
                //SDK is connected
            }
            else
            {
                //SDK is disconnected
            }
        };

GS.GameSparksAuthenticated = (playerId) => {
    //playerId is the authenticated players id

};
        Debug.Log("logging in");
        UserNameLogIn();
    }
    public void UserNameLogIn()
    {
        new AuthenticationRequest()
            .SetPassword("gabs")
            .SetUserName("gabs")
            .Send((response) => {
                string authToken = response.AuthToken;
                string displayName = response.DisplayName;
                bool? newPlayer = response.NewPlayer;
                GSData scriptData = response.ScriptData;
                var switchSummary = response.SwitchSummary;
                string userId = response.UserId;
           
            });
    }
}
