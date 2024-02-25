using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Image im;
    private LineRenderer lineRenderer;
    private Canvas canvas;
    private bool dragStart = false;
    public bool startWire;
    private WireManager wm;
    public Color wireColor;
    public bool matched = false;

    private void Awake()
    {
        im = GetComponent<Image>();
        lineRenderer = GetComponent<LineRenderer>();
        canvas = GetComponentInParent<Canvas>();
        Cursor.lockState = CursorLockMode.None;
        wm = GetComponentInParent<WireManager>();
    }

    private void Update()
    {
        
        if(dragStart)
        {
            Vector2 movePosition;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                    canvas.transform as RectTransform,
                    Input.mousePosition,
                    canvas.worldCamera,
                    out movePosition
                );
            lineRenderer.sortingOrder = 1;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, canvas.transform.TransformPoint(movePosition));
        }
        
        else
        {
            if(!matched)
            {
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
            }
        }
        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, canvas.worldCamera);
        if(isHovered)
        {
            wm.hoveredWire = this;
        }
    }

    public void SetColor(Color color)
    {
        im.color = color;
        wireColor = color;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // not used for this functionality
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(!startWire) { return; }
        if(!matched) { return; }
        Debug.Log("wire");
        dragStart = true;
        wm.currentWire = this;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(wm.hoveredWire != null)
        {
            if(wm.hoveredWire.wireColor == wireColor && !wm.hoveredWire.startWire)
            {
                matched = true;
                wm.hoveredWire.matched = true;
            }
        }
        dragStart = false;
        wm.currentWire = null;
    }
}
