using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private Security[] _homes;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _changingVolumeTime;
    private bool _isIncreaseVolumeRunning = false;
    private bool _isTurnDownVolumeRunning = false;

    public void TurnOnAlarm()
    {
        StartCoroutine( IncreaseVolume());
    }

    public void TurnOffAlarm()
    {        
        StartCoroutine( TurnDownVolume());
    }

    private IEnumerator IncreaseVolume()
    {
        _isTurnDownVolumeRunning = false;
        _isIncreaseVolumeRunning = true;
        float _changingVolumeRunningTime = 0;

        while (_audioSource.volume < 1f&& _isTurnDownVolumeRunning==false)
        {
            _changingVolumeRunningTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 1f,_changingVolumeRunningTime/ _changingVolumeTime);
            yield return null;
        }

        _isIncreaseVolumeRunning = false;
    }

    private IEnumerator TurnDownVolume()
    {
        _isIncreaseVolumeRunning = false;
        _isTurnDownVolumeRunning = true;
        float _changingVolumeRunningTime = 0;        

        while (_audioSource.volume > 0f&& _isIncreaseVolumeRunning==false)
        {
            _changingVolumeRunningTime += Time.deltaTime;
            _audioSource.volume = Mathf.Lerp(_audioSource.volume, 0f, _changingVolumeRunningTime / _changingVolumeTime);
            Debug.Log("Сирена уменьш " + _audioSource.volume + " " + _changingVolumeRunningTime);
            yield return null;
        }

        _isTurnDownVolumeRunning = false;
    }
}
