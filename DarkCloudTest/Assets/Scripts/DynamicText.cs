using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicText : MonoBehaviour
{
    public Text text;
    public void UpdateName(string name)
    {
        this.text.text = name;
    }
    
}
