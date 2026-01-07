using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public GameObject bullet;
    public GameObject homingBullet;

    public void NewBullet(Vector2 position, float horizontalSpeed, float verticalSpeed, int damageAmount)
    {
        GameObject newBullet = Instantiate(bullet, position, Quaternion.identity);
        Bullet bulletScript = newBullet.GetComponent<Bullet>();

        bulletScript.horizontalSpeed = horizontalSpeed;
        bulletScript.verticalSpeed = verticalSpeed;
        bulletScript.damageAmount = damageAmount;
    }

    public void NewHomingBullet(Vector2 position, float speed, int damageAmount)
    {
        GameObject newHomingBullet = Instantiate(homingBullet, position, Quaternion.identity);
        HomingBullet homingBulletScript = newHomingBullet.GetComponent<HomingBullet>();
        homingBulletScript.speed = speed;
        homingBulletScript.damageAmount = damageAmount;
    }
}
