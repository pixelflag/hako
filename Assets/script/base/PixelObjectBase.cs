using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelObjectBase : MonoBehaviour
{
    private Vector3 cashPosition;

    void LateUpdate()
    {
        cashPosition = transform.localPosition;
        transform.localPosition = new Vector3(
                        Mathf.RoundToInt(cashPosition.x),
                        Mathf.RoundToInt(cashPosition.y),
                        Mathf.RoundToInt(cashPosition.z)
                   );
    }

    void OnRenderObject()
    {
        transform.localPosition = cashPosition;
    }
}