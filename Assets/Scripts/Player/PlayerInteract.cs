using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    public DialogueData currentDialogue;

    public static event Action OnGetDialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            dialogueManager.NextDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.CompareTag("Npc"))
        {
            OnGetDialogue?.Invoke();

            if (currentDialogue != null)
            {
                dialogueManager.StartDialogue(currentDialogue);
            }
        }
    }
}
