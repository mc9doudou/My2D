using UnityEngine;
namespace My2D
{
    public class PlayerController : MonoBehaviour
    {
        //��ü
        private Rigidbody2D rb2D;
        
        //�ȴ� �ӵ�
        [SerializeField] private float walkSpeed = 4f;

        //�̵�
        //�̵� �Է°�
        private Vector2 inputMove;

    }
}