//스크립트 작성자: 이준호
//다음 방향을 랜덤으로 산정해서 반환해주는 스크립트.
using UnityEngine;

public class MapNextDirector : MonoBehaviour {
    public Direction MapNextDirect() {
        int random = Random.Range(0, 4);
        switch (random) {
            case 0:
                return Direction.Up;
            case 1:
                return Direction.Down;
            case 2:
                return Direction.Left;
            case 3:
                return Direction.Right;
            default:
                Debug.Log("Error: MapNextDirect()");
                return Direction.Up;
        }
    }
}
