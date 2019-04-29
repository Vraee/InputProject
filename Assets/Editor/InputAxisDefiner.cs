using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InputAxisDefiner : MonoBehaviour
{
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
        public int Axis;
        public int JoyNum;
    }

    public static void AddNewAxis(InputAxisData axisData) {
        SerializedObject inputManager = LoadInputManager();
        SerializedProperty allAxesProperty = GetAllAxes(inputManager);
        allAxesProperty.arraySize++;
        inputManager.ApplyModifiedProperties();

        int lastIndex = GetAxesAmount(inputManager) - 1;

        EditAxisData(inputManager, lastIndex, axisData);
    }

    public static void EditAxis(string baseName, InputAxisData axisData) {
        SerializedObject inputManager = LoadInputManager();

        // TODO: get all indexes to edit based on baseName, move this to for loop
        EditAxisData(inputManager, 1000, axisData);
    }

    public static void DeteleAxis(string axisToDelete) {
        SerializedObject inputManager = LoadInputManager();
        SerializedProperty allAxesProperty = GetAllAxes(inputManager);
        int axesAmount = GetAxesAmount(inputManager);

        for (int i = 0; i < axesAmount; i++) {
            string axisName = FindAxisProperty(LoadInputManager(), "m_Name", i).stringValue;
            if (axisName.Contains(axisToDelete) || axisName == axisToDelete) {
                // TODO: delete axis
                // also better checks that unintented axes don't get deleted
            }
        }
    }

    public static List<string> GetUniqueAxisNames() {
        SerializedObject inputManager = LoadInputManager();
        List<string> axesNames = new List<string>();
        int axesAmount = GetAxesAmount(inputManager);

        for (int i = 0; i < axesAmount; i++) {
            string axisName = FindAxisProperty(inputManager, "m_Name", i).stringValue;
            int joyNum = FindAxisProperty(inputManager, "joyNum", i).intValue;

            if (axisName.EndsWith("Joy" + joyNum)) { // TODO: Better way for checking this?
                axisName = axisName.Split(new string[] { "Joy" }, StringSplitOptions.None)[0];
            }

            if (!axesNames.Contains(axisName))
                axesNames.Add(axisName);
        }

        return axesNames;
    }

    private static void EditAxisData(SerializedObject inputManager, int index, InputAxisData axisData) {
        FindAxisProperty(inputManager, "m_Name", index).stringValue = axisData.Name;
        FindAxisProperty(inputManager, "descriptiveName", index).stringValue = axisData.DescriptiveName;
        FindAxisProperty(inputManager, "descriptiveNegativeName", index).stringValue = axisData.DescriptiveNegativeName;
        FindAxisProperty(inputManager, "negativeButton", index).stringValue = axisData.NegativeButton;
        FindAxisProperty(inputManager, "positiveButton", index).stringValue = axisData.PositiveButton;
        FindAxisProperty(inputManager, "altNegativeButton", index).stringValue = axisData.AltNegativeButton;
        FindAxisProperty(inputManager, "altPositiveButton", index).stringValue = axisData.AltPositiveButton;
        FindAxisProperty(inputManager, "gravity", index).floatValue = axisData.Gravity;
        FindAxisProperty(inputManager, "dead", index).floatValue = axisData.Dead;
        FindAxisProperty(inputManager, "sensitivity", index).floatValue = axisData.Sensitivity;
        FindAxisProperty(inputManager, "snap", index).boolValue = axisData.Snap;
        FindAxisProperty(inputManager, "invert", index).boolValue = axisData.Invert;
        FindAxisProperty(inputManager, "type", index).intValue = 2;
        FindAxisProperty(inputManager, "axis", index).intValue = axisData.Axis;
        if (axisData.JoyNum != -1)
            FindAxisProperty(inputManager, "joyNum", index).intValue = axisData.JoyNum;
        inputManager.ApplyModifiedProperties();
    }

    // Reloaded everytime, since some changes might not otherwise be permanent; since this is an
    // editor script, it shouldn't matter
    private static SerializedObject LoadInputManager() {
        return new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/InputManager.asset")[0]);
    }

    private static int GetAxesAmount(SerializedObject inputManager) {
        return GetAllAxes(inputManager).arraySize;
    }

    private static SerializedProperty GetAllAxes(SerializedObject inputManager) {
        return inputManager.FindProperty("m_Axes");
    }

    private static SerializedProperty FindAxis(SerializedObject inputManager, int index) {
        SerializedProperty axis = inputManager.FindProperty("m_Axes.Array.data[" + index + "]");
        return axis;
    }

    private static SerializedProperty FindAxisProperty(SerializedObject inputManager, string propertyName, int index) {
        SerializedProperty child = inputManager.FindProperty("m_Axes.Array.data[" + index + "]." + propertyName);
        return child;
    }
}