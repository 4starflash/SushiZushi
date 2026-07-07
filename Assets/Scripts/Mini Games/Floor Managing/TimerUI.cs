using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    // the timer UI appears when a customer arrives at the reigster
    // and shows how much time the player has before the customer will leave

    [SerializeField] private GameObject registTimerObject;
    [SerializeField] private Image registerTimer;
    [SerializeField] private float maxRegisterTimer = 10f;
    private float _currentRegisterTimer;

    private void OnEnable()
    {
        _currentRegisterTimer = maxRegisterTimer;
    }

    private void Update()
    {
        if (registTimerObject.activeInHierarchy)
        {
            CountDownTimer();
        }
    }

    private void CountDownTimer()
    {
        if (_currentRegisterTimer > 0)
        {
            _currentRegisterTimer -= Time.deltaTime;

            registerTimer.fillAmount = _currentRegisterTimer / maxRegisterTimer;
        }

        else
        {
            registerTimer.fillAmount = 0f;
            registTimerObject.SetActive(false);
        }
    }
}
