using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    private Vector3 startPosition; // 记录初始位置
    private Quaternion startRotation; // 记录初始旋转

    void Start()
    {
        startPosition = transform.position;  // 存储玩家初始位置
        startRotation = transform.rotation; // 存储玩家初始旋转角度
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // 按 R 键重置角色
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition; // 还原位置
        transform.rotation = startRotation; // 还原旋转角度
        GetComponent<Rigidbody>().velocity = Vector3.zero; // 清除速度，防止继续滑动
    }
}