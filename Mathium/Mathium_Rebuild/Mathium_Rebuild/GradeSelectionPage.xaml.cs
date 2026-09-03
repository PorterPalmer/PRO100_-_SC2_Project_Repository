using Mathium.Controllers;
using Mathium.Models;

namespace Mathium_Rebuild;

public partial class GradeSelectionPage : ContentPage, IQueryAttributable
{
    private bool _practiceMode;

    public GradeSelectionPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("PracticeMode", out object? practiceMode))
        {
            _practiceMode = practiceMode is bool value && value;
        }

        if (_practiceMode)
        {
            ModeLabel.Text = "PRACTICE MODE";
            TitleLabel.Text = "Choose Your Grade";
            DescriptionLabel.Text =
                "Choose a grade and practice with unlimited questions.";
        }
        else
        {
            ModeLabel.Text = "MATH QUIZ";
            TitleLabel.Text = "Choose Your Grade";
            DescriptionLabel.Text =
                "Choose a grade and try to beat your personal best.";
        }

        LoadHighScores();
    }

    private void LoadHighScores()
    {
        KindergartenScore.Text =
            FormatScore(GradeLevel.Kindergarten);

        FirstGradeScore.Text =
            FormatScore(GradeLevel.FirstGrade);

        SecondGradeScore.Text =
            FormatScore(GradeLevel.SecondGrade);

        ThirdGradeScore.Text =
            FormatScore(GradeLevel.ThirdGrade);

        FourthGradeScore.Text =
            FormatScore(GradeLevel.FourthGrade);

        FifthGradeScore.Text =
            FormatScore(GradeLevel.FifthGrade);

        SixthGradeScore.Text =
            FormatScore(GradeLevel.SixthGrade);

        SeventhGradeScore.Text =
            FormatScore(GradeLevel.SeventhGrade);

        EighthGradeScore.Text =
            FormatScore(GradeLevel.EighthGrade);

        NinthGradeScore.Text =
            FormatScore(GradeLevel.NinthGrade);

        TenthGradeScore.Text =
            FormatScore(GradeLevel.TenthGrade);

        EleventhGradeScore.Text =
            FormatScore(GradeLevel.EleventhGrade);

        TwelfthGradeScore.Text =
            FormatScore(GradeLevel.TwelfthGrade);
    }

    private string FormatScore(GradeLevel grade)
    {
        int score =
            ScoreManager.GetBestScore(grade);

        return _practiceMode
            ? $"Best: {score}"
            : $"Best: {score}/{ScoreManager.QuestionsPerQuiz}";
    }

    private async void OnGradeTapped(
        object sender,
        TappedEventArgs e)
    {
        if (sender is not Border border)
            return;

        if (border.GestureRecognizers.Count == 0)
            return;

        if (border.GestureRecognizers[0]
            is not TapGestureRecognizer tap)
        {
            return;
        }

        if (tap.CommandParameter is null)
            return;

        if (!Enum.TryParse(
                tap.CommandParameter.ToString(),
                out GradeLevel selectedGrade))
        {
            return;
        }

        await Shell.Current.GoToAsync(
            "MainPage",
            new ShellNavigationQueryParameters
            {
                { "SelectedGrade", selectedGrade },
                { "PracticeMode", _practiceMode }
            });
    }

    private async void OnBackClicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}