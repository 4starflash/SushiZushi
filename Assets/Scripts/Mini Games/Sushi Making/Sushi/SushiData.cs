using UnityEngine;
using System;

[System.Serializable]
public class SushiDataClass
{
    [SerializeField] private int m_topLayer;
    public int topLayer { get { return m_topLayer; } }
    [SerializeField] private int m_middleLayer;
    public int middleLayer { get { return m_middleLayer; } }
    [SerializeField] private int m_bottomLayer;
    public int bottomLayer { get { return m_bottomLayer; } }

}

[CreateAssetMenu(fileName = "SushiData", menuName = "Scriptable Objects/SushiData")]
public class SushiData : ScriptableObject
{
    [SerializeField] private SushiDataClass m_sushiDataClass;
    public SushiDataClass sushiDataClass { get { return m_sushiDataClass; } }
}