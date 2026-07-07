using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuspicionMeter : MonoBehaviour
{
    // This guage shows how much the celestials trust the player
    // the guage goes up when the player performs tasks correctly
    // and goes down when the player makes mistakes or is caught helping humans

    [SerializeField] private Image susTotal;
    [SerializeField] private Image susCurrent;
    [SerializeField] private float totalPoints = 100f;
    private float _currentPoints;

    private void Start()
    {
        _currentPoints = totalPoints;
    }

    private void OnEnable()
    {
        PlayerInteract.OnCorrectOrder += AddPoints;
        PlayerInteract.OnIncorrectOrder += SubtractPoints;
    }

    private void OnDisable()
    {
        PlayerInteract.OnCorrectOrder -= AddPoints;
        PlayerInteract.OnIncorrectOrder -= SubtractPoints;
    }

    private void Update()
    {
        susCurrent.fillAmount = _currentPoints / totalPoints;

        //_currentPoints -= .01f continious hp loss;
    }

    private void SubtractPoints()
    {
        _currentPoints -= 10f;
    }

    private void AddPoints()
    {
        _currentPoints += 10f;
    }
}
