using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLobbyManager : MonoBehaviour {

    public GameObject CreateRoomPanel;
    public GameObject JoinRoomPanel;
    public InputField c_roomName;
    public InputField j_roomName;
    public Dropdown maxPlayersDropDown;
    public Text CreateFailureWarn;
    public Text JoinFailureWarn;

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

    public void EnableCreateRoomPanel()
    {
        CreateRoomPanel.SetActive(true);
    }

    public void DisableCreateRoomPanel()
    {
        CreateRoomPanel.SetActive(false);
        DisableCreateFailureWarn();
    }


    public void EnableJoinRoomPanel()
    {
        JoinRoomPanel.SetActive(true);
    }

    public void DisableJoinRoomPanel()
    {
        JoinRoomPanel.SetActive(false);
        DisableJoinFailureWarn();
    }

    public void DisableCreateFailureWarn()
    {
        CreateFailureWarn.enabled = false;
    }

    public void DisableJoinFailureWarn()
    {
        JoinFailureWarn.enabled = false;
    }
}
