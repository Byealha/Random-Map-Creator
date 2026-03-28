//스크립트 작성자: 이준호
//맵 생성에 관련된 스크립트들을 실질적으로 실행하는 감독 스크립트.
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    private MapInstantiator mapInstantiator;
    private MapNextDirector mapNextDirector;
    private GameObject savePrefab;
    private MapDoorSensor mapDoorSensor;
    [SerializeField] private GameObject firstObject;
    [SerializeField] private MapDoorOpener mapDoorOpener;

#if UNITY_EDITOR
    [ContextMenu("Auto Assign")]
    private void AutoAssign() {
        mapDoorOpener = GameObject.Find("FirstMap").GetComponent<MapDoorOpener>();
        mapDoorSensor = GameObject.Find("FirstMap").GetComponent<MapDoorSensor>();
        firstObject = GameObject.Find("FirstMap");
    }
#endif

    private void Awake() {
        mapInstantiator = GetComponent<MapInstantiator>();
        mapNextDirector = GetComponent<MapNextDirector>();
    }

    private void Start() {
        savePrefab = firstObject;
    }

    public void MapGenerate() {
        Direction dir = mapNextDirector.MapNextDirect();
        var temp = mapInstantiator.MapInstantiate(dir);

        mapDoorOpener.MapCurrentDoorOpen(temp.dir);
        if (mapDoorSensor != null)
            mapDoorSensor.DoorSensorCurrentActive(temp.dir);

        MapDoorParticleOpener.Instance.DoorParticleCurrentSave(savePrefab, temp.dir);
        savePrefab = temp.prefab;

        mapDoorOpener = savePrefab.GetComponent<MapDoorOpener>();
        mapDoorSensor = savePrefab.GetComponent<MapDoorSensor>();

        mapDoorOpener.MapNextDoorOpen(temp.dir);
        mapDoorSensor.DoorSensorNextActive(temp.dir);

        MapDoorParticleOpener.Instance.DoorParticleNextSave(temp.prefab, temp.dir);
    }

    public Vector3 GetPrefabPosition() {
        return savePrefab.transform.position;
    }
}
