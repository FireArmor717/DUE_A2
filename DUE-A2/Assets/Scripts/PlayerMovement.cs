using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // �ƶ��ٶ�
    private Vector3 moveDirection = Vector3.zero; // �ƶ�����

    void Update()
    {
        // �ý�ɫ�����ƶ�
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // �ý�ɫ�����ƶ����򣨷�ֹ��������ת����
        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }
    }

    // ��ס��ťʱ���趨�ƶ�����
    public void MoveUp() => moveDirection = Vector3.forward;
    public void MoveDown() => moveDirection = Vector3.back;
    public void MoveLeft() => moveDirection = Vector3.left;
    public void MoveRight() => moveDirection = Vector3.right;

    // �ɿ���ťʱ��ֹͣ�ƶ�
    public void StopMoving() => moveDirection = Vector3.zero;
}