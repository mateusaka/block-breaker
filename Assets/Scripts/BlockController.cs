using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    [SerializeField] private int _blockValue;

    private void OnCollisionEnter2D(Collision2D other) {
        if(PlayerController.OnScoreChanged != null) {
            PlayerController.OnScoreChanged(PlayerController.Score += _blockValue);
        }

        if(LevelManager.OnBlockDestroyed != null) {
            LevelManager.OnBlockDestroyed();
        }
        
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        
    }
}
