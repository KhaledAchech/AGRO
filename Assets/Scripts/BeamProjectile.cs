using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamProjectile : BaseProjectile
{
    public float beamLength = 10.0f;
    GameObject m_launcher;
    Vector3 m_direction;
    bool m_fired;
    // Update is called once per frame
    void Update()
    {
        if (m_launcher)
        {
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, transform.position + (m_launcher.transform.forward * beamLength));
        }
    }

    public override void FireProjectile(GameObject launcher, GameObject target, int damage)
    {
        if (launcher)
        {
            m_launcher = launcher;
            transform.SetParent(m_launcher.transform);
        }
    }
}
