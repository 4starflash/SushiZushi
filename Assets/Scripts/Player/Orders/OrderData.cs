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

    [SerializeField] private int m_topLayerID;
    public int topLayerID { get { return m_topLayerID; } }
    [SerializeField] private int m_middleLayerID;
    public int middleLayerID { get { return m_middleLayerID; } }
    [SerializeField] private int m_bottomLayerID;
    public int bottomLayerID { get { return m_bottomLayerID; } }
}
