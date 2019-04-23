using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerTest : MonoBehaviour
{
    void Start()
    {
        InputAxisDefiner.InputAxisData testAxis = new InputAxisDefiner.InputAxisData {
            Name = "test",
            JoyNum = 10
        };

        InputAxisDefiner.AddNewAxis(testAxis);
    }
}
