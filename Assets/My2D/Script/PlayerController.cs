using UnityEngine;
using UnityEngine.InputSystem;
namespace My2D
{
    public class PlayerController : MonoBehaviour
    {
        #region
        //��ü
        private Rigidbody2D rb2D;
        
        //�ȴ� �ӵ�
        [SerializeField] private float walkSpeed = 4f;

        //�̵�
        //�̵� �Է°�
        private Vector2 inputMove;
        #endregion
        private void Awake()
        {
            rb2D = this.GetComponent<Rigidbody2D>();
        }
        #region Unity Event Method
        private void FixedUpdate()
        {
            //��ǲ���� ���� �¿� �̵�
            rb2D.linearVelocity = new Vector2(inputMove.x * walkSpeed, rb2D.linearVelocity.y);
            /*//Ű �Է°��� ���� ī�޶� �̵�
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