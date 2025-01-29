using System;

public class ThemeService
{
    public event Action? OnThemeChange;
    private bool _isDarkMode;

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            _isDarkMode = value;
            NotifyStateChanged();
        }
    }

    private void NotifyStateChanged() => OnThemeChange?.Invoke();
} 