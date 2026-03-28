using UnityEngine;

public class EnemySenseRange : MonoBehaviour {
    private EnemyAI enemyAI;

    private void Awake() {
        enemyAI = GetComponent<EnemyAI>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (enemyAI.GetCanAttack())
                enemyAI.SetStateAttack();
            else
                enemyAI.SetStateTrack();
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            enemyAI.SetStateIdle();
        }
    }
}
