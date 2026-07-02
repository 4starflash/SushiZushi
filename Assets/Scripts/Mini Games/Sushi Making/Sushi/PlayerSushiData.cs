using UnityEngine;
using System;

[CreateAssetMenu(fileName = "PlayerSushiData", menuName = "Scriptable Objects/PlayerSushiData")]
public class PlayerSushiData : ScriptableObject
{
    [SerializeField] private Sprite m_TopIcon;
    public Sprite TopIcon { get { return m_TopIcon; } }
    [SerializeField] private Sprite m_MiddleIcon;
    public Sprite MiddleIcon { get { return m_MiddleIcon; } }
    [SerializeField] private Sprite m_BottomIcon;
    public Sprite BottomIcon { get { return m_BottomIcon; } }

    [SerializeField] private int m_TopId;
    public int TopId { get { return m_TopId; } }
    [SerializeField] private int m_MiddleId;
    public int MiddleId { get { return m_MiddleId; } }
    [SerializeField] private int m_BottomId;
    public int BottomId { get { return m_BottomId; } }

    private void OnEnable()
    {
        SushiButton.OnSelectTop += CreateLayerTop;
        SushiButton.OnSelectMiddle += CreateLayerMiddle;
        SushiButton.OnSelectBottom += CreateLayerBottom;
    }

    private void Disable()
    {
        SushiButton.OnSelectTop -= CreateLayerTop;
        SushiButton.OnSelectMiddle -= CreateLayerMiddle;
        SushiButton.OnSelectBottom -= CreateLayerBottom;
    }

    private void CreateLayerTop(LayerData data)
    {
        m_TopIcon = data.DataClass.Icon;
        m_TopId = data.DataClass.Id;
    }

    private void CreateLayerMiddle(LayerData data)
    {
        m_MiddleIcon = data.DataClass.Icon;
        m_MiddleId = data.DataClass.Id;
    }

    private void CreateLayerBottom(LayerData data)
    {
        m_BottomIcon = data.DataClass.Icon;
        m_BottomId = data.DataClass.Id;
    }
}