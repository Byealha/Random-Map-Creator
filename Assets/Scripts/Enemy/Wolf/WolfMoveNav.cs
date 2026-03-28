using System;
using UnityEngine;
using UnityEngine.AI;

public class WolfMoveNav : MonoBehaviour {
    private Transform target;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float moveSpeed = 2.5f;
    [SerializeField] private float stopDistance = 1.5f;
    [SerializeField] private float hysteresis = 0.3f;
    [SerializeField] private float repathInterval = 0.15f;

    private NavMeshAgent agent;
    private bool chaseEnabled;
    private float repathTimer;

    public event Action moveNavFinish;

    private void Awake() {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.autoBraking = false;
        agent.acceleration = 99f;
        agent.speed = moveSpeed;
        agent.stoppingDistance = stopDistance;
        agent.isStopped = true;
        agent.ResetPath();
    }

    private void Start() {
        CacheTargetIfNeeded();
    }

    public void StartChase() {
        chaseEnabled = true;
        CacheTargetIfNeeded();
    }

    public void StopChase() {
        chaseEnabled = false;
        agent.isStopped = true;
        moveNavFinish?.Invoke();
        agent.ResetPath();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            StartChase();
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            StopChase();
        }

        if (!chaseEnabled) return;  

        if (target == null) {
            CacheTargetIfNeeded();
            if (target == null) return;
        }

        float dist = Vector2.Distance(transform.position, target.position);

        bool shouldStop = dist <= stopDistance;
        bool shouldMove = dist >= (stopDistance + hysteresis);

        if (shouldStop) {
            if (!agent.isStopped) {
                agent.isStopped = true;
                agent.ResetPath();
                StopChase();
            }
            return;
        }

        if (!shouldMove) {
            if (agent.isStopped) return;
        }

        agent.isStopped = false;

        repathTimer -= Time.deltaTime;
        if (repathTimer <= 0f) {
            repathTimer = repathInterval;
            agent.stoppingDistance = stopDistance;
            agent.SetDestination(target.position);
        }
    }

    private void CacheTargetIfNeeded() {
        if (target != null) return;

        var go = GameObject.FindGameObjectWithTag(playerTag);
        if (go != null) target = go.transform;
    }

}
