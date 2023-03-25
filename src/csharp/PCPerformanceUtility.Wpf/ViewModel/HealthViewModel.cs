using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Controls;
using Microsoft.Win32;
using PCPerformanceUtility.Wpf.Common;

namespace PCPerformanceUtility.Wpf.ViewModel;

public partial class HealthViewModel : ObservableObject
{
	[ObservableProperty] private string _allSystemInfo = GetSystemInfo();
	[ObservableProperty] private string _proxyStatus = GetProxyInfo();

	private static string GetSystemInfo()
	{
		var sb = new StringBuilder();
		sb.AppendLine($"CPU: {SystemInfo.GetCpuName()}");
		sb.AppendLine($"GPU: {SystemInfo.GetGpuName()}");
		sb.AppendLine($"RAM: {SystemInfo.GetRamSizeInGb()} GB");
		sb.AppendLine($"系统版本: {SystemInfo.GetSystemVersion()}");
		sb.AppendLine($"系统架构: {SystemInfo.GetSystemArchitecture()}");
		sb.AppendLine($"系统语言: {SystemInfo.GetSystemLanguage()}");
		sb.AppendLine($"系统型号: {SystemInfo.GetSystemModel()}");
		sb.AppendLine($"系统制造商: {SystemInfo.GetSystemManufacturer()}");
		sb.AppendLine($"系统启动时间: {SystemInfo.GetSystemBootTime()}");
		sb.Append($"系统安装时间: {SystemInfo.GetSystemInstallTime()}");
		return sb.ToString();
	}

	private static string GetProxyInfo()
	{
		var proxyEnable = (int)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings", "ProxyEnable", 0);
		if (proxyEnable != 0)
			Growl.Warning("警告! 系统代理被开启 此电脑网络安全性极低!");
		return proxyEnable switch
		{
			0 => "代理状态: 禁用",
			1 => "代理状态: 启用"
		};
	}
}