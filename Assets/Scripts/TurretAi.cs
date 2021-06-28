using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAi : MonoBehaviour
{
    public enum AIStates{NEAREST, FURTHEST};

    public AIStates aiState = AIStates.NEAREST;

    TrackingSystem m_tracker;
    ShootingSystem m_shooter;
    RangeChecker m_range;
    // Start is called before the first frame update
    void Start()
    {
        m_tracker = GetComponent<TrackingSystem>();
        m_shooter = GetComponent<ShootingSystem>();
        m_range   = GetComponent<RangeChecker>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!m_tracker || !m_shooter || !m_range)
        {
            return;
        }

        switch(aiState)
        {
            case AIStates.NEAREST: 
                targetNearest();
                break;
            case AIStates.FURTHEST: 
                targetFurthest();
                break;
        }
            
    }

    void targetNearest()
    {
        List<GameObject> validTargets = m_range.GetValidTargets();

        GameObject curTarget = null;
        float closestDist = 0.0f;

        for (int i = 0; i < validTargets.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, validTargets[i].transform.position);

            if (!curTarget || dist < closestDist)
            {
                curTarget = validTargets[i];
                closestDist = dist;
            }
        }
        m_tracker.SetTarget(curTarget);
        m_shooter.SetTarget(curTarget);
        
    }

    void targetFurthest()
    {
        List<GameObject> validTargets = m_range.GetValidTargets();

        GameObject curTarget = null;
        float furthestDist = 0.0f;

        for (int i = 0; i < validTargets.Count; i++)
        {
            float dist = Vector3.Distance(transform.position, validTargets[i].transform.position);

            if (!curTarget || dist > furthestDist)
            {
                curTarget = validTargets[i];
                furthestDist = dist;
            }
        }
        m_tracker.SetTarget(curTarget);
        m_shooter.SetTarget(curTarget);
        
    }
}
