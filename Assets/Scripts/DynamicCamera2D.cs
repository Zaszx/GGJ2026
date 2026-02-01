using UnityEngine;

public class DynamicCamera2D : MonoBehaviour
{
    [Header("Targets")]
    public Transform player1;
    public Transform player2;

    [Header("Movement")]
    public float smoothTime = 0.3f; // Takip gecikmesi (düşük = daha sıkı takip)
    public Vector3 offset = new Vector3(0, 0, -10f); // Z -10 olmalı ki her şeyi görsün

    [Header("Zoom")]
    public float minZoom = 5f;      // En yakın ne kadar girebilir
    public float maxZoom = 20f;     // En uzak ne kadar çıkabilir
    public float zoomLimiter = 5f; // Mesafeyi buna böler. Sayı KÜÇÜLDÜKÇE kamera daha çabuk uzaklaşır.

    private Vector3 velocity;
    private Camera cam;

    void Awake() => cam = GetComponent<Camera>();

    void LateUpdate()
    {
        if (!player1 || !player2) return;

        Move();
        Zoom();
    }

    void Move()
    {
        // İki oyuncunun orta noktasını bul
        Vector3 centerPoint = (player1.position + player2.position) * 0.5f;
        Vector3 targetPos = centerPoint + offset;

        // Kamerayı oraya pürüzsüz taşı
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

    void Zoom()
    {
        // Oyuncular arası mesafeyi ölç
        float distance = Vector2.Distance(player1.position, player2.position);

        // Mesafeye göre yeni zoom değerini hesapla
        // distance / zoomLimiter formülü doğrusal bir oran kurar.
        float targetZoom = Mathf.Clamp(distance / 2f + minZoom, minZoom, maxZoom);

        // Zoom geçişini yumuşat
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * 2f);
    }
}