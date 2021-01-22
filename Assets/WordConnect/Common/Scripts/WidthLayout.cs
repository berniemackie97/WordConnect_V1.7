using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WidthLayout : MonoBehaviour {

    public bool padding;
    public float paddingValue;
    public bool maxWidth;
    public float maxWidthValue;
    public bool minWidth;
    public float minWidthValue;

    private RectTransform rt, parentRt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        parentRt = transform.parent.GetComponent<RectTransform>();
    }

    private void Update()
    {
        float width = rt.sizeDelta.x;
        if (padding)
        {
            width = parentRt.rect.width - paddingValue * 2;
        }

        if (maxWidth && width > maxWidthValue)
        {
            width = maxWidthValue;
        }

        if (minWidth && width < minWidthValue)
        {
            width = minWidthValue;
        }

        rt.sizeDelta = new Vector2(width, rt.sizeDelta.y);

        if (rt.pivot.x == 0)
        {
            rt.localPosition = new Vector3(-width / 2, rt.localPosition.y, rt.localPosition.z);
        }
    }
}
