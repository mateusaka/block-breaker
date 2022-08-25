using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _lifesText;

    private void UpdateLife(int lifes) {
        _lifesText.text = lifes.ToString();
    }

    private void UpdateScore(int score) {
        _scoreText.text = score.ToString();
    }

    private void OnEnable() {
        PlayerController.OnScoreChanged += UpdateScore;
        PlayerController.OnLifeChanged += UpdateLife;
    }

    private void OnDisable() {
        PlayerController.OnScoreChanged -= UpdateScore;
        PlayerController.OnLifeChanged -= UpdateLife;
    }
}
