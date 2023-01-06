using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Config")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;
    [SerializeField] GameObject player3;
    [SerializeField] GameObject player4;
    [SerializeField] GameObject gamePath;

    [SerializeField][Range (1, 4)] int numberOfPlayers;

    public GameObject GetPlayer1Prefab() {
        return player1;
    }

    public GameObject GetPlayer2Prefab() {
        return player2;
    }

    public GameObject GetPlayer3Prefab()
    {
        return player3;
    }

    public GameObject GetPlayer4Prefab()
    {
        return player4;
    }

    public List<Transform> GetGamePath() {
        var pathWaypoint = new List<Transform>();
        foreach (Transform child in gamePath.transform) {
            pathWaypoint.Add(child);
        }
        //Debug.Log(pathWaypoint);
        return pathWaypoint;
    }

    public int GetNumberOfPlayers() {
        return numberOfPlayers;
    }


}


