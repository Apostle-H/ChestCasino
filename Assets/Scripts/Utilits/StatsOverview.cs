using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class StatsOverview : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI info;

    private int UILayer;
    private Transform UIOver;
    private ItemSlot itemSlotOver;
    private bool isShowing;

    private void Start()
    {
        UILayer = LayerMask.NameToLayer("UI");
    }

    private void Update()
    {
        UIOver = IsOverUI(GetEventSystemRaycastResults());

        if (!isShowing && UIOver)
        {
            if ((UIOver.TryGetComponent(out itemSlotOver) || UIOver.parent.TryGetComponent(out itemSlotOver)) && Inventory.Instance.storedItems[itemSlotOver.index] != null)
            {
                ShowStats(Inventory.Instance.storedItems[itemSlotOver.index]);
                isShowing = true;
            }
        }
        else if (isShowing && UIOver != itemSlotOver.transform)
        {
            for (int i = 0; i < itemSlotOver.transform.childCount; i++)
            {
                if (UIOver == itemSlotOver.transform.GetChild(i))
                {
                    return;
                }
            }

            StopShowingStats();
            isShowing = false;
        }
    }

    private Transform IsOverUI(List<RaycastResult> eventSystemRaycastResults)
    {
        for (int i = 0; i < eventSystemRaycastResults.Count; i++)
        {
            if (eventSystemRaycastResults[i].gameObject.layer == UILayer)
            {
                return eventSystemRaycastResults[i].gameObject.transform;
            }
        }

        return null;
    }

    private List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

    private void ShowStats(Item item)
    {
        switch (item.itemType)
        {
            //case ItemType.weapon:
            //    info.text = ((Weapon)item).ToString();
            //    break;
            //case ItemType.armor:
            //    info.text = ((Armor)item).ToString();
            //    break;
            //case ItemType.artifact:
            //    info.text = ((Artifact)item).ToString();
            //    break;
            //case ItemType.consumable:
            //    info.text = ((Consumable)item).ToString();
            //    break;
            default:
                info.text = item.ToString();
                break;
        }
    }

    private void StopShowingStats()
    {
        info.text = "info";
    }
}
