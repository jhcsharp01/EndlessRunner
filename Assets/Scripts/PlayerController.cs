using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller; //컴포넌트

    private Vector3 moveVector;                                 // 방향 벡터
    private float vertical_velocity = 0.0f;                     // 점프를 위한 수직 속도
    private float gravity = 12.0f;                              // 중력 값


    [SerializeField] private bool isDead = false; //일반적으론 살아있는 상태
    [SerializeField] private float speed = 5.0f;                // 플레이어의 이동 속도
    [SerializeField] private float jump = 3.0f;                 // 플레이어의 점프 수치
    public void SetSpeed(float level)
    {
        speed += level;
        Debug.Log("현재 스피드 : " + speed);
    }

    public float GetSpeed() => speed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //카메라 컨트롤러를 이용해 플레이어 움직임 전에 카메라 연출을 진행해보려 합니다.
        if(Time.timeSinceLevelLoad < CameraController.camara_animate_duration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;
        }

        //죽은 상태일 경우 Update 작업 x
        if (isDead)
            return;


        moveVector = Vector3.zero; //방향 벡터 값 리셋
        //땅에 닿아있을 경우 velocity 고정
        if(controller.isGrounded)
        {
            //Debug.Log("컨트롤러가 땅에 닿았습니다.");
            vertical_velocity = -0.5f;

            //점프 기능 추가
            if(Input.GetKeyDown(KeyCode.X))
            {
                vertical_velocity = jump;
            }
        }
        else
        {
            //아닐 경우 중력치만큼 떨어지도록
            vertical_velocity -= gravity * Time.deltaTime;
        }
        //1. 좌우 이동
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //2. 점프 관련
        moveVector.y = vertical_velocity;
        //3. 앞으로 이동
        moveVector.z = speed;
        //설정한 방향대로 이동 진행 
        controller.Move(moveVector * Time.deltaTime);
    }

   

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "Obstacle")
        {
            OnDeath();
            //충돌하면 바로 죽는 이벤트로 진행 
        }
    }

    private void OnDeath()
    {
        isDead = true;
    }
}
