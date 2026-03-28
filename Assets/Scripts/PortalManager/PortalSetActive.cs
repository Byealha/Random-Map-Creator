//스크립트 작성자: 이준호
//다음 스테이지로 이동하는 포탈 활성화 여부를 결정하는 스크립트.
using UnityEngine;

public class PortalSetActive : MonoBehaviour {
    [SerializeField] private MapDoorParticleOpener mapDoorParticleOpener;
    [SerializeField] private GameObject portalObject;

    private bool state = true;

#if UNITY_EDITOR
    [ContextMenu("Auto Assign")]
    private void AutoAssign() {
        portalObject = GameObject.Find("Portal");
        mapDoorParticleOpener = GameObject.Find("MapManager").GetComponent<MapDoorParticleOpener>();
    }
#endif

    private void OnEnable() {
        mapDoorParticleOpener.PortalOpenFinished += PortalActive;
    }

    private void PortalActive() {
        state = !state;
        portalObject.SetActive(state);
    }
}
