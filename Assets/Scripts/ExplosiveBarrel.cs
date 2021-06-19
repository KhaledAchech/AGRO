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

        Collider[] objects = Physics.OverlapSphere(transform.position, range);

        foreach (Collider obj in objects)
        {
            if (obj.GetComponent<Enemy>() != null)
            {
                Debug.Log("we have enemies !");
                obj.GetComponent<Enemy>().KillEnemy(transform.position);
            }
            if (obj.GetComponent<ExplosiveBarrel>() != null)
            {
                Debug.Log("we have Barrels !");
                obj.GetComponent<ExplosiveBarrel>().Explode();
            }
        }

        this.enabled = false;
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("i hit a barrel");
        if (other.tag == "Laser")
        {
            Debug.Log("am a laser");
            Explode();
        }
    }
    */
    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Explode();
        }
        */
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
