using System;
using UnityEngine;

public class SushiButton : MonoBehaviour
{
    public enum LayerType { Top, Middle, Bottom }
    public LayerType layerType;

    [SerializeField] private LayerData layerData;

    public static event Action<LayerData> OnSelectTop;
    public static event Action<LayerData> OnSelectMiddle;
    public static event Action<LayerData> OnSelectBottom;

    public void SelectOption()
    {
        if(layerType == LayerType.Top)
        {
            OnSelectTop?.Invoke(layerData);
        }

        else if (layerType == LayerType.Middle)
        {
            OnSelectMiddle?.Invoke(layerData);
        }

        else if (layerType == LayerType.Bottom)
        {
            OnSelectBottom?.Invoke(layerData);
        }
    }
}
