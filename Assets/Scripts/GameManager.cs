using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Photon.PunBehaviour {

	// Use this for initialization
	void Start () {
            //string characterName = GameObject.Find("PlayerInRoom(Clone)").GetComponent<PlayerInRoomManager>().selectedCharacter.Replace("Idel", "");
            //PhotonNetwork.Instantiate(characterName, new Vector3(12, 0, 0), Quaternion.identity, 0);

       // GameObject[] playersList = GameObject.FindGameObjectsWithTag("Player");
/*
        foreach(GameObject player in playersList)
        {
            string characterName = player.GetComponent<PlayerInRoomManager>().selectedCharacter.Replace("Idel", "");
            PhotonNetwork.Instantiate(characterName, new Vector3(12, 0, 0), Quaternion.identity, 0);
        }
*/        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
