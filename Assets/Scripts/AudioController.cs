using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    [SerializeField] private AudioSource _audioSourceBG;
    [SerializeField] private AudioSource _audioSourceFX;
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _SFX;

    private void FXBlockDestroyed() {
        _audioSourceFX.PlayOneShot(_SFX);
    }

    private void Start() {
        _audioSourceBG.clip = _backgroundMusic;
        _audioSourceBG.Play();
    }

    private void OnEnable() {
        LevelManager.OnBlockDestroyed += FXBlockDestroyed;
    }

    private void OnDisable() {
        LevelManager.OnBlockDestroyed -= FXBlockDestroyed;
    }
}
