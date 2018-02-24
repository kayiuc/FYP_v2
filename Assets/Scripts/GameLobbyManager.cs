using UnityEngine;
using UnityEngine.UI;

public class GameLobbyManager : MonoBehaviour {

    public GameObject CreateRoomPanel;
    public GameObject JoinRoomPanel;
    public InputField c_roomName;
    public InputField j_roomName;
    public Dropdown maxPlayersDropDown;

    private byte[] MaxPlayersOptions = { 2, 4 };
	// Use this for initialization
	void Start () {
        DisableCreateRoomPanel();
        DisableJoinRoomPanel();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Create()
    {
        NetworkManager.instance.CreateRoom(c_roomName.text, MaxPlayersOptions[maxPlayersDropDown.value]);
    }

    public void Join()
    {
        NetworkManager.instance.JoinRoom(j_roomName.text);
    }

    public void Cancel()
    {
        DisableCreateRoomPanel();
        DisableJoinRoomPanel();
    }

    public void EnableCreateRoomPanel()
    {
        CreateRoomPanel.SetActive(true);
    }

    public void DisableCreateRoomPanel()
    {
        CreateRoomPanel.SetActive(false);
    }

    public void EnableJoinRoomPanel()
    {
        JoinRoomPanel.SetActive(true);
    }

    public void DisableJoinRoomPanel()
    {
        JoinRoomPanel.SetActive(false);
    }
}
