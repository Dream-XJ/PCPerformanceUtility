using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PCPerformanceUtility.Wpf.View.Pages;

namespace PCPerformanceUtility.Wpf.ViewModel;

public partial class MainViewModel : ObservableObject
{
	[ObservableProperty] private object? _currentPage = new HomePage();
	[RelayCommand]
	private void SwitchPage(string page)
	{
		CurrentPage = page switch
		{
			"HomePage" => new HomePage(),
			"ScanPage" => new ScanPage(),
			"SettingsPage" => new SettingsPage(),
			"HealthPage" => new HealthPage(),
			_ => throw new ArgumentOutOfRangeException(nameof(page))
		};
	}
}