using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    // TODO: delet dis
    /*private string _player = "P1";
    [SerializeField]
    private ControlScheme _controller;
    private List<InputType> _inputs = new List<InputType>();*/
    //

    private void Update() {
        CheckForInput();
    }

    private void CheckForInput() {
        if (PlayerDetector.PlayerControllers != null) {
            int i = 0;
            foreach (KeyValuePair<string, List<InputType>> playerController in PlayerDetector.PlayerControllers) {
                string controller = PlayerDetector.Controllers[i];
                i++;
                foreach (InputType input in playerController.Value) {
                    switch (input) {
                        case InputAxisAsButton axisAsButton:
                            CheckForAxisAsButtonInput(input as InputAxisAsButton, playerController.Key);
                            break;
                        case InputAxis axis:
                            CheckForAxisInput(input as InputAxis, playerController.Key);
                            break;
                        case InputButton button:
                            CheckForButtonInput(input as InputButton, playerController.Key, controller);
                            break;
                    }
                }
            }
        }
    }

    private void CheckForAxisAsButtonInput(InputAxisAsButton input, string player) {
        if (Input.GetAxisRaw(input.MappableAxis + player) == input.PressedValue) {
            Debug.Log("PLAYER " + player + " " + input.name + " Axis as button input read");
            // TODO: Trigger event
        }
    }

    private void CheckForAxisInput(InputAxis input, string player) {
        Vector2 axisInput = new Vector2(Input.GetAxisRaw(input.MappableAxisX + player), Input.GetAxisRaw(input.MappableAxisY + player));
        if (axisInput != Vector2.zero) {
            axisInput.Normalize();
            Debug.Log("PLAYER " + player + " " + input.name + " Axis input read. AxisX: " + input.MappableAxisX + player + " Axis Y: " + input.MappableAxisY + player);
        }
    }

    private void CheckForButtonInput(InputButton input, string player, string controller) {
        if (Input.GetKeyDown(controller + "button " + input.ButtonNo)) {
            Debug.Log("PLAYER " + player + " " + input.name + " Button input read");
            // TODO: Trigger event
        }
    }
}
