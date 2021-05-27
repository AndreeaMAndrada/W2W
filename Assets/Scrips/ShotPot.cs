using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPot : MonoBehaviour

{
    public float offset;
    public GameObject projectile;
    public Transform shotPoint;
    private float timeBtwShots;//time between shots 
    public float startTimeBtwShots;//0.25
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;//how to make the bomb follow the mouse
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//the equation to make the rotation z
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);//offset is -90, equation
        if(timeBtwShots <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))//left click
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);//projectile input from assets, shotpoint is where the projectile should shot out from
                timeBtwShots = startTimeBtwShots;
            }

        }
        else
        {
            timeBtwShots -= Time.deltaTime;//setting time to decrease 
        }
    }
}
