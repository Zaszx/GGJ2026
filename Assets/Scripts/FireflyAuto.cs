using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireflyAuto : MonoBehaviour
{
    [Header("Hareket Ayarlarý")]
    // DEÐÝÞTÝ: Artýk 5 birimlik geniþ bir alanda gezecek
    public float movementRadius = 5.0f;

    // DEÐÝÞTÝ: Hýzý 3'ten 8'e çýktý, fýrlayýp gidecek
    public float moveSpeed = 8.0f;
    public float waitTime = 0.1f;

    [Header("Renk Ayarlarý (Sarý Tonlarý)")]
    public Color colorBright = new Color(1f, 0.9f, 0.4f);
    public Color colorDim = new Color(1f, 0.6f, 0.0f);

    [Header("Iþýk Þiddeti")]
    public float minIntensity = 0.4f;
    public float maxIntensity = 1.8f;
    public float flickerSpeed = 10.0f;

    [Header("Iþýk Alaný")]
    public float minLightSize = 4.0f;
    public float maxLightSize = 6.0f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float waitTimer;
    private Light2D myLight;
    private float randomOffset;

    void Start()
    {
        myLight = GetComponent<Light2D>();
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 100f);
        PickNewPosition();
    }

    void Update()
    {
        MoveFirefly();
        FlickerLight();
    }

    void MoveFirefly()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                PickNewPosition();
                waitTimer = waitTime;
            }
        }
    }

    void PickNewPosition()
    {
        Vector2 randomPoint = Random.insideUnitCircle * movementRadius;
        targetPosition = startPosition + new Vector3(randomPoint.x, randomPoint.y, 0);
    }

    void FlickerLight()
    {
        if (myLight != null)
        {
            float noise = Mathf.PerlinNoise((Time.time + randomOffset) * flickerSpeed, 0);

            // 1. Parlaklýk deðiþimi
            myLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

            // 2. Boyut deðiþimi
            myLight.pointLightOuterRadius = Mathf.Lerp(minLightSize, maxLightSize, noise);

            // 3. Renk deðiþimi
            myLight.color = Color.Lerp(colorDim, colorBright, noise);
        }
    }
}