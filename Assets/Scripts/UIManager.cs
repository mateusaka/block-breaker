using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField] private TMP_Text _levelText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _lifesText;

    private void UpdateLife(int lifes) {
        _lifesText.text = lifes.ToString();
    }

    private void UpdateScore(int score) {
        _scoreText.text = score.ToString();
    }

    private void UpdateLevel(int level) {
        _levelText.text = level.ToString();
    }

    private void OnEnable() {
        PlayerController.OnLevelChanged += UpdateLevel;
        PlayerController.OnScoreChanged += UpdateScore;
        PlayerController.OnLifeChanged += UpdateLife;
    }

    private void OnDisable() {
        PlayerController.OnLevelChanged -= UpdateLevel;
        PlayerController.OnScoreChanged -= UpdateScore;
        PlayerController.OnLifeChanged -= UpdateLife;
    }
}
