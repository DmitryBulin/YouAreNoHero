using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class FloatDisplay : MonoBehaviour
{

    public void UpdateValue(float value)
    {
        GetComponent<TMP_Text>().SetText(value.ToString());
    }

}
