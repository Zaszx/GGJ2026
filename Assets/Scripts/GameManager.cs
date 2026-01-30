using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerController Player1;
	[SerializeField] private PlayerController Player2;

	private void Awake()
	{
        Instance = this;
	}

	void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Fire(PlayerController firingPlayer)
	{
        PlayerController targetPlayer = firingPlayer == Player1 ? Player2 : Player1;

        Vector3 direction = (targetPlayer.transform.position - firingPlayer.transform.position).normalized;

        Projectile firedProjectile = Instantiate(Prefabs.Projectile).GetComponent<Projectile>();
        firedProjectile.transform.position = firingPlayer.transform.position + direction;
        firedProjectile.transform.right = direction;

        firedProjectile.Init(direction);
	}

    public void OnPlayerDeath(PlayerController deadPlayer)
	{

	}
}
