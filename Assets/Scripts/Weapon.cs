using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10;

    void Start()
    {
        // 오브젝트의 메모리 save를 위해 1초 지나면 오브젝트 사라지게 함
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
    }
}
