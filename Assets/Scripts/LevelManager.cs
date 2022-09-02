using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [System.Serializable]
    public class Level {
        public List<GameObject> blocks;
    }

    [System.Serializable]
    public class LevelList {
        public List<Level> blockList;
    }

    [SerializeField] private LevelList _allBlocks;
    [SerializeField] private List<GameObject> _allLevels;
    [SerializeField] private List<GameObject> _powerUps;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private GameObject _won;

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

    private void NextLevel() {
        foreach(var level in _allLevels) {
            level.SetActive(false);
        }

        _allLevels[PlayerController.Level - 1].SetActive(true);

        _player.SetActive(false);
        _ball.SetActive(false);

        _player.SetActive(true);
        _ball.SetActive(true);
    }

    private void BlockDestroyed() {
        foreach(var block in _allBlocks.blockList[PlayerController.Level - 1].blocks) {
            //Debug.Log("bloco: " + block.name + " esta: " + block.activeInHierarchy);
            if(block.activeInHierarchy) {
                return;
            }
        }

        foreach(var powerup in _powerUps) {
            powerup.SetActive(false);
        }

        // Win
        if(PlayerController.OnLevelChanged != null) {
            PlayerController.OnLevelChanged(PlayerController.Level += 1);
        }

        if(PlayerController.Level > _allLevels.Count) {
            _won.SetActive(true);

            // Export score
            _player.SetActive(false);
            _ball.SetActive(false);

            ScoreExport(PlayerController.Score);
        }
        else {
            NextLevel();
        }
    }

    public void RestartButton() {
        /* foreach(var block in _allBlocks.blockList[PlayerController.Level - 1].blocks) {
            if(!block.activeSelf) {
                block.SetActive(true);
            }
        } */
        SetDefaultConfig();
        NextLevel();

        _gameOver.SetActive(false);
    }

    private void SetDefaultConfig() {
        PlayerController.Level = PlayerController.Config.DEFAULT_START_LEVEL;
        PlayerController.Score = PlayerController.Config.DEFAULT_START_SCORE;
        PlayerController.Life = PlayerController.Config.DEFAULT_START_LIFE;
    }

    private void RestartLevel() {
        _player.SetActive(false);
        _ball.SetActive(false);

        if(PlayerController.Life <= 0) {
            _gameOver.SetActive(true);

            // Export score
            ScoreExport(PlayerController.Score);

            SetDefaultConfig();

            return;
        }

        _player.SetActive(true);
        _ball.SetActive(true);
    }

    private void OnEnable() {
        SetDefaultConfig();
        NextLevel();

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
