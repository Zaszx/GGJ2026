using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public TMP_Text GameOverText;

    void Start()
    {
        if(PlayerMaskSelections.PlayerOneWins) 
            GameOverText.text = "Player 1 Wins!\n\nPress space to play again";
        else
			GameOverText.text = "Player 2 Wins!\n\nPress space to play again";
	}

	// Update is called once per frame
	void Update()
    {
        if(Input.GetKey(KeyCode.Space))
		{
            SceneManager.LoadScene("MaskSelection");
		}
    }
}
