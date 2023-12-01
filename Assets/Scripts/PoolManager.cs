using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public GameObject fireballPrefab;
    private List<GameObject> fireballPool;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializePool(); 
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void InitializePool()
    {
        fireballPool = new List<GameObject>();

        for (int i = 0; i < 10; i++) 
        {
            GameObject obj = Instantiate(fireballPrefab);
            obj.SetActive(false);
            fireballPool.Add(obj);
        }
    }

    public GameObject GetFireball()
    {
        foreach (var fireball in fireballPool)
        {
            if (!fireball.activeInHierarchy)
            {
                fireball.SetActive(true);
                return fireball;
            }
        }

        GameObject newObj = Instantiate(fireballPrefab);
        newObj.SetActive(true);
        fireballPool.Add(newObj);
        return newObj;
    }

    public void ReturnToPool(GameObject fireball)
    {
        fireball.SetActive(false);
    }

    void Deactivate()
    {
        if (PoolManager.Instance != null)
    {
        PoolManager.Instance.ReturnToPool(gameObject);
    }
    else
    {
        Debug.LogError("PoolManager.Instance is null.");
    }
        
        Debug.Log("PoolManager Instance: " + PoolManager.Instance);
        PoolManager.Instance.ReturnToPool(gameObject);
    }

}
