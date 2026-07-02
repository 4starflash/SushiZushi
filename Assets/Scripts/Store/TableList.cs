using UnityEngine;

public class TableList : MonoBehaviour
{
    public static TableList Instance { get; private set; }

    public Transform[] tableNumber;
    public Transform registerTable;

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
