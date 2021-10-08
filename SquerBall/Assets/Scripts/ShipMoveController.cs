using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoveController : MonoBehaviour
{
    [SerializeField]private Transform m_target;
    [SerializeField] private float m_speed = 5;
    [SerializeField] private float m_attenuation = 0.5f;

    private Vector3 m_velocity;

    private void Update()
    {
        m_velocity += (m_target.position - transform.position) * m_speed;
        m_velocity *= m_attenuation;
        transform.position += m_velocity *= Time.deltaTime;
    }
}
