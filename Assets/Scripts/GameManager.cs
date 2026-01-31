using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private Player Player1;
	[SerializeField] private Player Player2;

	private void Awake()
	{
        Instance = this;

		if (Player1 == null)
			Player1 = GameObject.FindWithTag("Player1").GetComponent<Player>();
		if (Player2 == null)
			Player2 = GameObject.FindWithTag("Player2").GetComponent<Player>();
	}

	void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Fire(PlayerController firingPlayer)
	{
        Fire(firingPlayer.GetComponent<Player>());
	}

    public void Fire(Player firingPlayer)
	{
		Vector3 direction = GetFiringDirectionForPlayer(firingPlayer);

		Projectile firedProjectile = Instantiate(Prefabs.Projectile).GetComponent<Projectile>();
		firedProjectile.transform.position = firingPlayer.transform.position + direction;
		firedProjectile.transform.right = direction;

		firedProjectile.Init(direction);
	}

	public Vector2 GetFiringDirectionForPlayer(Player firingPlayer)
	{
		Player targetPlayer = firingPlayer == Player1 ? Player2 : Player1;

		Vector2 direction = (targetPlayer.transform.position - firingPlayer.transform.position).normalized;

		return direction;
	}

    public void OnPlayerDeath(Player deadPlayer)
	{
		SceneManager.LoadScene("GameOver");
	}
}
