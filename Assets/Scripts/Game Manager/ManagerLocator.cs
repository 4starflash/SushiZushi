using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLocator : MonoBehaviour
{
    public static ManagerLocator Instance { get; private set; }
    public DialogueManager dialogueManager { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        GameObject managerObject = GameObject.FindWithTag("GameController");
        dialogueManager = managerObject.GetComponent<DialogueManager>();
    }
}
