using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text speakerName;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private Image speakerIcon;

    [SerializeField] private DialogueData currentData;

    private int _index;

    private void OnEnable()
    {
        Npc.OnSendDialogue += StartDialogue;
    }

    private void OnDisable()
    {
        Npc.OnSendDialogue -= StartDialogue;
    }

    public void StartDialogue(DialogueData data)
    {
        dialogueBox.SetActive(true);
        currentData = data;

        speakerName.text = currentData.DataClass.speakerName;
        dialogueText.text = currentData.DataClass.dialogueLines[_index];
        speakerIcon.sprite = currentData.DataClass.speakerIcon;
    }

    public void NextDialogue()
    {
        _index++;

        if (_index < currentData.DataClass.dialogueLines.Length) dialogueText.text = currentData.DataClass.dialogueLines[_index];
        else EndDialogue();
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        currentData = null;
        _index = 0;
    }
}
