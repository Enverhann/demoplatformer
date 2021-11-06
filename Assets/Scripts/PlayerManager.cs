//couldn't make it work with reset mechanic/ai colliding with each other
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject cp;
    public GameObject checkpointHolder;
    public GameObject[] Players;
    public Transform[] CheckpointPositions;
    public GameObject[] CheckpointForEachPlayer;
    private int totalPlayers;
    private int totalCheckpoints;
    public Text positionText;

    // Start is called before the first frame update
    void Start()
    {
        totalPlayers = Players.Length;
        totalCheckpoints = checkpointHolder.transform.childCount;

        SetCheckpoints();
        SetPlayerPosition();
    }

    void SetCheckpoints()
    {
        CheckpointPositions = new Transform[totalCheckpoints];
        for(int i=0; i < totalCheckpoints; i++)
        {
            CheckpointPositions[i] = checkpointHolder.transform.GetChild(i).transform;
        }

        CheckpointForEachPlayer = new GameObject[totalPlayers];

        for (int i =0; i < totalPlayers; i++)
        {
            CheckpointForEachPlayer[i] = Instantiate(cp, CheckpointPositions[0].position, CheckpointPositions[0].rotation);
            CheckpointForEachPlayer[i].name = "cp" + i;
            CheckpointForEachPlayer[i].layer = 11 + i;
        }
    }

    void SetPlayerPosition()
    {
        for(int i =0; i < totalPlayers; i++)
        {
            Players[i].GetComponent<PlayerCpManager>().playerPosition = i + 1;
            Players[i].GetComponent<PlayerCpManager>().playerNumber = i;
        }
        positionText.text = "Pos" + Players[0].GetComponent<PlayerCpManager>().playerPosition + "/" + totalPlayers;
    }

    public void PlayerCollectedCp(int playerNumber, int cpNumber)
    {
        CheckpointForEachPlayer[playerNumber].transform.position = CheckpointPositions[cpNumber].transform.position;
        CheckpointForEachPlayer[playerNumber].transform.rotation = CheckpointPositions[cpNumber].transform.rotation;

        ComparePositions(playerNumber);
    }

    void ComparePositions(int playerNumber)
    {
        //if player isn't at first place
        if (Players[playerNumber].GetComponent<PlayerCpManager>().playerPosition > 1)
        {
            GameObject currentPlayer = Players[playerNumber];
            int currentPlayerPos = currentPlayer.GetComponent<PlayerCpManager>().playerPosition;
            int currentPlayerCp = currentPlayer.GetComponent<PlayerCpManager>().cpCrossed;

            GameObject playerInFront = null;
            int playerInFrontPos = 0;
            int playerInFrontCp = 0;

            for(int i =0; i < totalPlayers; i++)
            {
                if(Players[i].GetComponent<PlayerCpManager>().playerPosition == currentPlayerPos - 1)//player in front
                {
                    playerInFront = Players[i];
                    playerInFrontCp = playerInFront.GetComponent<PlayerCpManager>().cpCrossed;
                    playerInFrontPos = playerInFront.GetComponent<PlayerCpManager>().playerPosition;
                    break;
                }
            }
            //this player cross player in front
            if (currentPlayerCp > playerInFrontCp)
            {
                currentPlayer.GetComponent<PlayerCpManager>().playerPosition = currentPlayerPos - 1;
                playerInFront.GetComponent<PlayerCpManager>().playerPosition = playerInFrontPos + 1;
            }
            positionText.text = "Pos" + Players[0].GetComponent<PlayerCpManager>().playerPosition + "/" + totalPlayers;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
