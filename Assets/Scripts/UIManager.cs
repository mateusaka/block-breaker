using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _lifesText;

    private void UpdateLifes(int lifes) {
        _lifesText.text = lifes.ToString();
    }

    private void UpdatePoints(int points) {
        _scoreText.text = points.ToString();
    }

    private void OnEnable() {
        PlayerController.OnScoreChanged += UpdatePoints;
        PlayerController.OnLifesChanged += UpdateLifes;
    }

    private void OnDisable() {
        PlayerController.OnScoreChanged -= UpdatePoints;
        PlayerController.OnLifesChanged -= UpdateLifes;
    }
}
