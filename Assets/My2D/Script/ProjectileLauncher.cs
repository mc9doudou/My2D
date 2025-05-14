using UnityEngine;
namespace My2D
{
    public class ProjectileLauncher : MonoBehaviour
    {
        #region Variables
        //발사체 프리팹
        public GameObject projectilePrefab;
        //발사 위치
        public Transform firePoint;
        #endregion

        #region Custom Method
        //발사체 발사
        public void FireProjectile()
        {
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, projectilePrefab.transform.rotation);
            Vector3 originScale = projectile.transform.localScale;
            //캐릭터의 발사 방향으로 화살을 앞 방향 설정 
            projectile.transform.localScale = new Vector3(
                originScale.x * (transform.parent.localScale.x > 0 ? 1 : -1), 
                originScale.y, 
                originScale.z);

            //발사체 발사후 3초뒤 킬
            Destroy(projectile, 3f);
        }
        #endregion
    }
}