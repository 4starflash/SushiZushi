using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] DialogueManager dialogueManager;
    public DialogueData currentDialogue;

    private void Update()
    {
        if (currentDialogue != null & Input.GetKeyDown(KeyCode.Z))
        {
            dialogueManager.StartDialogue(currentDialogue);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            dialogueManager.NextDialogue();
        }
    }
}
