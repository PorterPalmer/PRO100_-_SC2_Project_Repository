namespace Mathium_Rebuild;

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        // Load the SettingsPage XAML.
        InitializeComponent();

        // Restore the saved Dark Mode setting.
        bool darkMode =
            Preferences.Default.Get(
                "DarkMode",
                false);

        // Restore the saved light-mode background.
        string savedBackground =
            Preferences.Default.Get(
                "BackgroundColor",
                "#F4F6FB");

        // Set the switch without triggering theme changes
        // before the page has finished loading.
        DarkModeSwitch.IsToggled = darkMode;

        // Apply the saved theme.
        if (darkMode)
        {
            ApplyDarkTheme();
        }
        else
        {
            ApplyLightTheme(savedBackground);
        }
    }


    // =============================================================
    // DARK MODE
    // =============================================================

    /// <summary>
    /// Handles turning Dark Mode on or off.
    /// </summary>
    private void OnDarkModeToggled(
        object sender,
        ToggledEventArgs e)
    {
        // Save the setting.
        Preferences.Default.Set(
            "DarkMode",
            e.Value);

        if (e.Value)
        {
            ApplyDarkTheme();
        }
        else
        {
            // Restore the previously selected light background.
            string savedBackground =
                Preferences.Default.Get(
                    "BackgroundColor",
                    "#F4F6FB");

            ApplyLightTheme(savedBackground);
        }
    }


    /// <summary>
    /// Applies the black-and-white Dark Mode theme.
    /// </summary>
    private void ApplyDarkTheme()
    {
        Application.Current!.UserAppTheme =
            AppTheme.Dark;

        // Main page background is pure black.
        Application.Current.Resources["PageBackgroundColor"] =
            Colors.Black;

        // Cards are very dark gray so they remain visible
        // against the black background.
        Application.Current.Resources["CardBackgroundColor"] =
            Color.FromArgb("#111111");

        // Main text is white.
        Application.Current.Resources["PrimaryTextColor"] =
            Colors.White;

        // Secondary text is light gray.
        Application.Current.Resources["SecondaryTextColor"] =
            Color.FromArgb("#AAAAAA");

        // Purple accent remains visible against black.
        Application.Current.Resources["AccentColor"] =
            Color.FromArgb("#8B82FF");

        Application.Current.Resources["ButtonTextColor"] =
            Colors.White;


        // ---------------------------------------------------------
        // Dark answer bubble colors
        // ---------------------------------------------------------

        Application.Current.Resources["AnswerABackground"] =
            Color.FromArgb("#351D1D");

        Application.Current.Resources["AnswerBBackground"] =
            Color.FromArgb("#182A40");

        Application.Current.Resources["AnswerCBackground"] =
            Color.FromArgb("#19331E");

        Application.Current.Resources["AnswerDBackground"] =
            Color.FromArgb("#382F0F");


        Application.Current.Resources["AnswerAText"] =
            Color.FromArgb("#FF7777");

        Application.Current.Resources["AnswerBText"] =
            Color.FromArgb("#6FA9FF");

        Application.Current.Resources["AnswerCText"] =
            Color.FromArgb("#72D77D");

        Application.Current.Resources["AnswerDText"] =
            Color.FromArgb("#FFE066");
    }


    // =============================================================
    // LIGHT MODE
    // =============================================================

    /// <summary>
    /// Applies the light theme using the selected background.
    /// </summary>
    private void ApplyLightTheme(
        string background)
    {
        Application.Current!.UserAppTheme =
            AppTheme.Light;

        Application.Current.Resources["PageBackgroundColor"] =
            Color.FromArgb(background);

        Application.Current.Resources["CardBackgroundColor"] =
            Colors.White;

        Application.Current.Resources["PrimaryTextColor"] =
            Color.FromArgb("#171923");

        Application.Current.Resources["SecondaryTextColor"] =
            Color.FromArgb("#687083");

        Application.Current.Resources["AccentColor"] =
            Color.FromArgb("#6C63FF");

        Application.Current.Resources["ButtonTextColor"] =
            Colors.White;


        // ---------------------------------------------------------
        // Light answer bubble colors
        // ---------------------------------------------------------

        Application.Current.Resources["AnswerABackground"] =
            Color.FromArgb("#FFE3E3");

        Application.Current.Resources["AnswerBBackground"] =
            Color.FromArgb("#DCEBFF");

        Application.Current.Resources["AnswerCBackground"] =
            Color.FromArgb("#DFF7E3");

        Application.Current.Resources["AnswerDBackground"] =
            Color.FromArgb("#FFF7DA");


        Application.Current.Resources["AnswerAText"] =
            Color.FromArgb("#E94B4B");

        Application.Current.Resources["AnswerBText"] =
            Color.FromArgb("#357FEA");

        Application.Current.Resources["AnswerCText"] =
            Color.FromArgb("#42A84F");

        Application.Current.Resources["AnswerDText"] =
            Color.FromArgb("#C49B00");
    }


    // =============================================================
    // BACKGROUND SELECTION
    // =============================================================

    /// <summary>
    /// Saves the selected light-mode background.
    /// </summary>
    private void SetBackground(
        string color)
    {
        // Always save the selected color.
        Preferences.Default.Set(
            "BackgroundColor",
            color);

        // Dark Mode must remain pure black.
        if (DarkModeSwitch.IsToggled)
            return;

        // Apply the new background immediately.
        ApplyLightTheme(color);
    }


    private void OnLightBackgroundClicked(
        object sender,
        EventArgs e)
        => SetBackground("#F4F6FB");


    private void OnBlueBackgroundClicked(
        object sender,
        EventArgs e)
        => SetBackground("#E8F1FF");


    private void OnPurpleBackgroundClicked(
        object sender,
        EventArgs e)
        => SetBackground("#F1E8FF");


    private void OnGreenBackgroundClicked(
        object sender,
        EventArgs e)
        => SetBackground("#E8F8EC");


    // =============================================================
    // BACK BUTTON
    // =============================================================

    private async void OnBackClicked(
        object sender,
        EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}