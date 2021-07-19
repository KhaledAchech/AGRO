using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public GameObject Barrel, Explosion, source;

    //public AudioSource source;

    [SerializeField]
    private float range;

    private bool isexploded = false;

    private void Awake()
    {
        Barrel.SetActive(true);
        Explosion.SetActive(false);
        source.SetActive(false);

    }

    public void Explode()
    {
        source.SetActive(true);
        source.GetComponent<AudioSource>().Play();
        Barrel.SetActive(false);
        Explosion.SetActive(true);


        Collider[] objects = Physics.OverlapSphere(transform.position, range);

        foreach (Collider obj in objects)
        {
            float dist = Vector3.Distance(transform.position, obj.transform.position);
            if (dist <= range)
            {
                if (obj.GetComponent<Enemy>() != null)
                {
                    obj.GetComponent<Enemy>().KillEnemy(transform.position);

                }
                if (obj.GetComponent<ExplosiveBarrel>() != null)
                {
                    obj.GetComponent<ExplosiveBarrel>().Explode();

                }
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
    
    void Update()
    {

        if (isexploded)
        {
            Debug.Log("here---------------------");
            //source.Play();
            isexploded = false;
        }

    }
    */
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
