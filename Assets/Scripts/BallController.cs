using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    [SerializeField] private Rigidbody2D _ballRB;
    [SerializeField] private float _sensitivity;

    private void RandomInitialTrajectory() {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(-80f, 80f));
        _ballRB.AddForce(transform.up * _sensitivity);
    }

    private void Start() {
        RandomInitialTrajectory();
    }
}
