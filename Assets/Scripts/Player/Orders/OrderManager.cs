using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private OrderListData m_OrderListData;

    private void Start()
    {
        Npc.OnSendOrder += RetrieveOrder;
        PlayerInteract.OnCompleteOrder += RemoveOrder;
    }

    private void RetrieveOrder(OrderData data)
    {
        m_OrderListData.AddOrder(data);
    }

    private void RemoveOrder(OrderData data)
    {
        m_OrderListData.RemoveOrder(data);
    }
}
