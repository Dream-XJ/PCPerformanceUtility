using System;
using System.Linq;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PCPerformanceUtility.Wpf.ViewModel;

public partial class ScanViewModel : ObservableObject
{
	[ObservableProperty] private string? _desktopFilesCount = $"桌面文件数量: {GetDesktopFilesCount()}";
	[ObservableProperty] private string? _desktopFilesSize = $"桌面文件大小: {GetDesktopFilesSize()}";

	private static string? desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
	private static string[]? desktopFiles = Directory.GetFiles(desktopPath, "*.*", System.IO.SearchOption.AllDirectories);

	private static string GetDesktopFilesCount() => desktopFiles.Length.ToString();

	private static string GetDesktopFilesSize()
	{
		var size = desktopFiles.Select(file => new System.IO.FileInfo(file)).Select(fileInfo => fileInfo.Length).Sum();
		//return $"{size.ToString()} KB";
		// byte to gigabyte
		return $"{(size / 1024d / 1024d / 1024d).ToString("0.00")} GB";
	}

	[RelayCommand]
	private void Refresh()
	{
		DesktopFilesCount = $"桌面文件数量: {GetDesktopFilesCount()}";
		DesktopFilesSize = $"桌面文件大小: {GetDesktopFilesSize()}";
	}

	[RelayCommand]
	private void HideDesktopFiles()
	{
		//foreach (var desktopFile in desktopFiles)
		//{
		//	File.SetAttributes("C:\\MyFile.txt", File.GetAttributes("C:\\MyFile.txt") | FileAttributes.Hidden);
		//}
		
	}

	[RelayCommand]
	private void RestoreDesktopFiles()
	{
		//File.SetAttributes("C:\\MyFile.txt", File.GetAttributes("C:\\MyFile.txt") & ~FileAttributes.Hidden);
	}

}