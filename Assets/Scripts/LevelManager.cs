using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;

    private void RestartLevel() {
        _player.SetActive(false);
        _ball.SetActive(false);

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
