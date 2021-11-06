using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwerveMovement : MonoBehaviour
{
    private SwerveInput swerveInput;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerve = 1f;
    private CharacterController m_char;
    public bool swipeUp;
    private Animator m_Animator;
    public float JumpPower = 7f;
    public bool InJump;
    private float y;
    private Vector3 originalPos;

    private void Awake()
    {
        swerveInput = GetComponent<SwerveInput>();
        m_char = GetComponent<CharacterController>();
        m_Animator = GetComponent<Animator>();
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    //Swerve Values
    private void Update()
    {
        //Running/jump/swerve movement values
        swipeUp = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow);
        float swerveAmount = swerveSpeed * Time.deltaTime * swerveInput.MoveFactorX;
        swerveAmount = Mathf.Clamp(value: swerveAmount, min: -maxSwerve, maxSwerve);
        Vector3 moveVector = new Vector3(swerveAmount, y*Time.deltaTime, z: 1.75f*Time.deltaTime);
        m_char.Move(moveVector);
        Jump();
    }
    public void Jump()
    {
        //Jump if char on ground
        if (m_char.isGrounded)
        {
            if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("Landing"))
            {
                m_Animator.Play("Landing");
                InJump = false;
            }
            if (swipeUp)
            {
                y = JumpPower;
                m_Animator.CrossFadeInFixedTime("Jump", 0.1f);
                InJump = true;
            }
        }
        else
        {
            y -= JumpPower * 2 * Time.deltaTime;
            if (m_char.velocity.y < -0.1f)
                m_Animator.Play("Falling");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Reset position to starting zone after colliding with obstacles
        if (other.gameObject.tag.Equals("Obstacles"))
        {
            m_char.enabled = false;
            m_char.transform.position = originalPos;
            m_char.enabled = true;
        }
    }
}