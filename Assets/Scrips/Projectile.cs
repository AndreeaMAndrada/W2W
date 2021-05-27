using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;
    public int damage;//it is in the projectile part

    // Start is called before the first frame update
    private void Start()
    {

        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    private void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);// the original position, where is going, what the distance is and what to hit with
        if (hitInfo.collider != null) //if it hids a colider 
        {
            if (hitInfo.collider.CompareTag("Enemy")) //if it hits the enemy colider
            {
                Debug.Log("ENEMY MUST DIE!");//how to write in the logs
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);//the hitinfo when it colides gets the components from the enemy class from the function take damage
            }
            DestroyProjectile();//destroy the projectile function
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);//puts the speen on the projectile

    }
    void DestroyProjectile()
    {
        destroyEffect = Instantiate(destroyEffect, transform.position, Quaternion.identity);//the effect is made out of the effect, position and identity
        Destroy(destroyEffect, 0.5f);//is destroyed after 0,5f
        Destroy(gameObject);

    }

}
