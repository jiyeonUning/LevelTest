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
    [SerializeField] Transform muzzlePoint; // �Ѿ��� ������ ��ġ


    private void Update()
    {
        // ====================================================================================================
        //                                            ����Ű �̵� ����

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir == Vector3.zero) return;

        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime, Space.World);

        Quaternion lookRot = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, rate * Time.deltaTime);

        // ====================================================================================================
        //                                      �����̽��ٸ� ���� �Ѿ� �߻�

        if (Input.GetKeyDown(KeyCode.Space))
        {
            curBulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
        }
    }
}
