using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputAxisEditor : EditorWindow
{
    private enum _tab {
        Add = 0,
        Edit = 1,
        Remove = 2
    }

    private _tab _currentTab = 0;
    private string[] _tabHeaders = { "Add", "Edit", "Remove" };

    private int _chosenAxis;

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
    private int _axis;

    [MenuItem("InputManager Editor/Contoller Axis Editor")]
    public static void ShowInputAxisEditor() {
        var window = GetWindow<InputAxisEditor>();
        window.titleContent = new GUIContent("Contoller Axis Editor");
    }

    private void OnGUI() {
        _currentTab = (_tab) GUILayout.Toolbar((int) _currentTab, _tabHeaders);
        switch (_currentTab) {
            case _tab.Add:
                GUILayout.Label("Add new axis", EditorStyles.boldLabel);
                GUILayout.Label("Adds the given axis to InputManager for all possible controllers (1 to 16)");
                ShowLayout();

                if (!string.IsNullOrEmpty(_name))
                    if (GUILayout.Button("Add axis"))
                        AddAxisForAllPossibleJoysticks();

                break;
            case _tab.Edit:
                GUILayout.Label("Edit existing axis", EditorStyles.boldLabel);
                ShowAxisList();
                ShowLayout();

                if (GUILayout.Button("Edit axis"))
                    EditAxisForAllJoysticks();

                break;
            case _tab.Remove:
                GUILayout.Label("Remove existing axis", EditorStyles.boldLabel);
                ShowAxisList();

                if (GUILayout.Button("Delete axis"))
                    DeleteAxisForAllJoysticks();

                break;
        }
        //TODO: Button for updating instead of adding
    }

    private void ShowLayout() {
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
        //NOTE: axes start from zero
        _axis = EditorGUILayout.IntSlider("Axis num", _axis, 1, 28);
    }

    private void ShowAxisList() {
        string[] axisNames = InputAxisDefiner.GetUniqueAxisNames().ToArray();
        _chosenAxis = EditorGUILayout.Popup(_chosenAxis, axisNames);
    }

    // InputManager can't be changed in-game and the numbering of joystick isn't always obvious; 
    // this adds all the possible variations (joysticks 1 to 16) for the given axis to InputManager
    private void AddAxisForAllPossibleJoysticks() {
        for (int i = 1; i <= 16; i++) { // TODO: move this loop to InputAxisDefiner for consistency?
            InputAxisDefiner.AddNewAxis(CreateAxisData(i));
        }
    }

    private void EditAxisForAllJoysticks() {
        //InputAxisDefiner.EditAxis("", CreateAxisData(-1));
    }

    private void DeleteAxisForAllJoysticks() {
        //InputAxisDefiner.DeteleAxis("");
    }

    private InputAxisDefiner.InputAxisData CreateAxisData(int joyNum) {
        InputAxisDefiner.InputAxisData axisData = new InputAxisDefiner.InputAxisData {
            Name = _name + "Joy" + joyNum,
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
            Axis = _axis - 1,
            JoyNum = joyNum
        };

        return axisData;
    }
}
