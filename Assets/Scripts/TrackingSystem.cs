using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject mybase = null;
    public GameObject m_target = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;

    // Update is called once per frame
    void Update()
    {
        if (m_lastKnownPosition != m_target.transform.position)
        {
            m_lastKnownPosition = m_target.transform.position;
            m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position); 
        }

        if (mybase.transform.rotation != m_lookAtRotation)
        {
             Quaternion tiltAroundYandZ = Quaternion.Euler(0, m_lookAtRotation.y, m_lookAtRotation.z);
            mybase.transform.rotation = Quaternion.RotateTowards(mybase.transform.rotation, tiltAroundYandZ, speed * Time.deltaTime);
        }
        
    }

    bool SetTarget(GameObject target)
    {
        if (target)
        {
            return false;
        }

        m_target = target;

        return true;
    }
}
