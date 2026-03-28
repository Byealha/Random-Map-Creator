using System.Collections;
using UnityEngine;

public class EnemyIdle : MonoBehaviour {
    private EnemyAI enemyAI;

    private bool isIdleRoutine = false;

    private void Awake() {
        enemyAI = GetComponent<EnemyAI>();
    }

    public void IdleAI() {
        if (!enemyAI.IsStateIdle()) {
            return;
        }
        EnemyIdleMove();

        if (!isIdleRoutine) {
            StartCoroutine(Idle());
        }
    }

    private void EnemyIdleMove() {
        GameObject targetIdle = enemyAI.GetTargetIdle();

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetIdle.transform.position,
            enemyAI.GetCurrentSpeed() * Time.deltaTime);

        enemyAI.NavAI(transform.position);
    }

    private IEnumerator Idle() {
        isIdleRoutine = true;

        GameObject targetIdle = enemyAI.GetTargetIdle();
        if (targetIdle != null) {
            targetIdle.transform.position = IdlePosMove(1f);
        }
        yield return new WaitForSeconds(2f);

        // "방황 종료"
        if (targetIdle != null) {
            targetIdle.transform.localPosition = Vector3.zero; //추적을 그만두게 하기 위해 위치 초기화
        }

        yield return new WaitForSeconds(5f);

        // 여전히 Idle 상태라면 다음 루프를 다시 허용
        // Track으로 바뀌었다면 Idle 루프는 자동 종료되도록 함
        isIdleRoutine = false;
    }

    private Vector2 IdlePosMove(float rand) {
        float addX = Random.Range(-rand, rand);
        float addY = Random.Range(-rand, rand);

        GameObject targetIdle = enemyAI.GetTargetIdle();
        if (targetIdle == null)
            return Vector2.zero;

        //랜덤한 방향을 받아서 해당 좌표로 애를 움직이게 하기
        Vector2 idlePos = new Vector2(
            targetIdle.transform.position.x + addX,
            targetIdle.transform.position.y + addY
        );

        return idlePos;
    }
}