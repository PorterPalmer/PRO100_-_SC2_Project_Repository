using Mathium.Models;

namespace Mathium_Rebuild;

public partial class ResultsPage : ContentPage, IQueryAttributable
{
    private GradeLevel _selectedGrade;
    private int _score;
    private int _bestScore;
    private bool _newHighScore;

    public ResultsPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(
        IDictionary<string, object> query)
    {
        if (query.TryGetValue(
                "SelectedGrade",
                out object? grade))
        {
            if (grade is GradeLevel gradeValue)
            {
                _selectedGrade = gradeValue;
            }
            else if (Enum.TryParse(
                         grade?.ToString(),
                         out GradeLevel parsedGrade))
            {
                _selectedGrade = parsedGrade;
            }
        }

        if (query.TryGetValue(
                "Score",
                out object? score) &&
            score is int scoreValue)
        {
            _score = scoreValue;
        }

        if (query.TryGetValue(
                "BestScore",
                out object? bestScore) &&
            bestScore is int bestScoreValue)
        {
            _bestScore = bestScoreValue;
        }

        if (query.TryGetValue(
                "NewHighScore",
                out object? newHighScore) &&
            newHighScore is bool highScoreValue)
        {
            _newHighScore = highScoreValue;
        }

        GradeLabel.Text =
            GetGradeName(_selectedGrade);

        ScoreLabel.Text =
            $"{_score}/10";

        BestScoreLabel.Text =
            $"Personal Best: {_bestScore}/10";

        if (_newHighScore)
        {
            HighScoreLabel.Text =
                "NEW PERSONAL BEST! 🎉";

            HighScoreLabel.IsVisible =
                true;
        }
        else
        {
            HighScoreLabel.IsVisible =
                false;
        }
    }

    private string GetGradeName(
        GradeLevel grade)
    {
        return grade switch
        {
            GradeLevel.Kindergarten =>
                "Kindergarten",

            GradeLevel.FirstGrade =>
                "1st Grade",

            GradeLevel.SecondGrade =>
                "2nd Grade",

            GradeLevel.ThirdGrade =>
                "3rd Grade",

            GradeLevel.FourthGrade =>
                "4th Grade",

            GradeLevel.FifthGrade =>
                "5th Grade",

            GradeLevel.SixthGrade =>
                "6th Grade",

            GradeLevel.SeventhGrade =>
                "7th Grade",

            GradeLevel.EighthGrade =>
                "8th Grade",

            GradeLevel.NinthGrade =>
                "9th Grade",

            GradeLevel.TenthGrade =>
                "10th Grade",

            GradeLevel.EleventhGrade =>
                "11th Grade",

            GradeLevel.TwelfthGrade =>
                "12th Grade",

            _ => grade.ToString()
        };
    }

    private async void OnTryAgainClicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync(
            "../MainPage",
            new ShellNavigationQueryParameters
            {
                { "SelectedGrade", _selectedGrade },
                { "PracticeMode", false }
            });
    }

    private async void OnHomeClicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync(
            "//HomePage");
    }

    private async void OnBackClicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync(
            "//HomePage");
    }
}