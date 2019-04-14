using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ControlScheme : ScriptableObject
{
    public GivenInput LeftStickMove;
    public GivenInput RightStickMove;
    public GivenInput LeftStickPress;
    public GivenInput RightStickPress;
    public GivenInput DPadUp;
    public GivenInput DPadDown;
    public GivenInput DPadLeft;
    public GivenInput DPadRight;
    public GivenInput FaceButtonUp;
    public GivenInput FaceButtonDown;
    public GivenInput FaceButtonLeft;
    public GivenInput FaceButtonRight;
    public GivenInput BumberLeft;
    public GivenInput BumberRight;
    public GivenInput TriggerLeft;
    public GivenInput TriggerRight;
    public GivenInput Back;
    public GivenInput Start;
}
