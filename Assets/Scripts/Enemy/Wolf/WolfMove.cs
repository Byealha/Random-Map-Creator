using System.Collections;
using UnityEngine;

public class WolfMove : MonoBehaviour {
    private WolfMoveNav wolfMoveNav;

    private void Awake() {
        wolfMoveNav = GetComponent<WolfMoveNav>();
        wolfMoveNav.moveNavFinish += NextMove;
    }

    private void Start() {
        wolfMoveNav.StartChase();
    }

    private void NextMove() {
        StartCoroutine(NextMoveCoroutine());
    }

    private IEnumerator NextMoveCoroutine() {
        int random = Random.Range(1, 3);
        float timer = (float)random;
        while (timer > 0) {
            timer -= Time.deltaTime;
            yield return null;
        }
        wolfMoveNav.StartChase();
    }
}
