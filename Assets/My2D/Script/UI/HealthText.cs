using UnityEngine;
using TMPro;

namespace My2D
{
    //- Damage가 위쪽으로 이동한다
    //- Damage 페이드 아웃 효과, Damage 페이드 아웃 효과 후 킬 - text의 컬러값으로 페이드 효과
    public class HealthText : MonoBehaviour
    {
        #region Variables
        //이동 
        [SerializeField]private float moveSpeed = 10f;
        private RectTransform textTransform;

        //페이드 효과
        public TextMeshProUGUI healthText;

        //Fadeout 타이머
        public float fadeTime = 1f;
        private float fadeCountdown = 0f;

        private Color startColor;
        #endregion

        #region Unity Event Method
        private void Awake()
        {
            //참조
            textTransform = this.GetComponent<RectTransform>();
            healthText = this.GetComponent<TextMeshProUGUI>();

            startColor = healthText.color ;
        }
        private void Update()
        {
            //이동
            textTransform.position += Vector3.up * Time.deltaTime * moveSpeed;

            fadeCountdown += Time.deltaTime;

            float newAlpha = startColor.a * (1 - fadeCountdown / fadeTime);
            healthText.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
            if (fadeCountdown >= fadeTime)
            {
                Destroy(gameObject);
            }
        }
        #endregion
    }
}
