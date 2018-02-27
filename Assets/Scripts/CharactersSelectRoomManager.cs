using UnityEngine;
using UnityEngine.UI;

public class CharactersSelectRoomManager : MonoBehaviour {

    const int TEAM_LEN = 2;

    public Text[] blueTeamTextList;
    public Text[] redTeamTextList;
    public Button redTeamButton;
    public Button blueTeamButton;

    private GameObject Lich;
    private GameObject Grunt;
    private GameObject Soldier;
    private GameObject Golem;
    private GameObject currentSelection;

	// Use this for initialization
	void Start () {
        Lich = GameObject.Find("Lich");
        Grunt = GameObject.Find("Grunt");
        Soldier = GameObject.Find("Soldier");
        Golem = GameObject.Find("Golem");
        
        Grunt.SetActive(false);
        Soldier.SetActive(false);
        Golem.SetActive(false);
/*
        for(int i = 0; i < TEAM_LEN; i++)
        {
            redTeamTextList[i].enabled = false;
            blueTeamTextList[i].enabled = false;
        }
*/
        currentSelection = Lich;

        Debug.Log(PhotonNetwork.room.MaxPlayers);
	}
	
	// Update is called once per frame
	void Update () {
        int redTeamIndex = 0, redTeamCount = PunTeams.PlayersPerTeam[PunTeams.Team.red].Count;
        int blueTeamIndex = 0, blueTeamCount = PunTeams.PlayersPerTeam[PunTeams.Team.blue].Count;
        int maxPlayers = PhotonNetwork.room.MaxPlayers;
        int playerCount = PhotonNetwork.room.PlayerCount;

        if (redTeamCount == maxPlayers / 2)
            redTeamButton.enabled = false;
        else
            redTeamButton.enabled = true;

        if (blueTeamCount == maxPlayers / 2)
            blueTeamButton.enabled = false;
        else
            blueTeamButton.enabled = true;

        for(int i = 0; i < TEAM_LEN; i++)
        {
            redTeamTextList[i].text = "";
            blueTeamTextList[i].text = "";
        }

        if (PhotonNetwork.inRoom)
        {
            if (PhotonNetwork.player.GetTeam() == PunTeams.Team.blue)
                blueTeamTextList[blueTeamIndex++].text = PhotonNetwork.player.ID.ToString();

            if (PhotonNetwork.player.GetTeam() == PunTeams.Team.red)
                redTeamTextList[redTeamIndex++].text = PhotonNetwork.player.ID.ToString();

            for (int i = 0; i < playerCount - 1; i++)
            {
                
                if (PhotonNetwork.otherPlayers[i].GetTeam() == PunTeams.Team.blue)
                    blueTeamTextList[blueTeamIndex++].text = PhotonNetwork.otherPlayers[i].ID.ToString();

                if (PhotonNetwork.otherPlayers[i].GetTeam() == PunTeams.Team.red)
                    redTeamTextList[redTeamIndex].text = PhotonNetwork.otherPlayers[i].ID.ToString();
            }
        }
	}

    public void SelectLich()
    {
        currentSelection.SetActive(false);
        Lich.SetActive(true);
        currentSelection = Lich;
    }

    public void SelectGrunt()
    {
        currentSelection.SetActive(false);
        Grunt.SetActive(true);
        currentSelection = Grunt;
    }

    public void SelectSoldier()
    {
        currentSelection.SetActive(false);
        Soldier.SetActive(true);
        currentSelection = Soldier;
    }

    public void SelectGolem()
    {
        currentSelection.SetActive(false);
        Golem.SetActive(true);
        currentSelection = Golem;
    }

    public void ChangeToBlueTeam()
    {
        PlayerInRoomManager playerInRoom = GameObject.Find("PlayerInRoom(Clone)").GetComponent<PlayerInRoomManager>();
        playerInRoom.ChangeTeam("blue");
    }

    public void ChangeToRedTeam()
    {
        PlayerInRoomManager playerInRoom = GameObject.Find("PlayerInRoom(Clone)").GetComponent<PlayerInRoomManager>();
        playerInRoom.ChangeTeam("red");
    }
}
