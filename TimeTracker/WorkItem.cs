
using System.Diagnostics;

namespace TimeTracker;
public class WorkItem : IWorkItem
{
    private string _title;
    private string? _notes;
    private TimeSpan _elapsedTime;  //separate class A
    private bool _isRunning = false;
    //private DateTime? _startTime;
    //private DateTime? _endTime;

    private Stopwatch _stopwatch = new Stopwatch();     //separate class A

    public WorkItem(string title, string? notes)
    {
        _title = title;
        _notes = notes;
    }

    public string Title
    {
        get => _title;
        set
        {
            if (_title != value)
            {
                _title = value;
                OnTitleChange(nameof(Title));
            }
        }
    }

    public TimeSpan ElapsedTime
    {
        get
        {
            if (_isRunning)
            {
                return _elapsedTime + _stopwatch.Elapsed;
            }
            return _elapsedTime;
        }
        set
        {
            _elapsedTime = value;
            if (_isRunning)
            {
                _stopwatch.Restart();
            }
        }
    }
   
    public DateTime StartTime()
    {
        _isRunning = true;
        return DateTime.Now;   //SQL
    }

    public DateTime EndTime()
    {
        _isRunning = false;
        return DateTime.Now;   //SQL 
    }

    public void OnTitleChange(string title)
    {
        throw new NotImplementedException();    //SQL
    }
}
