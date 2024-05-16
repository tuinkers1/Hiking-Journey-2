using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragonflyInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject infoPage; // Reference to the information page for the bug

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        // When the player hovers over the button, enable the information page
        infoPage.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // When the player stops hovering over the button, disable the information page
        infoPage.SetActive(false);
    }
}

