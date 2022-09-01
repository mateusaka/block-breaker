using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public static class Config {
        public const int DEFAULT_START_LEVEL = 5;
        public const int DEFAULT_START_SCORE = 0;
        public const int DEFAULT_START_LIFE = 3;
    }

    [SerializeField] private Rigidbody2D _playerRB;
    /* [SerializeField] private float _leftBound;
    [SerializeField] private float _rightBound; */
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _defaultScale;
    [SerializeField] private float _sensitivity;

    private Vector2 _playerPosition;
    private bool _enableUpdate;

    // Stats
    public static int Level = Config.DEFAULT_START_LEVEL;
    public static int Score = Config.DEFAULT_START_SCORE;
    public static int Life = Config.DEFAULT_START_LIFE;

    // Events
    public static Action<int> OnScoreChanged;
    public static Action<int> OnLifeChanged;
    public static Action<int> OnLevelChanged;

    private void PlayerInput() {
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            //transform.Translate(Vector2.left * _sensitivity * Time.deltaTime);
            _playerRB.velocity = Vector2.left * _sensitivity;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            //transform.Translate(Vector2.right * _sensitivity * Time.deltaTime);
            _playerRB.velocity = Vector2.right * _sensitivity;
        }
        else {
            _playerRB.velocity = Vector3.zero;
        }
    }

    private void SetStartEvents() {
        if(OnScoreChanged != null) {
            OnScoreChanged(Score);
        }

        if(OnLifeChanged != null) {
            OnLifeChanged(Life);
        }

        if(OnLevelChanged != null) {
            OnLevelChanged(Level);
        }
    }

    private void Update() {
        if(_enableUpdate) {
            PlayerInput();
        }
    }

    private IEnumerator EnablePlayer() {
        _enableUpdate = false;
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        _enableUpdate = true;
    }

    private void OnEnable() {
        transform.position = _startPosition;
        transform.localScale = _defaultScale;

        SetStartEvents();

        StartCoroutine(EnablePlayer());
    }

    private void Start() {
        SetStartEvents();
    }
}
