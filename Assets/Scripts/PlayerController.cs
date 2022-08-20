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
        if(_playerPosition != Vector2.zero) {
            _playerRB.MovePosition(_playerRB.position + _playerPosition * (_sensitivity * Time.fixedDeltaTime));
        }
    }

    private void Update() {
        PlayerInput();
    }

    private void FixedUpdate() {
        PlayerMovement();
    }
}
