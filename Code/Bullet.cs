using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public static float speed = 60f;
    public int damage;
    public Rigidbody2D rb;
    public GameObject blulletDestroyPrefab;
    public Transform bullet;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
        FindObjectOfType<AudioManager>().Play("pyu1");
    }

    void OnTriggerEnter2D (Collider2D hitInfo)//blir kalt vis spillerens skud trefer noe
    {
        BulletEnemy bulletEnemy = hitInfo.GetComponent<BulletEnemy>();
        if (bulletEnemy != null) //vis skudet til spileren trefer skude til en fienden
        { 
            FindObjectOfType<AudioManager>().Play("Ping");
            
            Instantiate(blulletDestroyPrefab, bullet.position, bullet.rotation);
        }

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null) //vis skudet til spileren trefer en fiende
        {
            enemy.TakeDamage(damage); //kaler TakeDamage() i enemy scriptet for fienden som ble trufet
        }

        Player player = hitInfo.GetComponent<Player>();
        if(player == null) //vis skudet til spileren IKKE trefer spileren
        {
           Destroy(gameObject);
        }
        
    }

}
