using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInventoryData", menuName = "Scriptable Objects/PlayerInventoryData")]
public class PlayerInventoryData : ScriptableObject
{
    public SushiData currentSushi;

    private void OnEnable()
    {
        PlayerInventoryManager.OnAddSushi += AddSushi;
    }

    private void Disable()
    {
        PlayerInventoryManager.OnAddSushi -= AddSushi;
    }

    // adds sushi to inventory
    private void AddSushi(SushiData sushi)
    {
        currentSushi = sushi;
    }

}
