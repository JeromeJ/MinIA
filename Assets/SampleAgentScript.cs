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
        m_agent.SetDestination(m_target.position);
    }

    #endregion

    #region Tools Debug and Utility

    #endregion

    #region Private and Protected Members

    private NavMeshAgent m_agent;

    #endregion
}
