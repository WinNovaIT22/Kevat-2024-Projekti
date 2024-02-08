using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    public float laserLength = 10f; // Laserin pituus
    public LayerMask targetLayer;    // Layer, jota vasten tarkistetaan osumia

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        CastLaser();
    }

    void CastLaser()
    {
        Vector2 startPos = transform.position;
        Vector2 endPos = startPos + (Vector2)transform.up * laserLength;

        // Tarkista osumat
        RaycastHit2D hit = Physics2D.Raycast(startPos, transform.up, laserLength, targetLayer);

        if (hit.collider != null)
        {
            // Osuma tapahtui
            endPos = hit.point;
            Debug.Log("Osuma objektiin: " + hit.collider.name);

            // Voit tässä käsitellä mitä haluat tehdä, kun laser osuu johonkin
            if (hit.collider.name == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            // Esimerkiksi voit kutsua hit.collider.SendMessage("TakeDamage", damageAmount);
        }

        // Päivitä line renderer
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }
}
