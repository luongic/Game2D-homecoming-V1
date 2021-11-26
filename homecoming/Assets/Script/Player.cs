using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    private void Start(){
        animator = GetComponent<Animator>();
    }
    private void Update(){
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            animator.SetTrigger("hop");
        }
    }
}
