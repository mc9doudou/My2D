using UnityEngine;
using UnityEngine.InputSystem;
namespace My2D
{
    public class PlayerController : MonoBehaviour
    {
        #region
        //강체
        private Rigidbody2D rb2D;
        
        //걷는 속도
        [SerializeField] private float walkSpeed = 4f;

        //이동
        //이동 입력값
        private Vector2 inputMove;
        #endregion
        private void Awake()
        {
            rb2D = this.GetComponent<Rigidbody2D>();
        }
        #region Unity Event Method
        private void FixedUpdate()
        {
            //인풋값에 따라 좌우 이동
            rb2D.linearVelocity = new Vector2(inputMove.x * walkSpeed, rb2D.linearVelocity.y);
            /*//키 입력값에 따른 카메라 이동
            Vector3 dir = new Vector3(inputMove.x, 0, inputMove.y);
            transform.Translate(dir * Time.deltaTime * walkSpeed, Space.World);*/
        }
        #endregion

        #region Custom Method
        public void OnMove(InputAction.CallbackContext context)
        {
            inputMove = context.ReadValue<Vector2>();
        }
        /*public void OnMove(InputValue value)
        {
            inputMove = value.Get<Vector2>();
        }*/
        #endregion
    }
}