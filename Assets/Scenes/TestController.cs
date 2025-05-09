using UnityEngine;

public class TestController : MonoBehaviour
{
    //���ǵ�
    [SerializeField] private float speed = 5.0f;
    //����
    Vector3 moveVector;

    //ĳ���� ��Ʈ�ѷ�
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed; //�¿�
        moveVector.z = Input.GetAxisRaw("Vertical") * speed;   //����
        controller.Move(moveVector * Time.deltaTime);
    }

    //�浹 ó���� ���� �̺�Ʈ
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
       if(hit.transform.tag == "Obstacle")
       {
            Debug.Log("��ֹ��̴�.");
       }

       if(hit.transform.tag == "Stair")
        {
            Debug.Log("����̴�.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Test")
        Debug.Log("Ʈ���� �߻�");
    }
}
