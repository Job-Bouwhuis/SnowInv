using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//[CustomEditor(typeof(ItemTool))]
//public class CustomEditorsTool : Editor
//{
//    GUIStyle horizontalLine;

//    private void OnEnable()
//    {
//        horizontalLine = new GUIStyle();
//        horizontalLine.normal.background = EditorGUIUtility.whiteTexture;
//        horizontalLine.margin = new RectOffset(0, 0, 4, 4);
//        horizontalLine.fixedHeight = 1;
//    }
//    public override void OnInspectorGUI()
//    {
//        DrawDefaultInspector();

//        serializedObject.Update();

//        ItemTool c = target as ItemTool;
//        EditorGUILayout.PrefixLabel("Source Image");
//        c.ItemSprite = (Sprite)EditorGUILayout.ObjectField(c.ItemSprite, typeof(Sprite), allowSceneObjects: false);

//        c.Name = EditorGUILayout.TextField("Name", c.Name);
//        c.Description = EditorGUILayout.TextField("Description", c.Description);
//        c.NuggetValue = EditorGUILayout.IntField("Value", c.NuggetValue);

//        GUILayout.Box(GUIContent.none, horizontalLine);

//        c.HarvestType = EditorGUILayout.TextField("Harvest Type", c.HarvestType);
//        c.HarvestDamage = EditorGUILayout.IntField("Harvest Damage", c.HarvestDamage);
//        c.MaxDurability = EditorGUILayout.IntField("Max Durability", c.MaxDurability);
//        c.Durability = EditorGUILayout.IntField("Durability", c.Durability);
//        c.SecondaryDamage = EditorGUILayout.IntField("Secondary Damage", c.SecondaryDamage);
//        serializedObject.ApplyModifiedProperties();

//        EditorUtility.SetDirty(c);
//    }
//}



    //[CustomEditor(typeof(ItemEquipment))]
    //public class CustomEditorsEquipment : Editor
    //{
    //    GUIStyle horizontalLine;

    //    private void OnEnable()
    //    {
    //        horizontalLine = new GUIStyle();
    //        horizontalLine.normal.background = EditorGUIUtility.whiteTexture;
    //        horizontalLine.margin = new RectOffset(0, 0, 4, 4);
    //        horizontalLine.fixedHeight = 1;
    //    }
    //    public override void OnInspectorGUI()
    //    {
    //        DrawDefaultInspector();

    //        serializedObject.Update();

    //        ItemEquipment c = target as ItemEquipment;
    //        EditorGUILayout.PrefixLabel("Source Image");
    //        c.ItemSprite = (Sprite)EditorGUILayout.ObjectField(c.ItemSprite, typeof(Sprite), allowSceneObjects: false);

    //        c.Name = EditorGUILayout.TextField("Name", c.Name);
    //        c.Description = EditorGUILayout.TextField("Description", c.Description);
    //        c.NuggetValue = EditorGUILayout.IntField("Value", c.NuggetValue);

    //        GUILayout.Box(GUIContent.none, horizontalLine);
    //        c.ArmorType = EditorGUILayout.TextField("Armor Type", c.ArmorType);
    //        c.ArmorValue = EditorGUILayout.IntField("Armor values", c.ArmorValue);
    //        c.MaxDurability = EditorGUILayout.IntField("Max Durability", c.MaxDurability);
    //        c.Durability = EditorGUILayout.IntField("Durability", c.Durability);
    //        serializedObject.ApplyModifiedProperties();

    //        EditorUtility.SetDirty(c);
    //    }
    //}

