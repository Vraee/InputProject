using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ControlScheme : ScriptableObject
{
    public InputType LeftStickMove;
    public InputType RightStickMove;
    public InputType LeftStickPress;
    public InputType RightStickPress;
    public InputType DPadMove;
    public InputType FaceButtonUp;
    public InputType FaceButtonDown;
    public InputType FaceButtonLeft;
    public InputType FaceButtonRight;
    public InputType BumberLeft;
    public InputType BumberRight;
    public InputType TriggerLeft;
    public InputType TriggerRight;
    public InputType Back;
    public InputType Start;
}
