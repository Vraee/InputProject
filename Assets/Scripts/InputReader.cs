using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    // TODO: delet dis
    private string _player = "P1";
    [SerializeField]
    private ControlScheme _controller;
    private List<InputType> _inputs = new List<InputType>();
    //

    private void Awake() {
        _inputs.Add(_controller.LeftStickMove);
        _inputs.Add(_controller.RightStickMove);
        _inputs.Add(_controller.LeftStickPress);
        _inputs.Add(_controller.RightStickPress);
        _inputs.Add(_controller.DPadUp);
        _inputs.Add(_controller.DPadDown);
        _inputs.Add(_controller.DPadLeft);
        _inputs.Add(_controller.DPadRight);
        _inputs.Add(_controller.FaceButtonUp);
        _inputs.Add(_controller.FaceButtonDown);
        _inputs.Add(_controller.FaceButtonLeft);
        _inputs.Add(_controller.FaceButtonRight);
        _inputs.Add(_controller.BumberLeft);
        _inputs.Add(_controller.BumberRight);
        _inputs.Add(_controller.TriggerLeft);
        _inputs.Add(_controller.TriggerRight);
        _inputs.Add(_controller.Back);
        _inputs.Add(_controller.Start);
    }

    private void Update() {
        CheckForInput();
    }

    private void CheckForInput() {
        foreach (InputType input in _inputs) {
            switch (input) {
                case InputAxisAsButton axisAsButton:
                    CheckForAxisAsButtonInput(input as InputAxisAsButton);
                    break;
                case InputAxis axis:
                    CheckForAxisInput(input as InputAxis);
                    break;
                case InputButton button:
                    CheckForButtonInput(input as InputButton);
                    break;
            }
        }
    }

    private void CheckForAxisAsButtonInput(InputAxisAsButton input) {
        if (Input.GetAxisRaw(input.MappableAxis + _player) == input.PressedValue) {
            Debug.Log(input.name + " Axis as button input read");
            // TODO: Trigger event
        }
    }

    private void CheckForAxisInput(InputAxis input) {
        Vector2 axisInput = new Vector2(Input.GetAxisRaw(input.MappableAxisX + _player), Input.GetAxisRaw(input.MappableAxisY + _player)).normalized;
        if (axisInput != Vector2.zero) {
            Debug.Log(input.name + " Axis input read");
        }
    }

    private void CheckForButtonInput(InputButton input) {
        if (Input.GetKeyDown(input.MappableButton)) {
            Debug.Log(input.name + " Button input read");
            // TODO: Trigger event
        }
    }
}
