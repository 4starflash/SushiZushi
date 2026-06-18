using UnityEngine;
using System;

public class Npc : MonoBehaviour
{
    [SerializeField] private DialogueData dialogueData;

    private void OnEnable()
    {
        PlayerInteract.OnGetDialogue += SendDialogue;
    }

    private void Disable()
    {
        PlayerInteract.OnGetDialogue -= SendDialogue;
    }

    private void SendDialogue()
    {
        ManagerLocator.Instance.dialogueManager.StartDialogue(dialogueData);
    }
}
