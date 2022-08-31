using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {
    [SerializeField] private PowerUpController.PowerUp _powerUp;
    [SerializeField] private GameObject _player;

    private void DecreasePlayer() {
        _player.transform.localScale -= Vector3.right * 2;
    }

    private void IncreasePlayer() {
        _player.transform.localScale += Vector3.right * 2;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            switch(_powerUp) {
                case PowerUpController.PowerUp.None:
                    break;
                case PowerUpController.PowerUp.Decrease:
                    DecreasePlayer();
                    break;
                case PowerUpController.PowerUp.Increase:
                    IncreasePlayer();
                    break;
            }
        }        

        gameObject.SetActive(false);
    }

    private void Update() {
        transform.Translate(Vector3.down * 2 * Time.deltaTime);
    }

    private void OnEnable() {
        DeathZoneController.OnDeath += OnDisable;
    }

    private void OnDisable() {
        DeathZoneController.OnDeath -= OnDisable;
        gameObject.SetActive(false);
    }
}
