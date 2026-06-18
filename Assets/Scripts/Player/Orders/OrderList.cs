using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OrderList : MonoBehaviour
{
    [SerializeField] private Image[] orderIcons;
    [SerializeField] private TMP_Text[] orderDetails;

    [SerializeField] OrderListData orderListData;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
            ShowOrdersOnList();
    }

    private void ShowOrdersOnList()
    {
        for (int i = 0; i < orderListData.orderList.Length; i++)
        {
            if (orderListData.orderList[i] != null)
            {
                orderIcons[i].sprite = orderListData.orderList[i].Icon;
                orderDetails[i].text = orderListData.orderList[i].Order;
            }
        }
    }
}
