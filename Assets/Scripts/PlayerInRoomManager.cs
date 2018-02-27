using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInRoomManager : Photon.PunBehaviour{

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);

        PhotonNetwork.player.SetTeam(PunTeams.Team.none);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeTeam(string team)
    {
        if (photonView.isMine)
        {
            if (team == "blue")
            {
                PhotonNetwork.player.SetTeam(PunTeams.Team.blue);
                Debug.Log("Set to blue team");
            }
            else if (team == "red")
            {
                PhotonNetwork.player.SetTeam(PunTeams.Team.red);
                Debug.Log("Set to red team");
            }
        }
    }
}
