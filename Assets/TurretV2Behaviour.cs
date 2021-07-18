using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretV2Behaviour : MonoBehaviour
{

    Transform target;

    //the base of the turrets that will be rotating following the player movement
    public GameObject mybase;
    //the laser beam spawners points
    public List<GameObject> projectileSpawns;
    //the laser beam launchers / guns
    public GameObject laserLaunchers;
    //speed needed for following the target
    public float speed = 3.0f;
    // Distance the turret can aim and fire from
    public float firingRange;
    // Used to start and stop the turret firing
    bool canFire = false;

    //the laser we re going to shoot
    public GameObject projectile;

    //to add a force effect
    public float launchVelocity = 700f;

    //Opening/closing animation
    private Animation anim;

    //SFX
    private AudioSource OpenDoor, CloseDoor;

    public AudioSource[] sounds;


    // Start is called before the first frame update
    void Start()
    {
        // Set the firing range distance
        this.GetComponent<SphereCollider>().radius = firingRange;

        anim = gameObject.GetComponent<Animation>();

        sounds = GetComponents<AudioSource>();
        OpenDoor = sounds[0];
        CloseDoor = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
        AimAndFire();
    }

    void OnDrawGizmosSelected()
    {
        // Draw a red sphere at the transform's position to show the firing range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, firingRange);
    }
    // Detect a Player, aim and fire
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = other.transform;
            canFire = true;
            anim["Turret_v1_activation"].speed = 0.8f;
            OpenDoor.Play();
            anim.Play("Turret_v1_activation");
        }

    }
    // Stop firing
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canFire = false;
            CloseDoor.Play();
            anim.Play("Turret_v1_deactivation");
        }
    }
    void AimAndFire()
    {
        if (canFire)
        {
            // aim at player
            //Vector3 mybaseTargetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            Vector3 laserLaunchersTargetPostition = new Vector3(target.position.x, target.position.y, target.position.z);

            var rotation = Quaternion.LookRotation(new Vector3(target.position.x, this.transform.position.y, target.position.z) - mybase.transform.position);
            mybase.transform.rotation = Quaternion.Slerp(mybase.transform.rotation, rotation, Time.deltaTime * speed);

            //mybase.transform.LookAt(mybaseTargetPostition);
            laserLaunchers.transform.LookAt(laserLaunchersTargetPostition);
            for (int i = 0; i < projectileSpawns.Count; i++)
            {
                GameObject laserShot = Instantiate(projectile, projectileSpawns[i].transform.position,
                                                    projectileSpawns[i].transform.rotation);
            }

            /*laserShot.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                (0, launchVelocity, 0));*/
        }
    }
}
