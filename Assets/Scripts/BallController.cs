using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Rigidbody2D _ballRB;
    [SerializeField] private float _sensitivity;
    [SerializeField] private GameObject _pressToStart;

    private void RandomInitialTrajectory() {
        float random = Random.Range(-60f, 60f);

        while(random > -25 && random < 25) {
            random = Random.Range(-60f, 60f);
        }

        transform.rotation = Quaternion.Euler(0, 0, random);
        _ballRB.AddForce(transform.up * _sensitivity);
    }

    private IEnumerator EnableBall() {        
        _ballRB.velocity = Vector2.zero;

        transform.position = _startPosition;

        _pressToStart.SetActive(true);
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        _pressToStart.SetActive(false);

        RandomInitialTrajectory();
    }

    private void OnEnable() {
        StartCoroutine(EnableBall());
    }
}
