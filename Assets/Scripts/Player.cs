using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // [SerializeField]: unity에서 설정 가능하도록 함
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Transform shootTransform;
    [SerializeField] private float ShootInterval = 0.05f;
    private float lastShotTime = 0f;

    // 본 게임은 상하 움직임을 구현할 필요는 없음
    void Update()
    {
        // Case 1(키보드)
        // // 좌우, 상하 방향키 입력을 받아서
        // float horizontalInput = Input.GetAxisRaw("Horizontal");
        // float verticalInput = Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, verticalInput, 0);
        // // Player의 위치를 입력받은 만큼 변경한다.
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Case 2(마우스)
        // 1080x1920 크기의 마우스 좌표를 Transform의 포지션 좌표로 변경
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 마우스의 x 좌표의 최대 최소 설정
        float toX = Mathf.Clamp(mousePos.x, -2.4f, 2.4f);
        // Player의 위치를 입력받은 만큼 변경한다.
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();
    }

    void Shoot()
    {
        // 게임 시작으로부터 지난 시간 - 마지막으로 쏜 시간 > 쏘는 시간 간격
        if (Time.time - lastShotTime > ShootInterval)
        {
            // Weapon 오브젝트(미사일)의 위치를 회전 없이 위쪽으로 나아간다.
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            // 마지막으로 쏜 시간 업데이트
            lastShotTime = Time.time;
        }
    }
}
