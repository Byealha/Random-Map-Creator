//스크립트 작성자: 이준호
//디버그 키를 포함한 스크립트.
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugKeyMap : MonoBehaviour {
    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("DemoScene");
        }
    }
}
