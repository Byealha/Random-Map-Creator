//스크립트 작성자: 이준호
//화면 연출을 담당하는 스크립트. (페이드 인 아웃)
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EventScreenManager : MonoBehaviour {
    [SerializeField] private Image eventScreen;

#if UNITY_EDITOR
    [ContextMenu("Auto Assign")]
    private void AutoAssign() {
        eventScreen = GameObject.Find("EventScreen").GetComponent<Image>();
    }
#endif

    private void Start() {
        StartCoroutine(EventScreenFirstCoroutine());
    }

    public void EventScreenShow() {
        StartCoroutine(EventScreenShowCoroutine());
    }

    public void EventScreenHide() {
        StartCoroutine(EventScreenHideCoroutine());
    }

    private IEnumerator EventScreenFirstCoroutine() {
        float fadeCount = 0.5f;
        eventScreen.color = new Color(0, 0, 0, 0);
        while (fadeCount > 0) {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            eventScreen.color = new Color(0, 0, 0, fadeCount);
        }
        eventScreen.gameObject.SetActive(false);
    }

    private IEnumerator EventScreenShowCoroutine() {
        float fadeCount = 0;
        eventScreen.gameObject.SetActive(true);
        eventScreen.color = new Color(0, 0, 0, 0);
        while (fadeCount <= 1) {
            fadeCount += 0.02f;
            yield return new WaitForSeconds(0.01f);
            eventScreen.color = new Color(0, 0, 0, fadeCount);
        }
    }

    private IEnumerator EventScreenHideCoroutine() {
        float fadeCount = 1f;
        eventScreen.color = new Color(0, 0, 0, 0);
        while (fadeCount > 0) {
            fadeCount -= 0.02f;
            yield return new WaitForSeconds(0.01f);
            eventScreen.color = new Color(0, 0, 0, fadeCount);
        }
        eventScreen.gameObject.SetActive(false);
    }
}
