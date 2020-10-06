using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameController : MonoBehaviour
{
    public GameObject bullet;
    public Queue<GameObject> bullets;
    public int maxBullets;

    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Create list of bullet before game start
    private void _BuildBulletPool()
    {
        bullets = new Queue<GameObject>();
        for(int i = 0; i < maxBullets; ++i)
        {
            //create bullet
            GameObject tempBullet = Instantiate(bullet);
            tempBullet.SetActive(false);

            bullets.Enqueue(tempBullet);
        }
    }

    //Get bullet from pool
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = bullets.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;

        return newBullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);

        bullets.Enqueue(bullet);
    }
}
