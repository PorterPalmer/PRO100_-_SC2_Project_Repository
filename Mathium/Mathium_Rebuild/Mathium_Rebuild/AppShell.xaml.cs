namespace Mathium_Rebuild;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register pages that are not directly contained
        // in the Shell visual hierarchy.

        Routing.RegisterRoute(
            "GradeSelectionPage",
            typeof(GradeSelectionPage));

        Routing.RegisterRoute(
            "MainPage",
            typeof(MainPage));

        Routing.RegisterRoute(
            "SettingsPage",
            typeof(SettingsPage));

        Routing.RegisterRoute(
            "ResultsPage",
            typeof(ResultsPage));
    }
}