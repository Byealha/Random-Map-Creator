//스크립트 작성자: 이준호
//각 맵끼리 이어주기 위해 해당하는 벽을 없애주는 스크립트.
using UnityEngine;

public class MapDoorOpener : MonoBehaviour {
    [SerializeField] private GameObject DoorsTop;
    [SerializeField] private GameObject DoorsBottom;
    [SerializeField] private GameObject DoorsLeft;
    [SerializeField] private GameObject DoorsRight;

    public void MapCurrentDoorOpen(Direction dir) {
        switch (dir) {
            case Direction.Up:
                DoorsTop.SetActive(false);
                break;
            case Direction.Down:
                DoorsBottom.SetActive(false); 
                break;
            case Direction.Left:
                DoorsLeft.SetActive(false);
                break;
            case Direction.Right:
                DoorsRight.SetActive(false);
                break;
            default:
                Debug.Log("Error: MapDoorOpen(Direction dir)");
                DoorsTop.SetActive(false);
                break;
        }
    }

    public void MapNextDoorOpen(Direction dir) {
        switch (dir) {
            case Direction.Up:
                DoorsBottom.SetActive(false);
                break;
            case Direction.Down:
                DoorsTop.SetActive(false);
                break;
            case Direction.Left:
                DoorsRight.SetActive(false);
                break;
            case Direction.Right:
                DoorsLeft.SetActive(false);
                break;
            default:
                Debug.Log("Error: MapDoorOpen(Direction dir)");
                DoorsTop.SetActive(false);
                break;
        }
    }
}
