namespace WattHappens.Application.Common;

public class ProcessingStateContainer
{
    private bool _isProcessing = false;

    public event Action? OnStateChanged;

    public bool IsProcessing
    {
        get => _isProcessing;
        set
        {
            _isProcessing = value;
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnStateChanged?.Invoke();
}