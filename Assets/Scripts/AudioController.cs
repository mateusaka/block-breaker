using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    [SerializeField] private AudioSource _audioSourceBG;
    [SerializeField] private AudioSource _audioSourceFX;
    [SerializeField] private List<AudioClip> _backgroundMusics;

    public void FXBlockDestroyed() {
        
    }

    private void Start() {
        _audioSourceBG.clip = _backgroundMusics[Random.Range(0, _backgroundMusics.Count)];
        _audioSourceBG.Play();
    }
}
