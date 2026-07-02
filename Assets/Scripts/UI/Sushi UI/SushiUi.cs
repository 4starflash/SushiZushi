using System;
using UnityEngine;
using UnityEngine.UI;

public class SushiUi : MonoBehaviour
{
    [SerializeField] private Image topLayerIcon;
    [SerializeField] private Image middleLayerIcon;
    [SerializeField] private Image bottomLayerIcon;

    private void OnEnable()
    {
        SushiButton.OnSelectTop += ShowLayerTop;
        SushiButton.OnSelectMiddle += ShowLayerMiddle;
        SushiButton.OnSelectBottom += ShowLayerBottom;
    }

    private void Disable()
    {
        SushiButton.OnSelectTop -= ShowLayerTop;
        SushiButton.OnSelectMiddle -= ShowLayerMiddle;
        SushiButton.OnSelectBottom -= ShowLayerBottom;
    }

    private void ShowLayerTop(LayerData data)
    {
        topLayerIcon.sprite = data.DataClass.Icon;
    }

    private void ShowLayerMiddle(LayerData data)
    {
        middleLayerIcon.sprite = data.DataClass.Icon;
    }

    private void ShowLayerBottom(LayerData data)
    {
        bottomLayerIcon.sprite = data.DataClass.Icon;
    }
}
