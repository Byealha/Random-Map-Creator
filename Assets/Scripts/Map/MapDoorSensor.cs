//스크립트 작성자: 이준호
//활성화된 맵끼리 지나가는 경계의 센서를 활성화해주는 스크립트.
using UnityEngine;

public class MapDoorSensor : MonoBehaviour {
    [SerializeField] private GameObject doorSensorTop;
    [SerializeField] private GameObject doorSensorBottom;
    [SerializeField] private GameObject doorSensorLeft;
    [SerializeField] private GameObject doorSensorRight;
    

    public void DoorSensorCurrentActive(Direction dir) {
        switch (dir) {
            case Direction.Up:
                doorSensorTop.SetActive(true);
                break;
            case Direction.Down:
                doorSensorBottom.SetActive(true);
                break;
            case Direction.Left:
                doorSensorLeft.SetActive(true);
                break;
            case Direction.Right:
                doorSensorRight.SetActive(true);
                break;
            default:
                break;
        }
    }

    public void DoorSensorNextActive(Direction dir) {
        switch (dir) {
            case Direction.Up:
                doorSensorBottom.SetActive(true);
                break;
            case Direction.Down:
                doorSensorTop.SetActive(true);
                break;
            case Direction.Left:
                doorSensorRight.SetActive(true);
                break;
            case Direction.Right:
                doorSensorLeft.SetActive(true);
                break;
            default:
                break;
        }
    }
}
