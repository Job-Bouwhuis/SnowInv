using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemTool))]
public class CustomEditorsTool : Editor
{
    GUIStyle horizontalLine;

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
        c.Description = EditorGUILayout.TextField("Description", c.Description);
        c.NuggetValue = EditorGUILayout.IntField("Value", c.NuggetValue);

        GUILayout.Box(GUIContent.none, horizontalLine);

        c.HarvestType = EditorGUILayout.TextField("Harvest Type", c.HarvestType);
        c.HarvestDamage = EditorGUILayout.IntField("Harvest Damage", c.HarvestDamage);
        c.MaxDurability = EditorGUILayout.IntField("Max Durability", c.MaxDurability);
        c.Durability = EditorGUILayout.IntField("Durability", c.Durability);
        c.SecondaryDamage = EditorGUILayout.IntField("Secondary Damage", c.SecondaryDamage);
        serializedObject.ApplyModifiedProperties();


        //base.OnInspectorGUI();
    }




    [CustomEditor(typeof(ItemEquipment))]
    public class CustomEditorsEquipment : Editor
    {
        GUIStyle horizontalLine;

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

            ItemEquipment c = target as ItemEquipment;
            EditorGUILayout.PrefixLabel("Source Image");
            c.ItemSprite = (Sprite)EditorGUILayout.ObjectField(c.ItemSprite, typeof(Sprite), allowSceneObjects: false);

            c.Name = EditorGUILayout.TextField("Name", c.Name);
            c.Description = EditorGUILayout.TextField("Description", c.Description);
            c.NuggetValue = EditorGUILayout.IntField("Value", c.NuggetValue);

            GUILayout.Box(GUIContent.none, horizontalLine);
            c.ArmorType = EditorGUILayout.TextField("Armor Type", c.ArmorType);
            c.ArmorValue = EditorGUILayout.IntField("Armor values", c.ArmorValue);
            c.MaxDurability = EditorGUILayout.IntField("Max Durability", c.MaxDurability);
            c.Durability = EditorGUILayout.IntField("Durability", c.Durability);
            serializedObject.ApplyModifiedProperties();


            //base.OnInspectorGUI();
        }
    }

    //[CustomEditor(typeof(ItemPickup))]
    //public class CustomEditorItemPickup : Editor
    //{
    //    ItemPickup c;
    //    public override void OnInspectorGUI()
    //    {
    //        c = target as ItemPickup;
    //        EditorGUILayout.PrefixLabel("Put an object in one of these boxes");
    //        if (c.tool == null && c.equipment == null)
    //            ShowAll();
    //        else if (c.tool == null)
    //            c.equipment = (ItemEquipment)EditorGUILayout.ObjectField(c.equipment, typeof(ItemEquipment), allowSceneObjects: false);
    //        else
    //            c.tool = (ItemTool)EditorGUILayout.ObjectField(c.tool, typeof(ItemTool), allowSceneObjects: false);

    //        base.OnInspectorGUI();
    //    }
    //    void ShowAll()
    //    {
    //        if(c != null)
    //        {
    //            c.tool = (ItemTool)EditorGUILayout.ObjectField(c.tool, typeof(ItemTool), allowSceneObjects: false);
    //            c.equipment = (ItemEquipment)EditorGUILayout.ObjectField(c.equipment, typeof(ItemEquipment), allowSceneObjects: false);
    //        }
    //    }
    //}
}
