using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // 移动速度
    private Vector3 moveDirection = Vector3.zero; // 移动方向

    void Update()
    {
        // 让角色持续移动
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // 让角色朝向移动方向（防止零向量旋转错误）
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    // 按住按钮时，设定移动方向
    public void MoveUp() => moveDirection = Vector3.forward;
    public void MoveDown() => moveDirection = Vector3.back;
    public void MoveLeft() => moveDirection = Vector3.left;
    public void MoveRight() => moveDirection = Vector3.right;

    // 松开按钮时，停止移动
    public void StopMoving() => moveDirection = Vector3.zero;
}