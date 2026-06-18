using UnityEngine;
using System;

public class Npc : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private OrderData orderData;
    private bool _interacted = false;

    public static event Action<DialogueData> OnSendDialogue;
    public static event Action<OrderData> OnSendOrder;
    public static event Action OnInteract;


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            OnInteract();
            OnSendDialogue?.Invoke(dialogueData);
            OnSendOrder?.Invoke(orderData);
            Debug.Log("talking");
        }
    }
}
