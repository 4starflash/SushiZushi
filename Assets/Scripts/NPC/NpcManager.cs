using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcManager : MonoBehaviour
{
    [Header("Customers")]
    [SerializeField] private GameObject[] customers;

    [Header("Customer Context")]
    private int _customerIndex;
    [SerializeField] private Transform spawnLocation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SpawnCustomer();
        }
    }

    // spawns one customer npc at spawn location
    private void SpawnCustomer()
    {
        if (customers[_customerIndex] != null)
        {
            Instantiate(customers[_customerIndex], spawnLocation.position, Quaternion.identity);
            _customerIndex += 1;
        }
    }
}
