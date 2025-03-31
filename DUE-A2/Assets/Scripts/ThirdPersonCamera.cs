using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // 角色
    public Vector3 offset = new Vector3(0, 3, -5); // 相机偏移量
    public float smoothSpeed = 5f; // 平滑移动速度
    public float rotationSpeed = 100f; // 旋转速度

    private float currentX = 0f;
    private float currentY = 10f; // 初始角度

    void LateUpdate()
    {
        if (target == null) return;

        // 旋转控制（鼠标右键控制）
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY, 5f, 60f); // 限制上下角度
        }

        // 计算新位置
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // 看向玩家
        transform.LookAt(target);
    }
}