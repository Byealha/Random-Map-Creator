//스크립트 작성자: 이준호
//맵을 복제해서 생성하는 스크립트.
//맵이 이미 있는 자리에 중복되서 생성되지 못하게 막는 스크립트.
using System.Collections.Generic;
using UnityEngine;

public class MapInstantiator : MonoBehaviour {
    private MapSelector mapSelector;
    [SerializeField] private float hInterval = 30f;
    [SerializeField] private float vInterval = 20f;
    private Vector2Int currentCoord = Vector2Int.zero;
    private HashSet<Vector2Int> occupiedCoords = new HashSet<Vector2Int>();

    private void Awake() {
        mapSelector = GetComponent<MapSelector>();
        occupiedCoords.Add(currentCoord);
    }

    public (GameObject prefab, Direction dir) MapInstantiate(Direction firstDir) {
        List<Direction> directions = new List<Direction> {
            Direction.Up, Direction.Down, Direction.Left, Direction.Right
        };

        ShuffleDir(directions);

        directions.Remove(firstDir);
        directions.Insert(0, firstDir);

        foreach (Direction direct in directions) {
            Vector2Int offset = GetOffset(direct);
            Vector2Int nextCoord = currentCoord + offset;

            if (occupiedCoords.Contains(nextCoord)) {
                continue;
            }

            Vector3 WorldPos = new Vector3(nextCoord.x * hInterval, nextCoord.y * vInterval, 0f);

            GameObject prefab = Instantiate(mapSelector.MapSelect(), WorldPos, Quaternion.Euler(-90f, 0, 0));

            currentCoord = nextCoord;
            occupiedCoords.Add(currentCoord);
            return (prefab, direct);
        }
        return (null, Direction.None);
    }

    private Vector2Int GetOffset(Direction dir) {
        switch (dir) {
            case Direction.Up:
                return Vector2Int.up;
            case Direction.Down:
                return Vector2Int.down;
            case Direction.Left:
                return Vector2Int.left;
            case Direction.Right:
                return Vector2Int.right;
            case Direction.None:
                return Vector2Int.zero;
            default:
                Debug.Log("Error: GetOffset(Direction dir)");
                return Vector2Int.zero;
        }
    }

    private void ShuffleDir(List<Direction> list) {
        for (int i = 0; i < list.Count; i++) {
            int rand = Random.Range(i, list.Count);
            (list[i], list[rand]) = (list[rand], list[i]);
        }
    }
}
