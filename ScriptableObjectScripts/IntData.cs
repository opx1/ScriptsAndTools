using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int value;

    public void UpdateValue(int number)
    {
        value += number;
    }

    public void ReplaceValue(int number)
    {
        value = number;
    }

    public void DisplayImage(Image img)
    {
        img.fillAmount = value;
    }

    public void DisplayNumber(Text txt)
    {
        txt.text = value.ToString();
    }  
    
    public void SetValue(IntData obj)
    {
        value = obj.value;
    }

    public void CompareValue(IntData obj)
    {
        if (value >= obj.value)
        {
         
        }
        else
        {
            value = obj.value;
        }
    }
}
