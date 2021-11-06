using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentRestart : MonoBehaviour
{
    private CharacterController m_char;
    Vector3 originalPos;
    //Opponent restart at starting position
    void Start()
    {
        m_char = GetComponent<CharacterController>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
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
