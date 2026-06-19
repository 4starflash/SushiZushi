using UnityEngine;
using System;

public class Npc : MonoBehaviour
{
    private enum NpcState { Talking, MovingToTable, Waiting }
    private NpcState currentState = NpcState.Waiting;

    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private OrderData orderData;

    [SerializeField] private int tableNumber;
    [SerializeField] private float speed = 5f;

    public static event Action<DialogueData> OnSendDialogue;
    public static event Action<OrderData> OnSendOrder;
    public static event Action OnInteract;

    private void OnEnable()
    {
        DialogueManager.OnFinishedOrdering += SwitchToMove;
    }

    private void OnDisable()
    {
        DialogueManager.OnFinishedOrdering -= SwitchToMove;
    }

    private void Update()
    {
        switch (currentState)
        {
            case NpcState.Talking:
                break;

            case NpcState.MovingToTable:
                MoveToTable();
                break;

            case NpcState.Waiting:
                break;
        }
    }
    
    private void SwitchToMove()
    {
        if(currentState == NpcState.Talking)
        {
            currentState = NpcState.MovingToTable;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            OnInteract();
            OnSendDialogue?.Invoke(dialogueData);
            OnSendOrder?.Invoke(orderData);
            currentState = NpcState.Talking;
        }
    }

    private void MoveToTable()
    {
        transform.position = Vector2.Lerp(transform.position, TableList.Instance.tableNumber[tableNumber].position, speed * Time.deltaTime);
    }
}
