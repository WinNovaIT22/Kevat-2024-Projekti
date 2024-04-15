using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float shootInterval = 2f;
    public int bulletsPerShot = 4;
    public float rotationSpeed = 50f;
    public float directionChangeInterval = 10f;

    private Transform[] firePoints;
    private float timer = 0f;
    private float directionTimer = 0f;
    private int rotationDirection = 1; // 1 for clockwise, -1 for counterclockwise

    void Start()
    {
        CalculateFirePoints();
    }

    void Update()
    {
        directionTimer += Time.deltaTime;
        if (directionTimer >= directionChangeInterval)
        {
            ChangeRotationDirection();
            directionTimer = 0f;
        }

        RotateCircle();

        timer += Time.deltaTime;

        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    void CalculateFirePoints()
    {
        firePoints = new Transform[bulletsPerShot];
        float angleStep = 360f / bulletsPerShot;
        float angle = 0f;

        for (int i = 0; i < bulletsPerShot; i++)
        {
            Vector3 offset = new Vector3(Mathf.Sin((angle * Mathf.PI) / 180f), Mathf.Cos((angle * Mathf.PI) / 180f), 0f);
            Vector3 firePointPosition = transform.position + offset;

            GameObject firePointObject = new GameObject("FirePoint" + i);
            firePointObject.transform.position = firePointPosition;
            firePointObject.transform.parent = transform;

            firePoints[i] = firePointObject.transform;

            angle += angleStep;
        }
    }

    void RotateCircle()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * rotationDirection * Time.deltaTime);
    }

    void ChangeRotationDirection()
    {
        rotationDirection *= -1; // Change rotation direction
    }

    void Shoot()
    {
        for (int i = 0; i < bulletsPerShot; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoints[i].position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = (firePoints[i].position - transform.position).normalized * 10f;
        }
    }
}
