using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.Events;
using System;

[Serializable]
public class FloatEvent : UnityEvent<float>{}

[Serializable]
public class InputEvent : UnityEvent<float,float>{}

public class Player : NetworkBehaviour
{
        Rigidbody2D rb;
        float inputX;
        float inputY;
        public float speed = 3;
        public int coins;

        public InputEvent OnDirectionChanged;
        
        void Start()
        {
                rb = GetComponent<Rigidbody2D>();
        }
        
        void Update()
        {
                if(isLocalPlayer)
                {
                        inputX = Input.GetAxisRaw("Horizontal");
                        inputY = Input.GetAxisRaw("Vertical");

                        OnDirectionChanged.Invoke(inputX, inputY);

                        rb.velocity = new Vector2(inputX, inputY) * speed;

                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
                
                if(collision.CompareTag("Coin1"))
                {               
                        coins++;
                        MyNetworkManager.spawnedCoins--;
                        Destroy(collision.gameObject);
                }
        }
}