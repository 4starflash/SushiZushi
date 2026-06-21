using System;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField] private SushiData sushiData;

    public static event Action<SushiData> OnAddSushi;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            OnAddSushi(sushiData);
        }
    }
}
