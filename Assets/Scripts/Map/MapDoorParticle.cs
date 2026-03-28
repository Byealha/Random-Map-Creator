//스크립트 작성자: 이준호
//맵 클리어 전까지 막고있는 벽을 반환해주는 스크립트
using UnityEngine;

public class MapDoorParticle : MonoBehaviour {
    [SerializeField] private GameObject doorParticleTop;
    [SerializeField] private GameObject doorParticleBottom;
    [SerializeField] private GameObject doorParticleLeft;
    [SerializeField] private GameObject doorParticleRight;

    public GameObject GetParticleTop() {
        return doorParticleTop;
    }

    public GameObject GetParticleBottom() {
        return doorParticleBottom;
    }

    public GameObject GetParticleLeft() {
        return doorParticleLeft;
    }

    public GameObject GetParticleRight() {
        return doorParticleRight;
    }
}
