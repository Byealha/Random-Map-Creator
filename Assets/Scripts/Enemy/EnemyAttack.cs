using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    private EnemyAI enemyAI;
    private bool attackState = false;

    private void Awake() {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void AttackAI() {
        
        if (!enemyAI.IsStateAttack()) {
            return;
        }

        if (enemyAI.GetCanTrackMove()) {
            if (enemyAI.GetPlayerDistance() > enemyAI.GetStopDistance()) {
                EnemyAttackMove();
            }
            else {
                enemyAI.NavAI(transform.position);

                if (!attackState) {
                    StartCoroutine(Attack(enemyAI.GetAttackCooldown()));
                }
                else {
                    enemyAI.GetForcedDirect(enemyAI.GetTargetPlayer());
                }
            }
        }
    }

    private IEnumerator Attack(float cooltime) {
        enemyAI.NavAI(transform.position);

        attackState = true;
        enemyAI.SetCanTrackMove(false);

        enemyAI.GetForcedDirect(enemyAI.GetTargetPlayer());

        yield return new WaitForSeconds(0.01f);

        StartCoroutine(AttackCoroutine());

        yield return new WaitForSeconds(cooltime);

        attackState = false;
        enemyAI.SetCanTrackMove(true);
    }

    private IEnumerator AttackCoroutine() {
        
        Debug.Log("АјАн");

        enemyAI.SetAttackRange(true);

        yield return new WaitForSeconds(0.1f);

        enemyAI.SetAttackRange(false);
    }

    private void EnemyAttackMove() {
        enemyAI.GetForcedDirect(enemyAI.GetTargetPlayer());
        enemyAI.NavAI(enemyAI.GetTargetPlayer().transform.position);
    }
}
