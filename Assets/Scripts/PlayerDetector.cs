using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    // TODO: rethink visibility
    private string[] _players;
    public string[] Players { get { return _players; } } // TODO: is this needed?

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
        //DetectControllerTypes(controllers);
    }

    private void DetectPlayers(string[] controllers) {
        int playerAmount = controllers.Count(c => !string.IsNullOrWhiteSpace(c));

        _players = new string[playerAmount];
        _controllers = new string[playerAmount];

        int playerIndex = 0;

        for (int i = 0; i < controllers.Length; i++) {
            if (!string.IsNullOrWhiteSpace(controllers[i])) {
                _players[playerIndex] = "P" + (playerIndex + 1);
                _controllers[playerIndex] = "joystick " + (i + 1) + " ";
                DetectControllerType(controllers[i], _players[playerIndex]);
                playerIndex++;
            }
        }
    }

    private void DetectControllerType(string controller, string player) {
        switch (controller) {
            case "Wireless Controller":
                _playerControllers.Add(player, _mapper.PS4Inputs);
                break;
            case "Controller (XBOX 360 For Windows)":
            default:
                _playerControllers.Add(player, _mapper.Xbox360Inputs);
                break;
        }
    }

    /*private void DetectControllerTypes(string[] controllers) {
        for (int i = 0; i < controllers.Length; i++) {
            Debug.Log(controllers[i]);
            switch (controllers[i]) {
                case "Wireless Controller":
                    _playerControllers.Add(_players[i], _mapper.PS4Inputs);
                    break;
                case "Controller (XBOX 360 For Windows)":
                default:
                    _playerControllers.Add(_players[i], _mapper.Xbox360Inputs);
                    break;
            }
        }
    }*/
    //
}
