using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    private void OnLStickMoved() {
        DebugInput("LeftStickMove");
    }

    private void OnRStickMoved() {
        DebugInput("RightStickMove");
    }

    private void OnLStickPressed() {
        DebugInput("LeftStickPress");
    }

    private void OnRStickPressed() {
        DebugInput("RightStickPress");
    }

    private void OnDPadUpPressed() {
        DebugInput("DPadUp");
    }

    private void OnDPadDownPressed() {
        DebugInput("DPadDown");
    }

    private void OnDPadLeftPressed() {
        DebugInput("DPapLeft");
    }

    private void OnDPadRightPressed() {
        DebugInput("DPadRight");
    }

    private void OnFaceButtonUpPressed() {
        DebugInput("FaceButtonUp");
    }

    private void OnFaceButtonDownPressed() {
        DebugInput("FaceButtonDown");
    }

    private void OnFaceButtonLeftPressed() {
        DebugInput("FaceButtonLeft");
    }

    private void OnFaceButtonRightPressed() {
        DebugInput("FaceButtonRight");
    }

    private void OnBumperLeftPressed() {
        DebugInput("BumberLeft");
    }

    private void OnBumperRightPressed() {
        DebugInput("BumberRight");
    }

    private void OnTriggerLeftPressed() {
        DebugInput("TriggerLeft");
    }

    private void OnTriggerRightPressed() {
        DebugInput("TriggerRight");
    }

    private void OnBackPressed() {
        DebugInput("Back");
    }

    private void OnStartPressed() {
        DebugInput("Start");
    }

    private void DebugInput(string input) {
        Debug.Log(input);
    }
}
