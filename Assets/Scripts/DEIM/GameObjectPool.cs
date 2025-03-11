using System;
using UnityEngine;
using System.Collections.Generic;

public class GameObjectPool : MonoBehaviour
{
    public GameObject objectToPool;
    [Tooltip("Initial pool size")]
    public uint poolSize;
    [Tooltip("If true, size increments")]
    public bool shouldExpand = false;

    private List<GameObject> _pool;

    void Start()
    {
        _pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            AddGameObjectToPool();
        }
    }

    public GameObject GimmeInactiveGameObject()
    {
        foreach (GameObject obj in _pool)
        {
            if (!obj.activeSelf)
            {
                return obj;
            }
        }

        if (shouldExpand)
        {
            return AddGameObjectToPool();
        }

        return null;
    }

    GameObject AddGameObjectToPool()
    {
        GameObject clone = Instantiate(objectToPool);
        clone.SetActive(false);
        _pool.Add(clone);

        return clone;
    }
}