using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderListData", menuName = "Scriptable Objects/OrderListData")]
public class OrderListData : ScriptableObject
{
    [SerializeField] private OrderData[] m_orderList;
    public OrderData[] orderList { get { return m_orderList; } }

    public void AddOrder(OrderData order)
    {
        if (m_orderList[m_orderList.Length - 1] != null) return;

        for (int i = 0; i < m_orderList.Length; i++)
        {
            if (m_orderList[i] == null)
            {
                m_orderList[i] = order;
                return;
            }
        }

        return;
    }
}
