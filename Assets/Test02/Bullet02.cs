using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet02 : MonoBehaviour
{
    [SerializeField] PooledObject02 pooledObject;
    [SerializeField] float MoveSpeed;
    [SerializeField] float returnTime; // �Ѿ��� Ǯ�� �ݳ��ϴ� �� ���� �ɸ��� �ð�

    private float remainTime; // �Ѿ��� ������ �ð�

    void OnEnable()
    {
        remainTime = returnTime;
    }

    void Update()
    {
        // ������ �̵��� �� �ִ� ��� ����
        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.Self);

        // �����ð��� ������, �ٽ� Ǯ�� �ݳ����� �� �ִ� if���� �ۼ�
        remainTime -= Time.deltaTime;
        if (remainTime < 0) { pooledObject.ReturnPool(); }
    }
}
