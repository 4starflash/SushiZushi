using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderListData", menuName = "Scriptable Objects/OrderListData")]
public class OrderListData : ScriptableObject
{
    [SerializeField] private OrderData[] m_orderList;
    public OrderData[] orderList { get { return m_orderList; } }

}
