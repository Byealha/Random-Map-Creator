//스크립트 작성자: 이준호
//포탈을 탔을 때 새로운 스테이지로 이동(씬 이동)하는 스크립트.
//LoadScene으로 구현되어있음. 추후 수정 필요.
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalNextStage : MonoBehaviour {
    [SerializeField] private EventScreenManager eventScreenManager;
    private bool portalEnter = false;

#if UNITY_EDITOR
    [ContextMenu("Auto Assign")]
    private void AutoAssign() {
        eventScreenManager = GameObject.Find("EventManager").GetComponent<EventScreenManager>();
    }
#endif

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player") && !portalEnter) {
            StartCoroutine(MoveNextStage());
        }
    }

    private IEnumerator MoveNextStage() {
        portalEnter = true;
        eventScreenManager.EventScreenShow();
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("DemoScene");
    }
}
