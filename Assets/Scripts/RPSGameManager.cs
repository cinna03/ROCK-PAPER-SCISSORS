using UnityEngine;
using UnityEngine.UI;

public class RPSGameManager : MonoBehaviour
{
    // Enum for choices
    public enum Choice { None, Rock, Paper, Scissors }

    // Track selections
    public Choice playerChoice = Choice.None;
    private Choice computerChoice = Choice.None;

    // UI references
    public Text playerText;
    public Text computerText;
    public Text resultText;

    public Button shootButton;
    public Button replayButton;

    private bool roundPlayed = false;

    void Start()
    {
        replayButton.interactable = false; // Replay disabled at start
        resultText.text = "";
    }

    // Called by Rock, Paper, Scissors buttons
    public void SelectChoice(int choiceIndex)
    {
        if (roundPlayed) return; // Anti-cheat
        playerChoice = (Choice)choiceIndex;
        playerText.text = "Player: " + playerChoice.ToString();
    }

    // Called by Shoot button
    public void Shoot()
    {
        if (playerChoice == Choice.None) return;

        // Random computer choice
        computerChoice = (Choice)Random.Range(1, 4);
        computerText.text = "Computer: " + computerChoice.ToString();

        // Determine winner
        string result = DetermineWinner(playerChoice, computerChoice);
        resultText.text = result;

        roundPlayed = true;
        replayButton.interactable = true;
    }

    // Called by Replay button
    public void Replay()
    {
        playerChoice = Choice.None;
        computerChoice = Choice.None;
        playerText.text = "Player: ";
        computerText.text = "Computer: ";
        resultText.text = "";
        roundPlayed = false;
        replayButton.interactable = false;
    }

    private string DetermineWinner(Choice player, Choice computer)
    {
        if (player == computer) return "Draw!";
        switch (player)
        {
            case Choice.Rock:
                return (computer == Choice.Scissors) ? "You Win!" : "Computer Wins!";
            case Choice.Paper:
                return (computer == Choice.Rock) ? "You Win!" : "Computer Wins!";
            case Choice.Scissors:
                return (computer == Choice.Paper) ? "You Win!" : "Computer Wins!";
            default:
                return "Error";
        }
    }
}
