using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0.01f;
    public Vector3 spawnPoint;

    public Transform booster;
    

    Rigidbody rb;

    public Gun gun;



    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3();
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        //transform.position += moveDirection * speed * Time.deltaTime;
        rb.velocity = moveDirection * speed;

        float distance = Vector3.Distance(transform.position, booster.position);
        if (distance <= 1)
        {
            speed += 0.3f;
            
            gun.StartShooting(2);
            
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.name.Contains("Enemy") || collision.gameObject.name.Contains("Bullet"))
        {
            Die();
            
        }
        
        
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
