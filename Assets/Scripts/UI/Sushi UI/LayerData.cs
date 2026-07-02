using UnityEngine;
using System;

[System.Serializable]
public class LayerDataClass
{
    [SerializeField] private Sprite m_Icon;
    public Sprite Icon { get { return m_Icon; } }

    [SerializeField] private int m_Id;
    public int Id { get { return m_Id; } }
}

[CreateAssetMenu(fileName = "LayerData", menuName = "Scriptable Objects/LayerData")]
public class LayerData : ScriptableObject
{
    [SerializeField] private LayerDataClass m_DataClass;
    public LayerDataClass DataClass { get { return m_DataClass; } }
}