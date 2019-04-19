using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMapper : MonoBehaviour
{
    // not used, remove maybe?
    public enum ControllerType {
        Xbox360,
        PS4
    }
    //

    [SerializeField]
    private ControlScheme _xbox360Controller;
    public ControlScheme Xbox360Controller { get { return _xbox360Controller; } }
    private List<InputType> _xbox360Inputs = new List<InputType>();
    public  List<InputType> Xbox360Inputs { get { return _xbox360Inputs; } }

    [SerializeField]
    private ControlScheme _ps4Controller;
    public ControlScheme PS4Controller { get { return _ps4Controller; } }
    private List<InputType> _ps4Inputs = new List<InputType>();
    public List<InputType> PS4Inputs { get { return _ps4Inputs; } }

    private void Awake() {
        MapControllers();
    }

    public void MapControllers() {
        MapController(_xbox360Controller, ref _xbox360Inputs);
        MapController(_ps4Controller, ref _ps4Inputs);
    }

    private static void MapController(ControlScheme controller, ref List<InputType> inputs) {
        inputs.Add(controller.LeftStickMove);
        inputs.Add(controller.RightStickMove);
        inputs.Add(controller.LeftStickPress);
        inputs.Add(controller.RightStickPress);
        inputs.Add(controller.DPadMove);
        inputs.Add(controller.FaceButtonUp);
        inputs.Add(controller.FaceButtonDown);
        inputs.Add(controller.FaceButtonLeft);
        inputs.Add(controller.FaceButtonRight);
        inputs.Add(controller.BumberLeft);
        inputs.Add(controller.BumberRight);
        inputs.Add(controller.TriggerLeft);
        inputs.Add(controller.TriggerRight);
        inputs.Add(controller.Back);
        inputs.Add(controller.Start);
    }
}
