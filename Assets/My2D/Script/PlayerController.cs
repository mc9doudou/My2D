using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;
namespace My2D
{
    public class PlayerController : MonoBehaviour
    {
        #region
        //강체
        private Rigidbody2D rb2D;
        //애니메이터
        public Animator animator;

        //걷는 속도 - 좌우로 걷는다
        [SerializeField] private float walkSpeed = 4f;
        //뛰는 속도 - 좌우로 뛴다
        [SerializeField] private float runSpeed = 7f;

        //이동
        //이동 입력값
        private Vector2 inputMove;

        //이동 키입력
        private bool isMoving = false;
        //런 키입력
        private bool isRunning = false;

        //반전 
        //캐릭터 이미지가 바라보는 방향 상태 : 오른쪽 바라보면 true
        private bool isFacingRight = true;
        #endregion

        #region Property
        //이동 키입력값 - 애니메이터 파라미터 셋팅
        public bool IsMoving
        {
            get 
            { 
                return isMoving; 
            }
            set
            {
                isMoving = value;
                animator.SetBool(AnimationString.isMoving,value);
            }
        }
        //런 키입력값 - 애니메이터 파라미터 셋팅
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                isRunning = value;
                animator.SetBool(AnimationString.isRunning, value);
            }
        }
        //현재 이동 속도 - 읽기 전용
        public float CurrentSpeed
        {
            get
            {
                if (IsMoving)
                {
                    if (IsRunning)
                    {
                        return runSpeed;
                    }
                    else
                    {
                        return walkSpeed;
                    }
                }
                else 
                {
                    return 0f;  //idle state
                }
            }
        }
        //캐릭터 이미지가 바라보는 방향 상태 : 오른쪽 바라보면 true
        public bool IsFacingRight
        {
            get
            {
                return isFacingRight;
            }
            set
            {
                //반전 구현 
                if (isFacingRight != value)
                {
                    transform.localScale *= new Vector2(-1, 1);
                }
                isFacingRight = value;
            }

        }
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            rb2D = this.GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate()
        {
            //인풋값에 따라 좌우 이동
            rb2D.linearVelocity = new Vector2(inputMove.x * CurrentSpeed, rb2D.linearVelocity.y);
        }
        #endregion

        #region Custom Method
        public void OnMove(InputAction.CallbackContext context)
        {
            inputMove = context.ReadValue<Vector2>();
            //입력값에 따른 반전
            SetFacingDirection(inputMove);

            //인풋 값이 들어오면 IsMoving 파라미터 셋팅
            IsMoving = (inputMove != Vector2.zero);
        }
        public void OnRun(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                IsRunning = true;
            }
            else if (context.canceled)
            {
                IsRunning = false;
            }
        }
        //반전, 바라보는 방향 전환 - 입력값에 따라
        void SetFacingDirection(Vector2 moveInput)
        {
            if (moveInput.x > 0f && IsFacingRight == false) //왼쪽을 바라보고 있고 우로 이동 입력
            {
                IsFacingRight = true;
            }
            else if (moveInput.x < 0f && IsFacingRight == true)//오른쪽을 바라보고 있는데 좌로 이동 
            {
                IsFacingRight = false;
            }
        }
        #endregion
    }
}