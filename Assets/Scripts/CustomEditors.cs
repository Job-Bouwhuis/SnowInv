using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemTool))]
public class CustomEditors : Editor
{
    GUIStyle horizontalLine;
    GUIStyle descriptoonArea;

    private void OnEnable()
    {
        
        horizontalLine = new GUIStyle();
        horizontalLine.normal.background = EditorGUIUtility.whiteTexture;
        horizontalLine.margin = new RectOffset(0, 0, 4, 4);
        horizontalLine.fixedHeight = 1;
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        serializedObject.Update();

        ItemTool c = target as ItemTool;
        EditorGUILayout.PrefixLabel("Source Image");
        c.ItemSprite = (Sprite)EditorGUILayout.ObjectField(c.ItemSprite, typeof(Sprite), allowSceneObjects: false);

        c.Name = EditorGUILayout.TextField("Name", c.Name);
        c.Description = EditorGUILayout.TextField ("Description", c.Description);
        c.Value = EditorGUILayout.IntField("Value", c.Value);

        GUILayout.Box(GUIContent.none, horizontalLine);

        c.HarvestType = EditorGUILayout.TextField("Harvest Type", c.HarvestType);
        c.HarvestDamage = EditorGUILayout.IntField("Harvest Damage", c.HarvestDamage);
        c.MaxDurability = EditorGUILayout.IntField("Max Durability", c.MaxDurability);
        c.Durability = EditorGUILayout.IntField("Durability", c.Durability);
        c.SecondaryDamage = EditorGUILayout.IntField("Secondary Damage", c.SecondaryDamage);
        serializedObject.ApplyModifiedProperties();


        //base.OnInspectorGUI();
    }
}
