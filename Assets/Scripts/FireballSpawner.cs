using UnityEngine;
public class FireballSpawner : MonoBehaviour
{
    public Vector3 spawnOffset = new Vector3(0, 0, 1); 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            GameObject fireball = PoolManager.Instance.GetFireball();
            if (fireball != null)
            {
                fireball.transform.position = transform.position + transform.TransformDirection(spawnOffset);
                fireball.transform.rotation = transform.rotation;
            }
        }
    }
}
