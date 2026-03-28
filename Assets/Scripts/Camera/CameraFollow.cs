//스크립트 작성자: 이준호
//카메라가 타겟을 따라가는 스크립트.
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public static CameraFollow Instance;
    public Transform target;

    [SerializeField] private float smoothTime = 0.15f;

    [SerializeField] private bool XMaxEnabled = false;
    [SerializeField] private float XMaxValue = 0;
    [SerializeField] private bool XMinEnabled = false; 
    [SerializeField] private float XMinValue = 0;
    
    [SerializeField] private bool YMaxEnabled = false;
    [SerializeField] private float YMaxValue = 0;
    [SerializeField] private bool YMinEnabled = false;
    [SerializeField] private float YMinValue = 0;
    
    private Vector3 velocity = Vector3.zero;

#if UNITY_EDITOR
    [ContextMenu("Auto Assign")]
    private void AutoAssign() {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
#endif

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);

    }

    private void FixedUpdate() {
        Vector3 targetPos = target.position;

        if (YMinEnabled && YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, YMaxValue);
        else if (YMinEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, YMinValue, target.position.y);
        else if (YMaxEnabled)
            targetPos.y = Mathf.Clamp(target.position.y, target.position.y, YMaxValue);
        if (XMinEnabled && XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, XMaxValue);
        else if (XMinEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, XMinValue, target.position.x);
        else if (XMaxEnabled)
            targetPos.x = Mathf.Clamp(target.position.x, target.position.x, XMaxValue);

        targetPos.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}