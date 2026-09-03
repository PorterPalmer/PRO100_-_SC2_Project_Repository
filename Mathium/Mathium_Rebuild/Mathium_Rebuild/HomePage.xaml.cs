namespace Mathium_Rebuild;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        // Load the HomePage XAML.
        InitializeComponent();
    }


    /// <summary>
    /// Opens the grade selection screen for normal quizzes.
    /// </summary>
    private async void OnQuizClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
            "GradeSelectionPage",
            new ShellNavigationQueryParameters
            {
            { "PracticeMode", false }
            });
    }


    /// <summary>
    /// Opens the grade selection screen for Practice Mode.
    /// </summary>
    private async void OnPracticeClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(
            "GradeSelectionPage",
            new ShellNavigationQueryParameters
            {
            { "PracticeMode", true }
            });
    }


    /// <summary>
    /// Opens the Settings page.
    /// </summary>
    private async void OnSettingsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SettingsPage");
    }
}