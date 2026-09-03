using Mathium.Controllers;
using Mathium.Models;

namespace Mathium_Rebuild;

public partial class MainPage : ContentPage, IQueryAttributable
{
    private GradeLevel _selectedGrade;
    private bool _practiceMode;

    private readonly QuestionGenerator _questionGenerator;

    private readonly Border[] _bubbles;

    private double _correctAnswer;
    private int _score;
    private int _currentQuestion;
    private bool _answered;

    public MainPage()
    {
        InitializeComponent();

        _questionGenerator =
            new QuestionGenerator();

        _bubbles =
        [
            BubbleA,
            BubbleB,
            BubbleC,
            BubbleD
        ];
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
                "PracticeMode",
                out object? practiceMode))
        {
            _practiceMode =
                practiceMode is bool value && value;
        }

        _score = 0;
        _currentQuestion = 0;

        if (_practiceMode)
        {
            ModeLabel.Text = "PRACTICE";
        }
        else
        {
            ModeLabel.Text = "QUIZ";
        }

        LoadQuestion();
    }

    private void LoadQuestion()
    {
        _answered = false;

        BubbleA.Stroke =
            GetResourceColor("AnswerAText");

        BubbleA.Background =
            GetResourceColor("AnswerABackground");

        BubbleB.Stroke =
            GetResourceColor("AnswerBText");

        BubbleB.Background =
            GetResourceColor("AnswerBBackground");

        BubbleC.Stroke =
            GetResourceColor("AnswerCText");

        BubbleC.Background =
            GetResourceColor("AnswerCBackground");

        BubbleD.Stroke =
            GetResourceColor("AnswerDText");

        BubbleD.Background =
            GetResourceColor("AnswerDBackground");

        FeedbackLabel.Text =
            string.Empty;

        NextButton.IsVisible =
            false;

        if (_practiceMode)
        {
            ProgressLabel.Text =
                $"Question {_currentQuestion + 1}";

            QuizProgress.Progress = 0;
        }
        else
        {
            ProgressLabel.Text =
                $"Question {_currentQuestion + 1}" +
                $"/{ScoreManager.QuestionsPerQuiz}";

            QuizProgress.Progress =
                (double)(_currentQuestion + 1) /
                ScoreManager.QuestionsPerQuiz;
        }

        ScoreLabel.Text =
            _score.ToString();

        MathQuestion question =
            _questionGenerator.GenerateQuestion(
                _selectedGrade);

        QuestionLabel.Text =
            question.Question;

        if (question is SingleAnswerQuestion singleQuestion)
        {
            _correctAnswer =
                singleQuestion.Answer;

            List<double> answers =
                GenerateAnswerChoices(
                    _correctAnswer);

            OptionALabel.Text =
                FormatAnswer(answers[0]);

            OptionBLabel.Text =
                FormatAnswer(answers[1]);

            OptionCLabel.Text =
                FormatAnswer(answers[2]);

            OptionDLabel.Text =
                FormatAnswer(answers[3]);

            BubbleA.BindingContext =
                answers[0];

            BubbleB.BindingContext =
                answers[1];

            BubbleC.BindingContext =
                answers[2];

            BubbleD.BindingContext =
                answers[3];
        }
    }

    private Color GetResourceColor(
        string resourceKey)
    {
        if (Application.Current != null &&
            Application.Current.Resources.TryGetValue(
                resourceKey,
                out object? resource))
        {
            if (resource is Color color)
                return color;
        }

        return Colors.Transparent;
    }

    private string FormatAnswer(
        double answer)
    {
        if (answer == Math.Truncate(answer))
            return answer.ToString("0");

        return answer.ToString("0.##");
    }

    private List<double> GenerateAnswerChoices(
        double correctAnswer)
    {
        HashSet<double> answers =
        [
            correctAnswer
        ];

        while (answers.Count < 4)
        {
            int offset =
                Random.Shared.Next(1, 6);

            double wrongAnswer;

            if (Random.Shared.Next(2) == 0)
            {
                wrongAnswer =
                    correctAnswer + offset;
            }
            else
            {
                wrongAnswer =
                    correctAnswer - offset;
            }

            if (wrongAnswer < 0)
                continue;

            answers.Add(wrongAnswer);
        }

        return answers
            .OrderBy(_ => Random.Shared.Next())
            .ToList();
    }

    private async void OnOptionTapped(
        object sender,
        TappedEventArgs e)
    {
        if (sender is not Border bubble)
            return;

        await SelectAnswer(bubble);
    }

    private async Task SelectAnswer(
        Border bubble)
    {
        if (_answered)
            return;

        if (bubble.BindingContext is not double chosenAnswer)
            return;

        _answered = true;

        bool isCorrect =
            chosenAnswer == _correctAnswer;

        if (isCorrect)
        {
            _score++;

            bubble.Stroke =
                Colors.LimeGreen;

            bubble.Background =
                Color.FromArgb("#D4F7D4");

            FeedbackLabel.Text =
                "Correct! ✓";

            FeedbackLabel.TextColor =
                Colors.LimeGreen;
        }
        else
        {
            bubble.Stroke =
                Colors.Crimson;

            bubble.Background =
                Color.FromArgb("#F9D4D4");

            foreach (Border answerBubble in _bubbles)
            {
                if (answerBubble.BindingContext is double answer &&
                    answer == _correctAnswer)
                {
                    answerBubble.Stroke =
                        Colors.LimeGreen;

                    answerBubble.Background =
                        Color.FromArgb("#D4F7D4");

                    break;
                }
            }

            FeedbackLabel.Text =
                $"Not quite — correct answer is " +
                $"{FormatAnswer(_correctAnswer)}";

            FeedbackLabel.TextColor =
                Colors.Crimson;
        }

        await bubble.ScaleTo(
            1.08,
            100);

        await bubble.ScaleTo(
            1.0,
            100);

        ScoreLabel.Text =
            _score.ToString();

        if (_practiceMode)
        {
            NextButton.Text =
                "NEXT QUESTION   →";

            NextButton.IsVisible =
                true;

            return;
        }

        if (_currentQuestion + 1 >=
            ScoreManager.QuestionsPerQuiz)
        {
            NextButton.Text =
                "VIEW RESULTS   →";
        }
        else
        {
            NextButton.Text =
                "NEXT QUESTION   →";
        }

        NextButton.IsVisible =
            true;
    }

    private async void OnNextClicked(
        object sender,
        EventArgs e)
    {
        if (_practiceMode)
        {
            _currentQuestion++;
            LoadQuestion();
            return;
        }

        if (_currentQuestion + 1 >=
            ScoreManager.QuestionsPerQuiz)
        {
            bool newHighScore =
                ScoreManager.SaveScore(
                    _selectedGrade,
                    _score);

            int bestScore =
                ScoreManager.GetBestScore(
                    _selectedGrade);

            await Shell.Current.GoToAsync(
                "ResultsPage",
                new ShellNavigationQueryParameters
                {
                    { "SelectedGrade", _selectedGrade },
                    { "Score", _score },
                    { "BestScore", bestScore },
                    { "NewHighScore", newHighScore }
                });

            return;
        }

        _currentQuestion++;

        LoadQuestion();
    }

    private async void OnBackClicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}