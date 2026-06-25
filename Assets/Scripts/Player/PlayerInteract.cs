using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    private enum InteractState { NotInteracting, Interacting }
    private InteractState currentState = InteractState.NotInteracting;

    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private PlayerInventoryData inventoryData;
    private OrderData _currentOrder;

    private int _requiredTopLayer;
    private int _requiredMiddleLayer;
    private int _requiredBottomLayer;

    private Collider2D _collider;
    [SerializeField] private LayerMask npcLayer;

    public static event Action OnInteract;
    public static event Action<OrderData> OnCompleteOrder;

    private void Start()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        Npc.OnRemindOrder += AddOrder;
        DialogueManager.OnFinishedOrdering += StopInteracting;
    }

    private void OnDisable()
    {
        Npc.OnRemindOrder -= AddOrder;
        DialogueManager.OnFinishedOrdering -= StopInteracting;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            dialogueManager.NextDialogue();
        }

        StateBehavior();
    }

    private void StateBehavior()
    {
        switch (currentState)
        {
            case InteractState.NotInteracting:
                if (InteractWith())
                {
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        OnInteract?.Invoke();
                        currentState = InteractState.Interacting;
                    }

                    if (Input.GetKeyDown(KeyCode.G))
                    {
                        CheckSushi();
                    }
                }
                break;

            case InteractState.Interacting:
                Debug.Log("Interacting!");
                break;
        }
    }

    private void StopInteracting()
    {
        currentState = InteractState.NotInteracting;
    }

    // Adds order requirements
    private void AddOrder(OrderData data)
    {
        _currentOrder = data;
        _requiredTopLayer = data.topLayerID;
        _requiredMiddleLayer = data.middleLayerID;
        _requiredBottomLayer = data.bottomLayerID;
    }

    private void CheckSushi()
    {
        if (inventoryData.currentSushi != null)
        {
            if (inventoryData.currentSushi.sushiDataClass.topLayer == _requiredTopLayer && inventoryData.currentSushi.sushiDataClass.middleLayer == _requiredMiddleLayer && inventoryData.currentSushi.sushiDataClass.bottomLayer == _requiredBottomLayer)
            {
                Debug.Log("correct!");
                OnCompleteOrder?.Invoke(_currentOrder);

            }
            else
            {
                Debug.Log("wrong!");
            }
        }
    }

    private bool InteractWith()
    {
        Vector2 origin = _collider.bounds.center;
        Vector2 size = _collider.bounds.size;

        RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0f, Vector2.up, 1f, npcLayer);

        return hit.collider != null;
    }
}
