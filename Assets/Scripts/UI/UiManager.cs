using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject orderList;

    [SerializeField] private GameObject topLayerSelect;
    [SerializeField] private GameObject middleLayerSelect;
    [SerializeField] private GameObject bottomLayerSelect;
    [SerializeField] private GameObject sushiUI;


    private void OnEnable()
    {
        Npc.OnInteract += HideOrderList;
    }

    private void Disable()
    {
        Npc.OnInteract -= HideOrderList;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            orderList.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            HideOrderList();
        }

    }

    private void HideOrderList()
    {
        orderList.SetActive(false);
    }

    public void ShowSushiUI()
    {
        sushiUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HideSushiUI()
    {
        sushiUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowTopLayerSelect()
    {
        topLayerSelect.SetActive(true);
        middleLayerSelect.SetActive(false);
        bottomLayerSelect.SetActive(false);
    }

    public void ShowMiddleLayerSelect()
    {
        topLayerSelect.SetActive(false);
        middleLayerSelect.SetActive(true);
        bottomLayerSelect.SetActive(false);
    }

    public void ShowBottomLayerSelect()
    {
        topLayerSelect.SetActive(false);
        middleLayerSelect.SetActive(false);
        bottomLayerSelect.SetActive(true);
    }
}
