using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;
using GameSparks.Core;

public class HighScoreUpload : MonoBehaviour {

	// Use this for initialization
	void Start () {
 

    }

    // Update is called once per frame
    void Update () {
	
	}

   public void UploadToHS()
    {
        new LogEventRequest()
         .SetEventAttribute("@class", ".LogEventRequest")
             .SetEventAttribute("eventKey", "SCORE_EVT")
             .SetEventAttribute("SCORE_ATTR", 400)
             .Send((response) => {
                 GSData scriptData = response.ScriptData;
                 Debug.Log(scriptData);
             });
    }

    public void ViewHS()
    {
        new LogEventRequest()
    .SetEventAttribute("@class", ".LeaderboardDataRequest")
        .SetEventAttribute("entryCount", "5")
        .SetEventAttribute("includeFirst", 0)
        .SetEventAttribute("includeLast", 0)
        .SetEventAttribute("leaderboardShortCode", "HIGH_SCORE_LB")
                .Send((response) => {
                    GSData scriptData = response.ScriptData;
                    Debug.Log(scriptData);
                });

    }

}
