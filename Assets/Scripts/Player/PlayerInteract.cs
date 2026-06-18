using UnityEngine;
using System;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    public DialogueData currentDialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            dialogueManager.NextDialogue();
        }
    }
}
