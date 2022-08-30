using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] private List<GameObject> _blocks;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _gameOver;

    public static Action OnBlockDestroyed;

    private void ScoreExport(int score) {
        string path = Application.persistentDataPath + "/score.txt";
        Debug.Log(path);
        
        if(!File.Exists(path)) {
            File.WriteAllText(path, score + "\n");

            return;
        }

        File.AppendAllText(path, score + "\n");
    }

    private void BlockDestroyed() {
        foreach(var block in _blocks) {
            if(block.activeSelf) {
                return;
            }
        }

        // Win
        // Export score
        _player.SetActive(false);
        _ball.SetActive(false);

        ScoreExport(PlayerController.Score);
    }

    public void RestartButton() {
        foreach(var block in _blocks) {
            if(!block.activeSelf) {
                block.SetActive(true);
            }
        }

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
            ScoreExport(PlayerController.Score);

            PlayerController.Score = PlayerController.Config.DEFAULT_START_SCORE;
            PlayerController.Life = PlayerController.Config.DEFAULT_START_LIFE;

            return;
        }

        _player.SetActive(true);
        _ball.SetActive(true);
    }

    private void OnEnable() {
        _player.SetActive(true);
        _ball.SetActive(true);

        DeathZoneController.OnDeath += RestartLevel;
        OnBlockDestroyed += BlockDestroyed;
    }

    private void OnDisable() {
        DeathZoneController.OnDeath -= RestartLevel;
        OnBlockDestroyed -= BlockDestroyed;
    }
}
