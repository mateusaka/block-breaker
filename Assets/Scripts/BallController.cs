using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    [SerializeField] private Rigidbody2D _ballRB;
    [SerializeField] private float _sensitivity;

    private void RandomInitialTrajectory() {
        float random = Random.Range(-80f, 80f);

        while(random > -10f && random < -10f) {
            random = Random.Range(-80f, 80f);
        }

        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-80f, 80f));
        _ballRB.AddForce(transform.up * _sensitivity);
    }

    private void Start() {
        RandomInitialTrajectory();
    }
}
