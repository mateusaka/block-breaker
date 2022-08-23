using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if(PlayerController.OnLifesChanged != null) {
            PlayerController.OnLifesChanged(PlayerController.Lifes -= 1);
        }
    }
}
