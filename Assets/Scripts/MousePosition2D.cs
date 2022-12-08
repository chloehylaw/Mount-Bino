using System;
using System.Collections;
using System.Collections.Generic;
using Creatures;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MousePosition2D : MonoBehaviour
{
    public static event Action<Creature> OnMouseClick;
    public GameObject hit;
    public GraphicRaycaster raycaster;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            InvokeCreatureAtMouse();
        }
    }

    private void InvokeCreatureAtMouse()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            this.hit = hit.collider.gameObject;
            if (hit.collider.gameObject.TryGetComponent(out Creature returnal))
                OnMouseClick.Invoke(returnal);
        }
    }
}
