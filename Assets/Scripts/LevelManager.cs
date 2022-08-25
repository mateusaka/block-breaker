using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _gameOver;

    public void RestartButton() {
        _gameOver.SetActive(false);

        _player.SetActive(true);
        _ball.SetActive(true);
    }

    private void RestartLevel() {
        _player.SetActive(false);
        _ball.SetActive(false);

        if(PlayerController.Life <= 0) {
            _gameOver.SetActive(true);

            // Export score

            PlayerController.Score = PlayerController.Config.DEFAULT_START_SCORE;
            PlayerController.Life = PlayerController.Config.DEFAULT_START_LIFE;

            return;
        }

        _player.SetActive(true);
        _ball.SetActive(true);
    }

    private void OnEnable() {
        DeathZoneController.OnDeath += RestartLevel;
    }

    private void OnDisable() {
        DeathZoneController.OnDeath -= RestartLevel;
    }
}
