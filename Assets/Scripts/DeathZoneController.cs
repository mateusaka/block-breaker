using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour {
    public static Action OnDeath;

    private void Death() {
        if(PlayerController.OnLifeChanged != null) {
            PlayerController.OnLifeChanged(PlayerController.Life -= 1);
        }

        if(OnDeath != null) {
            OnDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ball")) {
            Death();
        }        
    }
}
