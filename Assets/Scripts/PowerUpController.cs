using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour {
    public enum PowerUp {
        None,
        Decrease,
        Increase
    }

    [SerializeField] private List<GameObject> _decrease;
    [SerializeField] private List<GameObject> _increase;

    private void Spawn(List<GameObject> powerList, Vector3 position) {
        foreach(var power in powerList) {
            if(!power.activeSelf) {
                power.SetActive(true);
                power.transform.position = position;
                return;
            }
        }
    }

    private void PowerUpSpawned(PowerUp powerup, Vector3 position) {
        switch(powerup) {
            case PowerUp.None:
                break;
            case PowerUp.Decrease:
                Spawn(_decrease, position);
                break;
            case PowerUp.Increase:
                Spawn(_increase, position);
                break;
        }
    }

    private void OnEnable() {
        BlockController.OnPowerUpSpawned += PowerUpSpawned;
    }

    private void OnDisable() {
        BlockController.OnPowerUpSpawned -= PowerUpSpawned;
    }
}
