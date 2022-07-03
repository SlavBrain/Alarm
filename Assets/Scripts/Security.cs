using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Security : MonoBehaviour
{
    [SerializeField ]private UnityEvent _onThiefInHome;
    [SerializeField] private UnityEvent _onThiefOutHome;
    private bool _isThiefInHome;
    private bool _isThiefOutHome;

    public event UnityAction OnThiefInHome
    {
        add => _onThiefInHome.AddListener(value);
        remove => _onThiefInHome.RemoveListener(value);
    }

    public event UnityAction OnThiefOutHome
    {
        add => _onThiefOutHome.AddListener(value);
        remove => _onThiefOutHome.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isThiefInHome)
        {
            return;
        }

        if(collision.TryGetComponent<Player>(out Player player))
        {
            _isThiefInHome=true;
            _isThiefOutHome = false;
            _onThiefInHome?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isThiefOutHome)
        {
            return;
        }

        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isThiefInHome = false;
            _isThiefOutHome = true;
            _onThiefOutHome?.Invoke();
        }
    }
}
