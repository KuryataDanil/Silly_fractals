using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private float baseValue;

    private float modifier = 0;

    public float GetValue
    {
        get { return baseValue + baseValue * modifier; }
    }

    public void AddModifier(float x)
    {
        modifier += x;
    }

    public void AddBaseValue(float x)
    {
        baseValue += x;
    }

    public void SetBaseValue(float x)
    {
        baseValue = x;
    }
}

[CustomPropertyDrawer(typeof(Stat))]
public class MyScriptDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        EditorGUI.PropertyField(position, property.FindPropertyRelative("baseValue"), GUIContent.none);
    }
}