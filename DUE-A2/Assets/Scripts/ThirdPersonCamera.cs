using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // ��ɫ
    public Vector3 offset = new Vector3(0, 3, -5); // ���ƫ����
    public float smoothSpeed = 5f; // ƽ���ƶ��ٶ�
    public float rotationSpeed = 100f; // ��ת�ٶ�

    private float currentX = 0f;
    private float currentY = 10f; // ��ʼ�Ƕ�

    void LateUpdate()
    {
        if (target == null) return;

        // ��ת���ƣ�����Ҽ����ƣ�
        if (Input.GetMouseButton(1))
        {
            currentX += Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            currentY -= Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            currentY = Mathf.Clamp(currentY, 5f, 60f); // �������½Ƕ�
        }

        // ������λ��
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        Vector3 desiredPosition = target.position + rotation * offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // �������
        transform.LookAt(target);
    }
}