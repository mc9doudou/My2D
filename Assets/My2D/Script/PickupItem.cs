using System.Collections.Generic;
using UnityEngine;

namespace My2D
{
    public class PickupItem : MonoBehaviour
    {
        #region Variables
        private Vector3 spinRotateSpeed = new Vector3(0f, 180f, 0f);

        [SerializeField]private float restoreHealth = 30f;

        //사운드 효과
        private AudioSource pickupSource;
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            pickupSource = this.GetComponent<AudioSource>();
        }
        void Update()
        {
            transform.eulerAngles += spinRotateSpeed * Time.deltaTime;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //플레이어가 충돌하면 Damageable 컴포넌트 찾아서 
            //Damageable에 있는 Heal 함수를 호출한다

            Damageable damageable = collision.GetComponent<Damageable>();

            if (damageable != null)
            {
                bool isHeal = damageable.Heal(restoreHealth);

                //아이템 킬 판단
                if (isHeal)
                {
                    //사운드 효과
                    if (pickupSource)
                    {
                        pickupSource.PlayOneShot(pickupSource.clip);
                    }

                    Destroy(gameObject);
                }
            }
        }
        #endregion
    }
}