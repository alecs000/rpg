using UnityEditor;
using UnityEngine;
using System.Linq;

public static class PrefabBreakMenuItems
{
    #region MENU_ITEMS

    // ��������� ������� ����� � ��������� �������� 
    [MenuItem("GameObject/Break Prefab Instance Definitive %&b", false, 29)]
    [MenuItem("CONTEXT/Object/Break Prefab Instance Definitive", false, 301)]
    static void MenuBreakInstanceDefinitive()
    {
        GameObject[] breakTargets = Selection.gameObjects;
        Selection.activeGameObject = null;
        BreakInstancesDefinitive(breakTargets);
        Selection.objects = breakTargets;
    }

    // ���������, �������� �� ��������� ������� ������
    [MenuItem("CONTEXT/Object/Break Prefab Instance Definitive", true)]
    [MenuItem("GameObject/Break Prefab Instance Definitive %&b", true)]
    static bool PrefabCheck()
    {
        GameObject[] goSelection = Selection.gameObjects;

        return (goSelection.Any(x => PrefabUtility.GetPrefabParent(x)));
    }

    #endregion

    #region LOGIC

    // ��������� ������� ����� � ��������� �������� 
    // ���������� � "undo" ��� ������
    public static void BreakInstancesDefinitive(GameObject[] targets)
    {
        Undo.RegisterCompleteObjectUndo(targets, "Breaking multiple prefab instances definitively");

        Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/dummy.prefab");
        foreach (var target in targets)
        {
            PrefabUtility.ReplacePrefab(target, prefab, ReplacePrefabOptions.ConnectToPrefab);
            PrefabUtility.DisconnectPrefabInstance(target);
        }
        AssetDatabase.DeleteAsset("Assets/dummy.prefab");

        Undo.RecordObjects(targets, "Breaking multiple prefab instances definitively");
    }


    // ��������� ������� ����� � ������ ���������� �������
    // ���������� � "undo" ��� ������
    public static void BreakInstanceDefinitive(GameObject target)
    {
        Undo.RegisterCompleteObjectUndo(target, "Breaking single prefab instance definitively");

        Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/dummy.prefab");

        PrefabUtility.ReplacePrefab(target, prefab, ReplacePrefabOptions.ConnectToPrefab);
        PrefabUtility.DisconnectPrefabInstance(target);

        AssetDatabase.DeleteAsset("Assets/dummy.prefab");
    }

    #endregion
}