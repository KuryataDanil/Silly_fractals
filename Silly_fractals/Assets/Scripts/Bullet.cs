using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime;

    void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
