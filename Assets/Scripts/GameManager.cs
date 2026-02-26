using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI References")]
    public TMP_Text playerText;
    public TMP_Text computerText;
    public TMP_Text resultText;
    public TMP_Text scoreText;

    public Button replayButton;
    public Button shootButton;
    public Button exitButton;

    [Header("Audio")]
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip drawSound;

    private Choice playerChoice = Choice.None;
    private Choice computerChoice = Choice.None;

    private int playerScore = 0;
    private int computerScore = 0;

    private bool canShoot = false;

    public enum Choice
    {
        None,
        Rock,
        Paper,
        Scissors
    }

    void Start()
    {
        replayButton.interactable = true;
        shootButton.interactable = false;

        UpdateScoreUI();
        ClearRoundUI();
    }

    void Update()
    {
        shootButton.interactable = (playerChoice != Choice.None && canShoot);
    }

    // ---------------------------
    // PLAYER CHOICE BUTTONS
    // ---------------------------

    public void SelectRock()
    {
        if (!canShoot) return;
        playerChoice = Choice.Rock;
        playerText.text = "Player: Rock";
    }

    public void SelectPaper()
    {
        if (!canShoot) return;
        playerChoice = Choice.Paper;
        playerText.text = "Player: Paper";
    }

    public void SelectScissors()
    {
        if (!canShoot) return;
        playerChoice = Choice.Scissors;
        playerText.text = "Player: Scissors";
    }

    // ---------------------------
    // SHOOT ROUND
    // ---------------------------

    public void Shoot()
    {
        if (!canShoot || playerChoice == Choice.None) return;

        canShoot = false;
        shootButton.interactable = false;

        computerChoice = (Choice)Random.Range(1, 4);
        computerText.text = "Computer: " + computerChoice.ToString();

        string winner = DetermineWinner();
        DisplayResult(winner);
    }

    // ---------------------------
    // DETERMINE WINNER
    // ---------------------------

    string DetermineWinner()
    {
        if (playerChoice == computerChoice)
            return "Draw";

        switch (playerChoice)
        {
            case Choice.Rock:
                return (computerChoice == Choice.Scissors) ? "Player" : "Computer";

            case Choice.Paper:
                return (computerChoice == Choice.Rock) ? "Player" : "Computer";

            case Choice.Scissors:
                return (computerChoice == Choice.Paper) ? "Player" : "Computer";
        }

        return "Draw";
    }

    // ---------------------------
    // DISPLAY RESULT + PLAY SFX
    // ---------------------------

    void DisplayResult(string winner)
    {
        if (winner == "Draw")
        {
            resultText.text = "Draw!";
            resultText.color = Color.yellow;

            if (drawSound != null)
                AudioManager.Instance.PlaySFX(drawSound);
        }
        else if (winner == "Player")
        {
            resultText.text = "Player Wins!";
            resultText.color = Color.green;
            playerScore++;

            if (winSound != null)
                AudioManager.Instance.PlaySFX(winSound);
        }
        else
        {
            resultText.text = "Computer Wins!";
            resultText.color = Color.red;
            computerScore++;

            if (loseSound != null)
                AudioManager.Instance.PlaySFX(loseSound);
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: Player " + playerScore + "    Computer " + computerScore;
    }

    // ---------------------------
    // REPLAY ROUND
    // ---------------------------

    public void Replay()
    {
        canShoot = true;
        playerChoice = Choice.None;

        ClearRoundUI();
    }

    void ClearRoundUI()
    {
        playerText.text = "Player:";
        computerText.text = "Computer:";
        resultText.text = "";
    }

    // ---------------------------
    // EXIT TO MAIN MENU
    // ---------------------------

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
}