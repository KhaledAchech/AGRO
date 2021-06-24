using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingSystem : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject mybase;
    public GameObject mytarget = null;
    Vector3 m_lastKnownPosition = Vector3.zero;
    Quaternion m_lookAtRotation;

    // Update is called once per frame
    void Update()
    {
        if (mytarget)
        {
            if (m_lastKnownPosition != mytarget.transform.position)
            {
                m_lastKnownPosition = mytarget.transform.position;
                m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position); 
            }

            if (mybase.transform.rotation != m_lookAtRotation)
            {
                Quaternion tiltAroundYandZ = Quaternion.Euler(0, m_lookAtRotation.y, m_lookAtRotation.z);
                mybase.transform.rotation = Quaternion.RotateTowards(mybase.transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
            }
        }
        
        
    }

    bool SetTarget(GameObject target)
    {
        if (target)
        {
            return false;
        }

        mytarget = target;

        return true;
    }
}
