using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private PlayerController _player1;
	private PlayerController _player2;

	private void Awake()
	{
        Instance = this;
        _player1 = GameObject.FindWithTag("Player1").GetComponent<PlayerController>();
        _player2 = GameObject.FindWithTag("Player2").GetComponent<PlayerController>();
	}

	void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Fire(PlayerController firingPlayer)
	{
        PlayerController targetPlayer = firingPlayer == _player1 ? _player2 : _player1;

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
