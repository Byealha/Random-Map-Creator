//스크립트 작성자: 이준호
//센서 오브젝트에 플레이어가 닿으면 입출구를 막는 스크립트.
using System.Collections.Generic;
using UnityEngine;

public class MapDoorSensorTrigger : MonoBehaviour {
    [SerializeField] private List<GameObject> otherSensor = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            MapDoorParticleOpener.Instance.DoorParticleClose();
            for (int i = 0; i < otherSensor.Count; i++) {
                otherSensor[i].SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
