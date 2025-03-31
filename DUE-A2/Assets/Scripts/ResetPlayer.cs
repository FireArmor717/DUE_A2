using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    private Vector3 startPosition; // ��¼��ʼλ��
    private Quaternion startRotation; // ��¼��ʼ��ת

    void Start()
    {
        startPosition = transform.position;  // �洢��ҳ�ʼλ��
        startRotation = transform.rotation; // �洢��ҳ�ʼ��ת�Ƕ�
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // �� R �����ý�ɫ
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition; // ��ԭλ��
        transform.rotation = startRotation; // ��ԭ��ת�Ƕ�
        GetComponent<Rigidbody>().velocity = Vector3.zero; // ����ٶȣ���ֹ��������
    }
}