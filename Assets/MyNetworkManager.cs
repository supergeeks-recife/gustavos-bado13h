using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class MyNetworkManager : NetworkManager
{
        public Transform player1SpawnPoint;
        public Transform player2SpawnPoint;
        
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
                Transform startPoint;
                
                if(numPlayers == 0)
                {
                        startPoint = player1SpawnPoint;
                }
                else
                {
                        startPoint = player2SpawnPoint;
                }
                
                GameObject new_player =
                        Instantiate(playerPrefab, startPoint.position, startPoint.rotation);


                NetworkServer.AddPlayerForConnection(conn, new_player);
        }
}

