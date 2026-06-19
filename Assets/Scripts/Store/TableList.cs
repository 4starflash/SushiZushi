using UnityEngine;

public class TableList : MonoBehaviour
{
    public static TableList Instance { get; private set; }

    public Transform[] tableNumber;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }
}
