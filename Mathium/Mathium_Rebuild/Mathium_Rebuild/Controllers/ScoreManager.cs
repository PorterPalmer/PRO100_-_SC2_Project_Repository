using Mathium.Models;

namespace Mathium.Controllers;

public static class ScoreManager
{
    // Number of questions in a normal quiz.
    public const int QuestionsPerQuiz = 10;

    // Prefix used for all saved high-score preference keys.
    private const string HighScorePrefix = "HighScore_";


    /// <summary>
    /// Gets the saved high score for a specific grade.
    /// </summary>
    public static int GetBestScore(GradeLevel grade)
    {
        string key =
            GetKey(grade);

        return Preferences.Default.Get(
            key,
            0);
    }


    /// <summary>
    /// Saves a new high score if it is better than
    /// the player's previous score.
    ///
    /// Returns true if a new high score was created.
    /// </summary>
    public static bool SaveScore(
        GradeLevel grade,
        int score)
    {
        int previousBest =
            GetBestScore(grade);

        // Only save if the new score is higher.
        if (score <= previousBest)
            return false;

        Preferences.Default.Set(
            GetKey(grade),
            score);

        return true;
    }


    /// <summary>
    /// Creates the preference key for a grade.
    ///
    /// Example:
    /// HighScore_SixthGrade
    /// </summary>
    private static string GetKey(
        GradeLevel grade)
    {
        return HighScorePrefix +
               grade.ToString();
    }
}