using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 10;
    public bool hasBounced = false;
    public Rigidbody2D rb;
    public GameObject EnemyBlulletDestroyPrefab;
    public Transform bullet;
    private SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        FindObjectOfType<AudioManager>().Play("pyu2");
    }

    void OnTriggerEnter2D (Collider2D hitInfo) // blir kalt vis fiendens skud trefer noe
    {

        Weapon weapon = hitInfo.GetComponent<Weapon>();
        if (weapon != null) //vis et skudet av fienden trefer sjhole til spileren og fliper retningen skude går i
        {
            FindObjectOfType<AudioManager>().Play("bubuouh");
            hasBounced = true;
            mySpriteRenderer.flipX = true;
            rb.velocity = transform.right * speed;
        }

        if(hasBounced == true) // vis et skudet av fienden har flipa og bytet retning
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>(); 
            if (enemy != null) // vis skude trefer en fiende
            {
                enemy.TakeDamage(damage); // kaler TakeDamage i enemy scripte   
                Destroy(gameObject);
            }

            BulletEnemy bulletEnemy = hitInfo.GetComponent<BulletEnemy>();
            if (bulletEnemy != null) // vis skude trefer en et skud
            {
                FindObjectOfType<AudioManager>().Play("Ping");
                Instantiate(EnemyBlulletDestroyPrefab, bullet.position, bullet.rotation);
                Destroy(gameObject);
            }
        }
        
        if(hasBounced == false) // vis et skudet av fienden har ikke byta retning
        {
            Player player = hitInfo.GetComponent<Player>();
            if (player != null) // vis skude trefer en et spilleren
            {
                player.TakeDamage(damage);
                Destroy(gameObject);
            }

            destroyBullet bulletDestroy = hitInfo.GetComponent<destroyBullet>();
            if (bulletDestroy != null) // vis skude trefer en et skude
            {
                bulletDestroy.BulletDestroy();
                Destroy(gameObject);
            }
        }
        
        Debug.Log(hitInfo.name);
    }

}
