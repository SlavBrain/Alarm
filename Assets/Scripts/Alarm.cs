using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _changingVolumeTime;

    private float _minVolume = 0f;
    private float _maxVolume = 1f;

    private Coroutine _changingVolume;

    public void TurnOnAlarm()
    {
        if (_changingVolume!=null)
        {
            StopCoroutine(_changingVolume);
        }

        _changingVolume= StartCoroutine( ChangeVolume(_maxVolume));
    }

    public void TurnOffAlarm()
    {
        if (_changingVolume != null)
        {
            StopCoroutine(_changingVolume);
        }

        _changingVolume = StartCoroutine(ChangeVolume(_minVolume));
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, Time.deltaTime/_changingVolumeTime);
            yield return null;
        }
    }
}
