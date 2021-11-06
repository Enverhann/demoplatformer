//couldn't make it work with reset mechanic/ai colliding with each other
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCpManager : MonoBehaviour
{
    public int cpCrossed;
    public int playerNumber;
    public int playerPosition;
    public PlayerManager playerManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cp"))
        {
            cpCrossed += 1;
            playerManager.PlayerCollectedCp(playerNumber, cpCrossed);
        }
    }
}   
