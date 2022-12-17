using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations : MonoBehaviour
{
    Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ChangeAnimation(float inputX, float inputY){

        if(inputX != 0) {
            anim.Play("walkHorizontal");
            transform.localScale = new Vector3(-inputX, 1, 1);
        }

        else if(inputY > 0) {
            anim.Play("walkUp");
        }

        else if(inputY < 0) {
            anim.Play("walkDown");
        }

        else {
            anim.Play("idle");
        }

    }
}
