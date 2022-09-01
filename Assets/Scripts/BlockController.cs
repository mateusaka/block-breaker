using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour {
    [SerializeField] private PowerUpController.PowerUp _powerUp;
    [SerializeField] private int _blockValue;

    public static Action<PowerUpController.PowerUp, Vector3> OnPowerUpSpawned;

    private void OnCollisionEnter2D(Collision2D other) {
        gameObject.SetActive(false);
        
        if(PlayerController.OnScoreChanged != null) {
            PlayerController.OnScoreChanged(PlayerController.Score += _blockValue);
        }

        if(LevelManager.OnBlockDestroyed != null) {
            LevelManager.OnBlockDestroyed();
        }

        if(OnPowerUpSpawned != null) {
            switch(_powerUp) {
                case PowerUpController.PowerUp.None:
                    break;
                case PowerUpController.PowerUp.Decrease:
                    OnPowerUpSpawned(PowerUpController.PowerUp.Decrease, transform.position);
                    break;
                case PowerUpController.PowerUp.Increase:
                    OnPowerUpSpawned(PowerUpController.PowerUp.Increase, transform.position);
                    break;
            }
        }
    }
}
