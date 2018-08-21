using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Animator _animator;
    private int A = 1;

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "Player_1(Clone)")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                _animator.SetBool("Turn_Left", true);
                _animator.SetBool("Turn_Right", false);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                _animator.SetBool("Turn_Left", false);
                _animator.SetBool("Turn_Right", false);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                _animator.SetBool("Turn_Right", true);
                _animator.SetBool("Turn_Left", false);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                _animator.SetBool("Turn_Right", false);
                _animator.SetBool("Turn_Left", false);
            }
        }

        /*  ----------------------------------------------------- */
        if (this.gameObject.name == "Player_2(Clone)")
        {
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                _animator.SetBool("Turn_Left", true);
                _animator.SetBool("Turn_Right", false);
            }
            if (Input.GetKeyUp(KeyCode.Keypad4))
            {
                _animator.SetBool("Turn_Left", false);
                _animator.SetBool("Turn_Right", false);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                _animator.SetBool("Turn_Right", true);
                _animator.SetBool("Turn_Left", false);
            }
            if (Input.GetKeyUp(KeyCode.Keypad6))
            {
                _animator.SetBool("Turn_Right", false);
                _animator.SetBool("Turn_Left", false);
            }
        }
    }
}
