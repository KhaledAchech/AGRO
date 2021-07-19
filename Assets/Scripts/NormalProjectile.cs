using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalProjectile : MonoBehaviour
{

    public GameObject collisionExplosion;
    public float speed = 100f;
    public float damage = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            explode();
        }
    }



    public void explode()
    {
        if (collisionExplosion != null)
        {
            GameObject explosion = (GameObject)Instantiate(
                collisionExplosion, transform.position, transform.rotation);
            PlayerAttributs playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributs>();
            //Debug.Log("am here");
            playerHealth.DeductHealth(damage);
            Destroy(gameObject);
            Destroy(explosion, 1f);
        }
    }
}
