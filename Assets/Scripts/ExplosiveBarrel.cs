using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public GameObject Barrel, Explosion;

    private AudioSource source;

    [SerializeField]
    private float range;

    private void Awake()
    {
        Barrel.SetActive(true);
        Explosion.SetActive(false);

        source = GetComponent<AudioSource>();
    }

    public void Explode()
    {
        Barrel.SetActive(false);
        Explosion.SetActive(true);

        source.Play();

        Collider[] enemies = Physics.OverlapSphere(transform.position, range);

        foreach (Collider enemy in enemies)
        {
            if (enemy.GetComponent<Enemy>() != null)
            {
                Debug.Log("we have enemies !");
                enemy.GetComponent<Enemy>().KillEnemy(transform.position);
            }
        }

        this.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("i hit a barrel");
        if (other.tag == "Laser")
        {
            Debug.Log("am a laser");
            Explode();
        }
    }
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }*/
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
