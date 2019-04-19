using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InputButton : InputType
{
    //public KeyCode MappableButton;
    [Range(0, 19)]
    public int ButtonNo = 0;
}
