//스크립트 작성자: 이준호
//포탈이 마지막 맵에 위치하게 해주는 스크립트.
using UnityEngine;

public class PortalPosition : MonoBehaviour {
    [SerializeField] private MapSpawner mapSpawner;
    [SerializeField] private MapGenerator mapGenerator;

#if UNITY_EDITOR
    [ContextMenu("Auto Assign")]
    private void AutoAssign() {
        mapSpawner = GameObject.Find("MapManager").GetComponent<MapSpawner>();
        mapGenerator = GameObject.Find("MapManager").GetComponent<MapGenerator>();
    }
#endif

    private void OnEnable() {
        mapSpawner.MapGeneratorFinished += PortalSetPosition;
    }

    private void OnDisable() {
        mapSpawner.MapGeneratorFinished -= PortalSetPosition;
    }

    public void PortalSetPosition() {
        transform.position = mapGenerator.GetPrefabPosition() + new Vector3(0, -5, 0);
    }
}
