using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private TMP_Text dialogueText;

    [SerializeField] private DialogueData currentData;

    private int index;

    public void StartDialogue(DialogueData data)
    {
        dialogueBox.SetActive(true);
        currentData = data;

        speakerName.text = currentData.DataClass.speakerName;
        dialogueText.text = currentData.DataClass.dialogueLines[index];
    }

    public void NextDialogue()
    {
        index++;

        if (index < currentData.DataClass.dialogueLines.Length) dialogueText.text = currentData.DataClass.dialogueLines[index];
        else EndDialogue();
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        currentData = null;
    }
}
