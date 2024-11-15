using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TransformValueData : MonoBehaviour
{
    public GameObject objTransform;
    public UnityEvent compareValue, noCompareValue;
    public ValueType valueType;
    public FloatData compareObj;
    public bool isWatering;

    public enum ValueType
    {
        PositionX,
        PositionY,
        PositionZ,
        RotationX,
        RotationY,
        RotationZ,
        ScaleX,
        ScaleY,
        ScaleZ
    }
    
    private void Update()
    {
        CompareTransformValue();
    }
    
    public void CompareTransformValue()
    {
        float valueToCompare = GetValueToCompare();
        
        
        if (valueToCompare >= compareObj.value && valueToCompare <= maxCompareObj.value)
        {
            compareValue.Invoke();
            isWatering = true;
        }
        else
        {
            noCompareValue.Invoke();
            isWatering = false;
        }
    }

    // Get the value based on the chosen value type
    private float GetValueToCompare()
    {
        switch (valueType)
        {
            case ValueType.PositionX:
                return objTransform.transform.position.x;
            case ValueType.PositionY:
                return objTransform.transform.position.y;
            case ValueType.PositionZ:
                return objTransform.transform.position.z; 
            case ValueType.RotationX:
                return objTransform.transform.rotation.eulerAngles.x;
            case ValueType.RotationY:
                return objTransform.transform.rotation.eulerAngles.y;
            case ValueType.RotationZ:
                return objTransform.transform.rotation.eulerAngles.z;
            case ValueType.ScaleX:
                return objTransform.transform.localScale.x;
            case ValueType.ScaleY:
                return objTransform.transform.localScale.y;
            case ValueType.ScaleZ:
                return objTransform.transform.localScale.z;
            default:
                Debug.LogError("Invalid value type selected.");
                return 0f;
        }
    }
    
}

