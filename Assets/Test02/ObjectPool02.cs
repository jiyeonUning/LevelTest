using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool02 : MonoBehaviour
{
    [SerializeField] PooledObject02 prefab;
    [SerializeField] bool createOnEmpty = true;
    [SerializeField] int size;
    [SerializeField] int capacity;

    // �Ѿ��� ���� �� ��ŭ �����Ͽ� �����صδ� �뵵�� Ǯ �迭�� ����
    private Stack<PooledObject02> pool;

    void Awake()
    {
        // �Ѿ��� ���� Ǯ�� ����
        pool = new Stack<PooledObject02>(capacity);

        // Ǯ�� �Ѿ��� �����ϴ� for��
        for (int i = 0; i < size; i++)
        {
            PooledObject02 instance = Instantiate(prefab);
            instance.gameObject.SetActive(false);
            instance.Pool = this;
            pool.Push(instance);
        }
    }

    // Ǯ�� ������ ���� �뿩�ϴ� �Լ�
    public PooledObject02 GetPool(Vector3 position, Quaternion rotation)
    {
        if (pool.Count > 0) // Ǯ�� ������ �Ѿ��� ���� 0�� ��,
        {
            PooledObject02 instance = pool.Pop();
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.gameObject.SetActive(true);
            return instance;
        }
        else if (createOnEmpty) // �Ѿ��� �뿩�ϰ� ���� ��,
        {
            PooledObject02 instance = Instantiate(prefab);
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.Pool = this;
            return instance;
        }
        else
        {
            return null;
        }
    }

    // �뿩�� ���� �ٽ� �ݳ��ϴ� �Լ�
    public void ReturnPool(PooledObject02 instance)
    {
        // �������� �Ѿ��� ���� �����Ϸ��� �Ѿ��� �� ���� ���� ��, ������ ���ߴ� if��
        if (pool.Count < capacity)
        {
            instance.gameObject.SetActive(false);
            pool.Push(instance);
        }
        else { Destroy(instance.gameObject); }
    }
}
