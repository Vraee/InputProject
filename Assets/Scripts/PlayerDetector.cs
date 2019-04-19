using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    // TODO: rethink visibility
    private string[] _players;
    public string[] Players { get { return _players; } }

    private static string[] _controllers;
    public static string[] Controllers { get { return _controllers; } }

    private static Dictionary<string, List<InputType>> _playerControllers = new Dictionary<string, List<InputType>>();
    public static Dictionary<string, List<InputType>> PlayerControllers { get { return _playerControllers; } }

    private InputMapper _mapper;
    //

    // TODO: clean up this mess
    private void Awake() {
        _mapper = GetComponent<InputMapper>(); // other way to get InputMapper?

        string[] controllers = Input.GetJoystickNames();
        DetectPlayers(controllers);
        DetectControllerTypes(controllers);
    }

    private void DetectPlayers(string[] controllers) {
        _players = new string[controllers.Length];
        _controllers = new string[controllers.Length];

        for (int i = 0; i < controllers.Length; i++) {
            _players[i] = "P" + (i + 1);
            _controllers[i] = "joystick " + (i + 1) + " ";
        }
    }

    private void DetectControllerTypes(string[] controllers) {
        for (int i = 0; i < controllers.Length; i++) {
            Debug.Log(controllers[i]);
            switch (controllers[i]) {
                case "Wireless Controller":
                    _playerControllers.Add(_players[i], _mapper.PS4Inputs);
                    break;
                case "Controller (XBOX 360 For Windows)":
                //default:
                    _playerControllers.Add(_players[i], _mapper.Xbox360Inputs);
                    break;
            }
        }
    }
    //
}
