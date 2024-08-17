using System.Diagnostics;

namespace TimeTracker;

public partial class MainPage : ContentPage
{
    public IWorkItem ActiveWorkItem { get; set; }

    public MainPage()   //set default ActiveWorkItem (misc?) so no random lost time?
    {
        InitializeComponent();
        combobox.ItemsSource = new object[] { "apple", "dog", "money" };
    }

    private void combobox_SelectedItemChanged(object sender, EventArgs e) { }

    private void OnTaskStartTime(object sender, EventArgs e)
    {
        ActiveWorkItem.StartTime();

        Debug.WriteLine($"OnTaskStartTime: {DateTime.Now}");
    }

    private void OnTaskEndTime(object sender, EventArgs e)
    {
        ActiveWorkItem.EndTime();

        Debug.WriteLine($"OnTaskEndTime: {DateTime.Now}");
    }

    private void OnNextTaskStartTime(object sender, EventArgs e)
    {
        ActiveWorkItem.EndTime();
        //TODO: Set NEW ActiveWorkItem.StartTime();
        ActiveWorkItem.StartTime();

        Debug.WriteLine($"OnNextTaskStartTime: {DateTime.Now}");
    }
}
