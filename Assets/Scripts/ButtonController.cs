using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    public Color32 normalColor;
    public Color32 hoverColor;
    public Color32 downColor;

    private Image image = null;
    // Start is alled before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = hoverColor;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = normalColor;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        image.color = downColor;
    }
    public void OnPointerUp(PointerEventData eventData)
    {

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        image.color = hoverColor;
    }
}
