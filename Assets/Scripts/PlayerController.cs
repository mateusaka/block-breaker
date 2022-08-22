using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private float _sensitivity;

    private Vector2 _playerPosition;

    private void PlayerInput() {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            _playerPosition = Vector2.left;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            _playerPosition = Vector2.right;
        }
        else {
            _playerPosition = Vector2.zero;
        }
    }

    private void PlayerMovement() {
        _playerRB.velocity = Vector2.right * _playerPosition * _sensitivity;
    }

    private void Update() {
        PlayerInput();
    }

    private void FixedUpdate() {
        PlayerMovement();
    }
}
