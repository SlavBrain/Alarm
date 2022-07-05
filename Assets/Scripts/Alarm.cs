using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _changingVolumeTime;

    private Coroutine _changingVolume;

    public void TurnOnAlarm()
    {
        if (_changingVolume!=null)
        {
            StopCoroutine(_changingVolume);
        }

        _changingVolume= StartCoroutine( IncreaseVolume());
    }

    public void TurnOffAlarm()
    {
        if (_changingVolume != null)
        {
            StopCoroutine(_changingVolume);
        }

        _changingVolume = StartCoroutine( TurnDownVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        float _changingVolumeRunningTime = 0;

        while (_audioSource.volume < 1f)
        {
            _changingVolumeRunningTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 1f,_changingVolumeRunningTime/ _changingVolumeTime);
            yield return null;
        }
    }

    private IEnumerator TurnDownVolume()
    {
        float _changingVolumeRunningTime = 0;        

        while (_audioSource.volume > 0f)
        {
            _changingVolumeRunningTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 0f, _changingVolumeRunningTime / _changingVolumeTime);
            yield return null;
        }
    }
}
