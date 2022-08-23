using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _ball;

    /* private IEnumerator Start() {
        yield return new WaitForSeconds(3);
        RestartLevel();
    } */

    private void RestartLevel() {
        _player.SetActive(false);
        _ball.SetActive(false);

        _player.SetActive(true);
        _ball.SetActive(true);
    }
}
