using UnityEngine;
namespace My2D
{
    public class PlayerController : MonoBehaviour
    {
        //강체
        private Rigidbody2D rb2D;
        
        //걷는 속도
        [SerializeField] private float walkSpeed = 4f;

        //이동
        //이동 입력값
        private Vector2 inputMove;

    }
}