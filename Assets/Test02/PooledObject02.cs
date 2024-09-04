using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PooledObject02 : MonoBehaviour
{
    private ObjectPool02 pool;
    public ObjectPool02 Pool
    { get { return pool; } set { pool = value; } }

    public void ReturnPool()
    {
        if (pool != null) { pool.ReturnPool(this); }
        else { Destroy(gameObject); }
    }
}
