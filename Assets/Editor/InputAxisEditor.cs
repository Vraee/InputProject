using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputAxisEditor : EditorWindow
{
    private string _name;
    private string _descriptiveName;
    private string _descriptiveNegativeName;
    private string _negativeButton;
    private string _positiveButton;
    private string _altNegativeButton;
    private string _altPositiveButton;
    private float _gravity;
    private float _dead;
    private float _sensitivity;
    private bool _snap;
    private bool _invert;
    private InputAxisDefiner.AxisType _type;
    private int _axis;

    [MenuItem("InputManager Editor/Input Axis Editor")]
    public static void ShowInputAcisEditor() {
        var window = GetWindow<InputAxisEditor>();
        window.titleContent = new GUIContent("Input Axis Editor");
    }

    private void OnGUI() {
        _name = EditorGUILayout.TextField("Axis name", _name);
        _descriptiveName = EditorGUILayout.TextField("Descriptive name", _descriptiveName);
        _descriptiveNegativeName = EditorGUILayout.TextField("Descriptive negative name", _descriptiveNegativeName);
        _negativeButton = EditorGUILayout.TextField("Negative button", _negativeButton);
        _positiveButton = EditorGUILayout.TextField("Positive button", _positiveButton);
        _altNegativeButton = EditorGUILayout.TextField("Alt negative button", _altNegativeButton);
        _altPositiveButton = EditorGUILayout.TextField("Alt positive button", _altPositiveButton);
        _gravity = EditorGUILayout.FloatField("Gravity", _gravity);
        _dead = EditorGUILayout.FloatField("Dead", _dead);
        _sensitivity = EditorGUILayout.FloatField("Sensitivity", _sensitivity);
        _snap = EditorGUILayout.Toggle("Snap", _snap);
        _invert = EditorGUILayout.Toggle("Invert", _invert);
        _type = (InputAxisDefiner.AxisType)EditorGUILayout.EnumPopup("Axis type", _type);
        //NOTE: axes start from zero
        _axis = EditorGUILayout.IntSlider("Axis num", _axis, 1, 28);

        if (GUILayout.Button("Add axis"))
            AddAxisForAllPossibleJoysticks();

        //TODO: Button for updating instead of adding
    }

    // InputManager can't be changed in-game and the numbering of joystick isn't always obvious; 
    // this adds all the possible variations (joysticks 1 to 16) for the given axis to InputManager
    private void AddAxisForAllPossibleJoysticks() {
        for (int i = 1; i <= 16; i++) {
            InputAxisDefiner.AddNewAxis(
                new InputAxisDefiner.InputAxisData {
                    Name = _name + "Joy" + i,
                    DescriptiveName = _descriptiveName,
                    DescriptiveNegativeName = _descriptiveNegativeName,
                    NegativeButton = _negativeButton,
                    PositiveButton = _positiveButton,
                    AltNegativeButton = _altNegativeButton,
                    AltPositiveButton = _altPositiveButton,
                    Gravity = _gravity,
                    Dead = _dead,
                    Sensitivity = _sensitivity,
                    Snap = _snap,
                    Invert = _invert,
                    Type = _type,
                    Axis = _axis - 1,
                    JoyNum = i
                }
            );
        }
    }
}
