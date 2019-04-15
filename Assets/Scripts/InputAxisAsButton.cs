using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InputAxisAsButton : InputType
{
    public string MappableAxis;
    [Range(-1, 1)]
    public int PressedValue;
}
