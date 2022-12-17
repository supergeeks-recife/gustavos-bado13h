using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class MyNetworkManager : NetworkManager
{
        public Transform player1SpawnPoint;
        public Transform player2SpawnPoint;

        public List<Transform> coinSpawnPoint;
        public int maxCoinInGame = 2;
        public static int spawnedCoins = 0;

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
                        InvokeRepeating("SpawnCoin", 2, 2);
                }
                
                GameObject new_player =
                        Instantiate(playerPrefab, startPoint.position, startPoint.rotation);


                NetworkServer.AddPlayerForConnection(conn, new_player);
        }
        
     
        public void SpawnCoin()
        {
                if(spawnedCoins < maxCoinInGame)
                {
                        Vector3 local =
                                coinSpawnPoint[Random.Range(0, coinSpawnPoint.Count)].position;
                
                        GameObject new_coin = Instantiate(
                                spawnPrefabs.Find(prefab => prefab.name == "Coin"),
                                local, transform.rotation);
                        
                        NetworkServer.Spawn(new_coin);
                        spawnedCoins++;
                }
        }

        


}

