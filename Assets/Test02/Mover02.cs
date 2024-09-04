using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Mover02 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rate;
    [SerializeField] float rotateSpeed;

    private ObjectPool02 curBulletPool;
    [SerializeField] Transform muzzlePoint; // 총알을 생성할 위치


    private void Update()
    {
        // ====================================================================================================
        //                                            방향키 이동 구현

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir == Vector3.zero) return;

        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);

        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rate * Time.deltaTime);

        // ====================================================================================================
        //                                      스페이스바를 통한 총알 발사

        if (Input.GetKeyDown(KeyCode.Space))
        {
            curBulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        }
    }
}
