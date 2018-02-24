using UnityEngine;
using UnityEngine.SceneManagement;

public class MeunManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameLobbyButton()
    {
        SceneManager.LoadScene("GameLobby");
    }
}
