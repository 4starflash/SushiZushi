using UnityEngine;
using System;

public class Npc : MonoBehaviour
{
    private enum NpcState { Entering, Talking, MovingToTable, Waiting }
    private NpcState currentState = NpcState.Entering;

    private bool _gaveOrder = false;

    // Dialogue info
    [SerializeField] private DialogueData dialogueData;
    [SerializeField] private OrderData orderData;

    // Movement info
    [SerializeField] private int tableNumber;
    [SerializeField] private float speed = 5f;

    public static event Action<DialogueData> OnSendDialogue;
    public static event Action<OrderData> OnSendOrder;
    public static event Action<OrderData> OnRemindOrder;
    public static event Action OnInteract;
    public static event Action OnArriveAtRegister;

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
            case NpcState.Entering:
                MoveToRegister();
                break;

            case NpcState.Talking:
                break;

            case NpcState.MovingToTable:
                MoveToTable();
                break;

            case NpcState.Waiting:
                break;
        }
    }
    
    // Npc switches to moving state and sends order data to player upon finishing dialogue
    private void SwitchToMove()
    {
        OnSendOrder?.Invoke(orderData);

        if (currentState == NpcState.Talking)
        {
            currentState = NpcState.MovingToTable;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (!_gaveOrder)
            {
                OnInteract.Invoke();
                OnSendDialogue?.Invoke(dialogueData);
                currentState = NpcState.Talking;
                _gaveOrder = true;
            }

            else
            {
                OnRemindOrder?.Invoke(orderData);
            }

        }
    }

    // Npc moves to table after giving order
    private void MoveToTable()
    {
        transform.position = Vector2.Lerp(transform.position, TableList.Instance.tableNumber[tableNumber].position, speed * Time.deltaTime);
    }

    private void MoveToRegister()
    {
        transform.position = Vector2.Lerp(transform.position, TableList.Instance.registerTable.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, TableList.Instance.registerTable.position) <= .1f) 
        {
            Debug.Log("arrived!");

            OnArriveAtRegister?.Invoke();
            currentState = NpcState.Waiting;
        }
    }

}
