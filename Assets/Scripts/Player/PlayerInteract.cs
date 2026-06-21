using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private PlayerInventoryData inventoryData;

    private int _requiredTopLayer;
    private int _requiredMiddleLayer;
    private int _requiredBottomLayer;

    private void OnEnable()
    {
        Npc.OnSendOrder += AddOrder;
    }

    private void OnDisable()
    {
        Npc.OnSendOrder -= AddOrder;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            dialogueManager.NextDialogue();
        }
    }

    // Adds order requirements
    private void AddOrder(OrderData data)
    {
        _requiredTopLayer = data.topLayerID;
        _requiredMiddleLayer = data.middleLayerID;
        _requiredBottomLayer = data.bottomLayerID;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Npc"))
        {
            if (inventoryData.currentSushi != null)
            {
                if(inventoryData.currentSushi.sushiDataClass.topLayer == _requiredTopLayer && inventoryData.currentSushi.sushiDataClass.middleLayer == _requiredMiddleLayer && inventoryData.currentSushi.sushiDataClass.bottomLayer == _requiredBottomLayer)
                {
                    Debug.Log("correct!");

                }
                else
                {
                    Debug.Log("wrong!");
                }
            }
        }
    }
}
