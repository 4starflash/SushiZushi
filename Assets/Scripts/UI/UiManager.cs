using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject orderList;

    private void OnEnable()
    {
        Npc.OnInteract += HideOrderList;
    }

    private void Disable()
    {
        Npc.OnInteract -= HideOrderList;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            orderList.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideOrderList();
        }
    }

    private void HideOrderList()
    {
        orderList.SetActive(false);
    }
}
