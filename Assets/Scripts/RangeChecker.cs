using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    /***********************************************/
    /*  The reason am using a list of tags and     */
    /*  a list of targets is because am planning   */
    /*  on adding a helper minion ai to the player */
    /*  that is a valid target for the turrets     */
    /***********************************************/
    public List<string> tags;
    List<GameObject> m_targets = new List<GameObject>();

    [SerializeField]
    private float range;

    void Update() {
        OnSphereEnter();
    }
    /*
    void OnTriggerEnter(Collider other) 
    {
        bool invalid = true; 
        for (int i = 0; i < tags.Count; i++)
        {
            if (other.CompareTag(tags[i]))
            {
                invalid = false;
                break;
            }
        }

        if (invalid)
        {
            return;
        }

        m_targets.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other) 
    {
        for (int i = 0; i < m_targets.Count; i++)
        {
            if (other.gameObject == m_targets[i])
            {
                m_targets.Remove(other.gameObject);
                return;
            }
        }
    }
    */

    void OnSphereEnter()
    {
        Collider[] objects = Physics.OverlapSphere(transform.position, range);
        bool invalid = true; 
        foreach (Collider obj in objects)
         {
            float dist = Vector3.Distance(transform.position, obj.transform.position);
            if (tags.Contains(obj.tag))
            {
                if (dist <= range)
                {
                    invalid = false;
                    m_targets.Add(obj.gameObject);
                }
                else
                {
                    invalid = true;
                    m_targets.Remove(obj.gameObject);
                }
            }
         }
    }
    

    public List<GameObject> GetValidTargets()
    {
        return m_targets;
    }
    
    public bool InRange(GameObject go)
    {
        for (int i = 0; i < m_targets.Count ; i++)
        {
            if (go == m_targets[i])
            return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
