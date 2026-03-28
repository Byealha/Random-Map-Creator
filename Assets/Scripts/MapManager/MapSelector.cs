//스크립트 작성자: 이준호
//맵을 생성할 때 어떤 맵을 생성할지 결정하는 스크립트.
#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections.Generic;
using UnityEngine;

public class MapSelector : MonoBehaviour {
    [SerializeField] private List<GameObject> RoomPrefabs = new List<GameObject>();
    private List<GameObject> pool = new List<GameObject>();
    private int maxRoom;

#if UNITY_EDITOR
    [ContextMenu("Auto Assign")]
    private void AutoAssign() {
        RoomPrefabs.Clear();
        
        string[] guids = AssetDatabase.FindAssets($"t:Prefab", new[] { "Assets/Prefabs/SampleMap" });

        foreach (var guid in guids) {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            RoomPrefabs.Add(prefab);
        }

        EditorUtility.SetDirty(this);
    }
#endif

    private void Awake() {
        pool = new List<GameObject>(RoomPrefabs);
        maxRoom = pool.Count;
    }

    public GameObject MapSelect() {
        if (pool.Count == 0) {
            Debug.Log("No Prefabs. You can Only create up to " + maxRoom + " rooms.");
            return null;
        }
        int random = Random.Range(0, pool.Count);
        GameObject selected = pool[random];
        pool.RemoveAt(random);
        return selected;
    }

}
