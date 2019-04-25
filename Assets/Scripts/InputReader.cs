using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private void Update() {
        CheckForInput();
    }

    private void CheckForInput() {
        if (PlayerDetector.PlayerControllers != null) {
            int i = 0;
            foreach (KeyValuePair<string, List<InputType>> playerController in PlayerDetector.PlayerControllers) {
                int controller = PlayerDetector.Controllers[i];
                i++;
                foreach (InputType input in playerController.Value) {
                    switch (input) {
                        case InputAxisAsButton axisAsButton:
                            CheckForAxisAsButtonInput(input as InputAxisAsButton, playerController.Key, controller);
                            break;
                        case InputAxis axis:
                            CheckForAxisInput(input as InputAxis, playerController.Key, controller);
                            break;
                        case InputButton button:
                            CheckForButtonInput(input as InputButton, playerController.Key, controller);
                            break;
                    }
                }
            }
        }
    }

    private void CheckForAxisAsButtonInput(InputAxisAsButton input, string player, int controller) {
        if (Input.GetAxisRaw(input.MappableAxis + "Joy" + controller) == input.PressedValue) {
            MyDebugger.FormatDebug("PLAYER {0} {1} axis as button input read", player, input.name);
            // TODO: Trigger event
        }
    }

    private void CheckForAxisInput(InputAxis input, string player, int controller) {
        Vector2 axisInput = new Vector2(Input.GetAxisRaw(input.MappableAxisX + "Joy" + controller), Input.GetAxisRaw(input.MappableAxisY + "Joy" + controller));
        if (axisInput != Vector2.zero) {
            axisInput.Normalize();
            MyDebugger.FormatDebug("PLAYER {0} {1} axis input read. Axis X: {2} Axis Y: {3}", player, input.name, input.MappableAxisX, input.MappableAxisY);
        }
    }

    private void CheckForButtonInput(InputButton input, string player, int controller) {
        if (Input.GetKeyDown("joystick " + controller + " button " + input.ButtonNo)) {
            MyDebugger.FormatDebug("PLAYER {0} controller {1} {2} button input read", player, controller, input.name);
            // TODO: Trigger event
        }
    }
}
