using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HumanityMeter : MonoBehaviour
{
    // This guage shows the player's humanity level
    // the guage decreases when the player performs actions that harm/kill humans
    // the guage increases when the player performs actions that help humans

    [SerializeField] private Image humanityTotal;
    [SerializeField] private Image humanityCurrent;
    [SerializeField] private float totalPoints = 100f;
    private float _currentPoints;

    private void Start()
    {
        _currentPoints = totalPoints;
    }

    private void OnEnable()
    {
        //PlayerInteract.OnCorrectOrder += AddPoints;
        //PlayerInteract.OnIncorrectOrder += SubtractPoints;
    }

    private void OnDisable()
    {
        //PlayerInteract.OnCorrectOrder -= AddPoints;
        //PlayerInteract.OnIncorrectOrder -= SubtractPoints;
    }

    private void Update()
    {
        humanityCurrent.fillAmount = _currentPoints / totalPoints;
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
