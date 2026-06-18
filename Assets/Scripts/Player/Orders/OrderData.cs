using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderData", menuName = "Scriptable Objects/OrderData")]
public class OrderData : ScriptableObject
{
    [SerializeField] private Sprite m_icon;
    public Sprite Icon { get { return m_icon; } }
    [SerializeField] private string m_order;
    public string Order { get { return m_order; } }

    
}
