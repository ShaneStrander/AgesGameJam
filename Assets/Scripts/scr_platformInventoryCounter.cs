using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scr_platformInventoryCounter : MonoBehaviour
{
    [SerializeField]
    private int inventoryCount = 0;
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void Update()
    {
        textMeshProUGUI.text = inventoryCount.ToString();
    }
    public void AddToInventory()
    {
        inventoryCount++;
    }
    public bool RemoveFromInventory()
    {
        if (inventoryCount > 0)
        {
            inventoryCount--;
            return true;
        }
        else
        {
            Debug.Log("Empty");
            return false;
        }
    }
}
