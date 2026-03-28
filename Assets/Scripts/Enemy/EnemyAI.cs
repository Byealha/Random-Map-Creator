//스크립트 작성자: 이준호
//몬스터를 움직이게 하는 감독 스크립트.
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {
    private NavMeshAgent agent;
    private SpriteRenderer spriteRenderer;

    private EnemyIdle enemyIdle;
    private EnemyTrack enemyTrack;
    private EnemyAttack enemyAttack;

    [SerializeField] private GameObject targetPlayer;
    [SerializeField] private GameObject targetIdle;
    [SerializeField] private GameObject attackRange;
    [SerializeField] private float enemySpeed = 3f;
    [SerializeField] private float trackSpeed = 5f;
    [SerializeField] private float stopDistance = 1f;
    [SerializeField] private float attackCooldown = 1f;

    [SerializeField] private bool canTrackMove = true;

    [SerializeField] private bool canIdle = true;
    [SerializeField] private bool canTrack = true;
    [SerializeField] private bool canAttack = true;

    private float currentSpeed;

    private enum EnemyState {
        Idle, Track, Attack
    }

    private EnemyState enemyState;
    //====================[Set Functions]==========================//
    public void SetStateIdle() {
        enemyState = EnemyState.Idle;

        currentSpeed = enemySpeed;
        agent.speed = currentSpeed;
    }

    public void SetStateTrack() {
        enemyState = EnemyState.Track;

        currentSpeed = trackSpeed;
        agent.speed = currentSpeed;
    }

    public void SetStateAttack() {
        enemyState = EnemyState.Attack;

        currentSpeed = trackSpeed;
        agent.speed = currentSpeed;
    }

    public void SetCanTrackMove(bool value) {
        canTrackMove = value;
    }

    public void SetAttackRange(bool value) {
        attackRange.SetActive(value);
    }
    //====================[Get Functions]==========================//
    public GameObject GetTargetPlayer() => targetPlayer;
    public GameObject GetTargetIdle() => targetIdle;

    public float GetStopDistance() => stopDistance;
    public float GetCurrentSpeed() => currentSpeed;
    public float GetAttackCooldown() => attackCooldown;

    public bool GetCanTrackMove() => canTrackMove;

    public bool IsStateIdle() => enemyState == EnemyState.Idle;
    public bool IsStateTrack() => enemyState == EnemyState.Track;
    public bool IsStateAttack() => enemyState == EnemyState.Attack;

    public bool GetCanTrack() => canTrack;
    public bool GetCanAttack() => canAttack;
    //=============================================================//


    private void Awake() {
        enemyIdle = GetComponent<EnemyIdle>();
        enemyTrack = GetComponent<EnemyTrack>();
        enemyAttack = GetComponent<EnemyAttack>();

        agent = GetComponent<NavMeshAgent>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        currentSpeed = enemySpeed;

        enemyState = EnemyState.Idle;
        NavAI(transform.position);
    }

    private void Update() {
        if (enemyState == EnemyState.Idle && canIdle) {
            enemyIdle.IdleAI();
        }

        if (enemyState == EnemyState.Attack && canAttack) {
            Debug.Log("공격 루틴");
            enemyAttack.AttackAI();
        }
        else if (enemyState == EnemyState.Track && canTrack) {
            Debug.Log("추적 루틴");
            enemyTrack.TrackAI();
        }
    }

    public void NavAI(Vector3 vec) {
        if (agent == null || !agent.enabled)
            return;

        transform.rotation = Quaternion.Euler(Vector3.zero);

        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.speed = currentSpeed;
        agent.destination = vec;
    }

    public void GetForcedDirect(GameObject target) {
        float dir = target.transform.position.x - transform.position.x;

        if (target.transform.position == Vector3.zero)
            return;
        if (dir < 0)
            spriteRenderer.flipX = false;
        else
            spriteRenderer.flipX = true;
    }

    public float GetPlayerDistance() {
        return Vector3.Distance(targetPlayer.transform.position, transform.position);
    }
}
