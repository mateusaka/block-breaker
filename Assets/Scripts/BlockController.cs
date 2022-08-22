using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    [SerializeField] private int _blockValue;

    private void SetPoints() {
        PlayerController._score += _blockValue;

        if(PlayerController.OnScoreChanged != null) {
            PlayerController.OnScoreChanged(PlayerController._score);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        SetPoints();

        gameObject.SetActive(false);
    }
}
