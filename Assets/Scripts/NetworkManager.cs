using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkManager : Photon.PunBehaviour {

    public static NetworkManager instance = null;

    private string _gameVersion = "1";
    //private GameLobbyManager gamelobbyManager;

    private void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;
    }

    // Use this for initialization
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(this);
        }

 
        PhotonNetwork.ConnectUsingSettings(_gameVersion);
       

        Debug.Log("NetworkManager start ");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateRoom(string name, int maxPlayers)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = (byte)maxPlayers;

        PhotonNetwork.CreateRoom(name, roomOptions, null);

        Debug.Log("CreateRoom in NetworkManager is called");
    }

    public void JoinRoom(string name)
    {
        PhotonNetwork.JoinRoom(name);

        Debug.Log("JoinRoom in NetworkManager is called");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster is called");
    }

    public override void OnCreatedRoom()
    {    
        Debug.Log("OnCreatedRoom is called");
    }

    public override void OnJoinedRoom()
    {
        //init Playerpref??
        
        //LoadScene
        SceneManager.LoadScene("CharactersSelectRoom");
        PhotonNetwork.Instantiate("PlayerInRoom", new Vector3(0, 0, 0), Quaternion.identity, 0);

        Debug.Log("OnJoinedRoom is called");
    }

    public override void OnPhotonCreateRoomFailed(object[] codeAndMsg)
    {
        //show error
        if (SceneManager.GetActiveScene().name == "GameLobby")
            GameObject.Find("CreateFailureWarn").GetComponent<Text>().enabled = true;

        Debug.Log("OnPhotonCreatedRoomFailed is called");
    }

    public override void OnPhotonJoinRoomFailed(object[] codeAndMsg)
    {
        //show error
        if (SceneManager.GetActiveScene().name == "GameLobby")
            GameObject.Find("JoinFailureWarn").GetComponent<Text>().enabled = true;

        Debug.Log("OnPhotonJoinRoomFailed is called");
    }
}
