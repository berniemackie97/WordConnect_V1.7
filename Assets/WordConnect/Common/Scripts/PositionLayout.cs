using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PositionLayout : MonoBehaviour {
    public bool paddingLeft;
    public float paddingLeftValue;
    public bool paddingRight;
    public float paddingRightValue;
    public bool paddingTop;
    public float paddingTopValue;
    public bool paddingBottom;
    public float paddingBottomValue;
    public bool minLeft;
    public float minLeftValue;
    public bool maxRight;
    public float maxRightValue;
    public bool minBottom;
    public float minBottomValue;
    public bool maxTop;
    public float maxTopValue;

    private RectTransform parentRt;

	void Start ()
    {
        parentRt = transform.parent.GetComponent<RectTransform>();
	}
	
	void Update ()
    {
        float x = transform.localPosition.x;

        float y = transform.localPosition.y;
	    if (paddingLeft)
        {
            x = - parentRt.rect.width / 2f + paddingLeftValue;
        }
        if (paddingRight)
        {
            x = parentRt.rect.width / 2f -  paddingRightValue;
        }
        if (paddingTop)
        {
            y = parentRt.rect.height / 2f - paddingTopValue;
        }
        if (paddingBottom)
        {
            y = -parentRt.rect.height / 2f + paddingBottomValue;
        }

        if (minLeft && x < minLeftValue)
        {
            x = minLeftValue;
        }
        if (maxRight && x > maxRightValue)
        {
            x = maxRightValue;
        }
        if (minBottom && y < minBottomValue)
        {
            y = minBottomValue;
        }
        if (maxTop && y > maxTopValue)
        {
            y = maxTopValue;
        }

        transform.localPosition = new Vector3(x, y, transform.localPosition.z);
    }
}
