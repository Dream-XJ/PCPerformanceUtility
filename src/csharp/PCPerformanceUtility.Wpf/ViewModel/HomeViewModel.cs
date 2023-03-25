using CommunityToolkit.Mvvm.ComponentModel;

namespace PCPerformanceUtility.Wpf.ViewModel;

[ObservableObject]
public partial class HomeViewModel
{
	[ObservableProperty] private string? _everydayPoem = GetEveryDayPoem();

	private static string GetEveryDayPoem() => "「一代天骄，成吉思汗，只识弯弓射大雕。」";
}