//스크립트 작성자: 이준호
//플레이어 이동 데모 스크립트.
using UnityEngine;

public class DemoPlayerMove : MonoBehaviour {
    private Rigidbody2D rigid;
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 moveVec;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");

        moveVec = moveVec.normalized;
    }

    private void FixedUpdate() {
        rigid.MovePosition(rigid.position + moveVec * moveSpeed * Time.fixedDeltaTime);
    }
}
