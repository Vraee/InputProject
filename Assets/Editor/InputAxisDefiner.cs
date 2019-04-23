using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputAxisDefiner : MonoBehaviour
{
    private static SerializedObject _inputManager;
    public static SerializedObject InputManager {
        get {
            if (_inputManager == null)
                _inputManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
            return _inputManager;
        }
    }

    public enum AxisType {
        KeyOrMouseButton = 0,
        MouseMovement = 1,
        JoystickAxis = 2
    };

    public struct InputAxisData {
        public string Name;
        public string DescriptiveName;
        public string DescriptiveNegativeName;
        public string NegativeButton;
        public string PositiveButton;
        public string AltNegativeButton;
        public string AltPositiveButton;
        public float Gravity;
        public float Dead;
        public float Sensitivity;
        public bool Snap;
        public bool Invert;
        public AxisType Type;
        public int Axis;
        public int JoyNum;
    }

    public static void AddNewAxis(InputAxisData axisData) {
        SerializedProperty allAxesProperty = InputManager.FindProperty("m_Axes");
        allAxesProperty.arraySize++;
        InputManager.ApplyModifiedProperties();

        SerializedProperty newAxisProperty = allAxesProperty.GetArrayElementAtIndex(allAxesProperty.arraySize - 1);

        GetChildProperty(newAxisProperty, "m_Name").stringValue = axisData.Name;
        GetChildProperty(newAxisProperty, "descriptiveName").stringValue = axisData.DescriptiveName;
        GetChildProperty(newAxisProperty, "descriptiveNegativeName").stringValue = axisData.DescriptiveNegativeName;
        GetChildProperty(newAxisProperty, "negativeButton").stringValue = axisData.NegativeButton;
        GetChildProperty(newAxisProperty, "positiveButton").stringValue = axisData.PositiveButton;
        GetChildProperty(newAxisProperty, "altNegativeButton").stringValue = axisData.AltNegativeButton;
        GetChildProperty(newAxisProperty, "altPositiveButton").stringValue = axisData.AltPositiveButton;
        GetChildProperty(newAxisProperty, "gravity").floatValue = axisData.Gravity;
        GetChildProperty(newAxisProperty, "dead").floatValue = axisData.Dead;
        GetChildProperty(newAxisProperty, "sensitivity").floatValue = axisData.Sensitivity;
        GetChildProperty(newAxisProperty, "snap").boolValue = axisData.Snap;
        GetChildProperty(newAxisProperty, "invert").boolValue = axisData.Invert;
        GetChildProperty(newAxisProperty, "type").intValue = (int) axisData.Type;
        GetChildProperty(newAxisProperty, "axis").intValue = axisData.Axis;
        GetChildProperty(newAxisProperty, "joyNum").intValue = axisData.JoyNum;
        InputManager.ApplyModifiedProperties();
    }

    private static SerializedProperty GetChildProperty(SerializedProperty axis, string name) {
        SerializedProperty child = axis.Copy();
        child.Next(true);
        do {
            if (child.name == name) return child;
        } while (child.Next(false));
        return null;
    }
}