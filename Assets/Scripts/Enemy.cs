using UnityEngine;

public class Enemy : MonoBehaviour
{
public GameObject turret, Explosion;

private AudioSource source;
    private void Awake()
    {
        turret.SetActive(true);
        Explosion.SetActive(false);

        source = GetComponent<AudioSource>();

        this.enabled = false;

    }

   
    public void KillEnemy(Vector3 ExplosionPosition)
    {
        turret.SetActive(false);
        Explosion.SetActive(true);

        source.Play();
    }
}
