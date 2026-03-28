using UnityEngine;

public class EnemyTrack : MonoBehaviour {
    private EnemyAI enemyAI;

    private void Awake() {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void TrackAI() {
        // Track 상태가 아니면 Track 로직 금지
        if (!enemyAI.IsStateTrack()) {
            return;
        }
        
        if (enemyAI.GetCanTrackMove()) {
            if (enemyAI.GetPlayerDistance() > enemyAI.GetStopDistance()) {
                EnemyTrackMove();
            }
            else {
                enemyAI.GetForcedDirect(enemyAI.GetTargetPlayer());
            }
        }
    }

    private void EnemyTrackMove() {
        enemyAI.GetForcedDirect(enemyAI.GetTargetPlayer());
        enemyAI.NavAI(enemyAI.GetTargetPlayer().transform.position);
    }
}
