//스크립트 작성자: 이준호
//roomCount만큼 맵을 추가로 생성하는 스크립트.
using System;
using UnityEngine;

public class MapSpawner : MonoBehaviour {
    private MapGenerator mapGenerator;
    public event Action MapGeneratorFinished;

    [SerializeField] private int roomCount = 5;

    private void Awake() {
        mapGenerator = GetComponent<MapGenerator>();
    }

    private void Start() {
        MapSpawn();
    }

    private void MapSpawn() {
        for (int i = 0; i < roomCount; i++) {
            mapGenerator.MapGenerate();
        }
        MapGeneratorFinished?.Invoke();
    }
}
