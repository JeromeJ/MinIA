using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SampleAgentScript : MonoBehaviour
{
    #region Public Members

    public Transform m_target;

    #endregion

    #region Public void

    #endregion

    #region System

    void Awake ()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Update ()
    {
        StateMachine();
    }

    void FixedUpdate()
    {

        var nav = GetComponent<NavMeshAgent>();
        if (nav == null || nav.path == null)
            return;

        var line = this.GetComponent<LineRenderer>();
        if (line == null)
        {
            line = this.gameObject.AddComponent<LineRenderer>();
            line.material = new Material(Shader.Find("Sprites/Default")) { color = Color.yellow };
            line.SetWidth(0.5f, 0.5f);
            line.SetColors(Color.yellow, Color.yellow);
        }

        var path = nav.path;
        line.SetVertexCount(path.corners.Length);

        for (int i = 0; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }
    }


    #endregion

    #region Class Methods

    void StateMachine()
    {
        switch(m_state)
        {
            case e_States.UNAWARE:
                RaycastHit hit;

                if (Physics.Raycast(transform.position, (m_target.position - transform.position), out hit))
                {
                    if (hit.transform.tag == "Player")
                    {
                        if (hit.distance <= 5f)
                        {
                            m_state = e_States.ENGAGE;
                        }
                        else if (hit.distance <= 10f)
                        {
                            m_state = e_States.INVESTIGATE;
                        }
                    }
                    else if((m_target.position - transform.position).magnitude < 5f)
                    {
                        m_state = e_States.INVESTIGATE;
                    }
                }

                break;
            case e_States.ENGAGE:
                Physics.Raycast(transform.position, (m_target.position - transform.position), out hit);
                Debug.DrawRay(transform.position, (m_target.position - transform.position) * hit.distance, Color.red);

                m_agent.SetDestination(m_target.position);

                break;
            case e_States.INVESTIGATE:
                // Lacks tweakability, makes the zombie rotate on his y axis when jumping etc
                // transform.LookAt(m_target.transform);

                Ray ray = new Ray(transform.position, (m_target.position - transform.position));

                // Link between both
                Debug.DrawRay(transform.position, (m_target.position - transform.position), Color.yellow);

                // Debug.DrawRay(m_target.position, new Vector3(2,2,2), Color.black);
                // Debug.Log(Vector3.ProjectOnPlane(m_target.position, zombiePlane.normal));
                // Debug.DrawRay(m_target.position, Vector3.ProjectOnPlane(m_target.position, zombiePlane.normal), Color.green);

                // Will look in the player direction (LOS or not)
                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 targetPoint = ray.GetPoint(hit.distance);

                    // Normalize so the zombie never look up or down - Ideally, they'd be both at 0 but this is in case they aren't
                    targetPoint.y = transform.position.y;

                    Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

                    // Instant rotation
                    // transform.rotation = targetRotation;

                    // 1 for slow rotation, 3 for faster
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);

                    // Direct LOS
                    if (hit.distance <= 5f && hit.transform.tag == "Player")
                    {
                        m_state = e_States.ENGAGE;
                    }
                    else if (hit.distance > 10f)
                    {
                        m_state = e_States.UNAWARE;
                    }
                }

                break;
        }
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    protected NavMeshAgent m_agent;

    [SerializeField]
    protected enum e_States
    {
        INVALID = -1,

        UNAWARE = 1,
        INVESTIGATE = 2,
        ENGAGE = 4,
        DEAD = 8,
    }

    protected e_States m_state = e_States.UNAWARE;

    #endregion
}
