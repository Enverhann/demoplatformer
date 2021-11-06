using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentRestart2 : MonoBehaviour
{
    private CharacterController m_char;
    Vector3 originalPos;
    //Opponent restart at specific position
    void Start()
    {
        m_char = GetComponent<CharacterController>();
        originalPos = new Vector3(2.146f, 0.1323465f, 0);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Obstacles"))
        {
            m_char.enabled = false;
            m_char.transform.position = originalPos;
            m_char.enabled = true;
        }
    }
}
