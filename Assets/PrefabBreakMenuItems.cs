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
        Undo.RegisterCompleteObjectUndo(targets, "Breaking multiple _prefab instances definitively");

        Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/dummy._prefab");
        foreach (var target in targets)
        {
            PrefabUtility.ReplacePrefab(target, prefab, ReplacePrefabOptions.ConnectToPrefab);
            PrefabUtility.DisconnectPrefabInstance(target);
        }
        AssetDatabase.DeleteAsset("Assets/dummy._prefab");

        Undo.RecordObjects(targets, "Breaking multiple _prefab instances definitively");
    }


    // ��������� ������� ����� � ������ ���������� �������
    // ���������� � "undo" ��� ������
    public static void BreakInstanceDefinitive(GameObject target)
    {
        Undo.RegisterCompleteObjectUndo(target, "Breaking single _prefab instance definitively");

        Object prefab = PrefabUtility.CreateEmptyPrefab("Assets/dummy._prefab");

        PrefabUtility.ReplacePrefab(target, prefab, ReplacePrefabOptions.ConnectToPrefab);
        PrefabUtility.DisconnectPrefabInstance(target);

        AssetDatabase.DeleteAsset("Assets/dummy._prefab");
    }

    #endregion
}