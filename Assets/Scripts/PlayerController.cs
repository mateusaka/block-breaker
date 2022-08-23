using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _leftBound;
    [SerializeField] private float _rightBound;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _sensitivity;

    private Vector2 _playerPosition;

    // Stats
    public static int Score = 0;
    public static int Life = 3;

    // Events
    public static Action<int> OnScoreChanged;
    public static Action<int> OnLifeChanged;

    private void PlayerInput() {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x > _leftBound) {
            transform.Translate(Vector2.left * _sensitivity * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x < _rightBound) {
            transform.Translate(Vector2.right * _sensitivity * Time.deltaTime);
        }
    }

    private void Update() {
        PlayerInput();
    }

    private void OnEnable() {
        transform.position = _startPosition;

        if(OnScoreChanged != null) {
            OnScoreChanged(Score);
        }

        if(OnLifeChanged != null) {
            OnLifeChanged(Life);
        }
    }
}
