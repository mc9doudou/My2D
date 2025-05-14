using UnityEngine;
namespace My2D
{
    //발사체 기능: 이동하기, 충돌하기, 데미지 입히기
    public class Projectile : MonoBehaviour
    { 
        #region Variables
        //참조
        private Rigidbody2D rb2D;
        //그라운드, 벽 체크
        private TouchingDirection touchingDirection;
        //이동속도 - 좌 우로 이동, 위 아래로 이동하지 않는다
        [SerializeField] private Vector2 moveVelocity;

        [SerializeField] private Vector2 knockback;
        //공격력
        [SerializeField] private float projectileDamage = 10f;

        //데미지 효과sfx, vfx
        public GameObject projectEffectPrefab;
        public Transform effectPos;
        
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            rb2D = this.GetComponent<Rigidbody2D>();
        }
        private void Start()
        {
            //초기화
            rb2D.linearVelocity = new Vector2(moveVelocity.x * this.transform.localScale.x, moveVelocity.y);
        }
        private void FixedUpdate()
        {
            
        }

        #endregion

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //collision에서 Damageable 컴포넌트를 찾아서 TakeDamage 주세요
            //Debug.Log($"플레이어에게 데미지 {attackDamage}을 준다");
            Damageable damageable = collision.GetComponent<Damageable>();

            if (damageable != null)
            {
                //공격하는 캐릭터의 방향에 따라 밀리는 방향 설정
                Vector2 deliveredKnockback = this.transform.localScale.x > 0
                    ? knockback : new Vector2(-knockback.x, knockback.y);

                bool isHit = damageable.TakeDamage(projectileDamage, deliveredKnockback);

                if (isHit)
                {
                    GameObject effectGo =Instantiate(projectEffectPrefab, effectPos.position, Quaternion.identity);
                    Destroy(effectGo, 0.4f);
                }
            }
            //화살 킬
            Destroy(gameObject);
        }
        
    }
}