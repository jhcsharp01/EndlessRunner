using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller; //������Ʈ
    public ScoreManager scoreManager; //���ھ� �Ŵ���
    Animator animator;

    private Vector3 moveVector;                                 // ���� ����
    private float vertical_velocity = 0.0f;                     // ������ ���� ���� �ӵ�
    private float gravity = 12.0f;                              // �߷� ��


    [SerializeField] private bool isDead = false; //�Ϲ������� ����ִ� ����
    [SerializeField] private float speed = 5.0f;                // �÷��̾��� �̵� �ӵ�
    [SerializeField] private float jump = 3.0f;                 // �÷��̾��� ���� ��ġ
    public void SetSpeed(float level)
    {
        speed += level;
        Debug.Log("���� ���ǵ� : " + speed);
    }

    public float GetSpeed() => speed;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //ī�޶� ��Ʈ�ѷ��� �̿��� �÷��̾� ������ ���� ī�޶� ������ �����غ��� �մϴ�.
        if(Time.timeSinceLevelLoad < CameraController.camara_animate_duration)
        {
            //controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        //���� ������ ��� Update �۾� x
        if (isDead)
            return;

        animator.SetBool("isRun", true);

        moveVector = Vector3.zero; //���� ���� �� ����
        //���� ������� ��� velocity ����
        if(controller.isGrounded)
        {
            //Debug.Log("��Ʈ�ѷ��� ���� ��ҽ��ϴ�.");
            vertical_velocity = -0.5f;
            
            //���� ��� �߰�
            if (Input.GetKeyDown(KeyCode.X))
            {
                vertical_velocity = jump;
                animator.SetBool("isJump",true);
            }
            else
            {
                animator.SetBool("isJump", false);
            }

            if(Input.GetKeyDown(KeyCode.Z))
            {
                animator.SetBool("isSlide", true);
            }
            else if(Input.GetKeyUp(KeyCode.Z))
            {
                animator.SetBool("isSlide", false);
            }
        }
        else
        {
            //�ƴ� ��� �߷�ġ��ŭ ����������
            vertical_velocity -= gravity * Time.deltaTime;
        }
        //1. �¿� �̵�
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //2. ���� ����
        moveVector.y = vertical_velocity;
        //3. ������ �̵�
        moveVector.z = speed;
        //������ ������ �̵� ���� 
        controller.Move(moveVector * Time.deltaTime);
        
    }

   

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            OnDeath();
            scoreManager.OnDead();
            //�浹�ϸ� �ٷ� �״� �̺�Ʈ�� ���� 
        }
    }

    private void OnDeath()
    {
        isDead = true;
    }
}
