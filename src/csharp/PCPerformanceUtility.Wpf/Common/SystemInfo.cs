using System.Management;
using System;
using System.Linq;

namespace PCPerformanceUtility.Wpf.Common;

public static class SystemInfo
{
	private static T GetFirstPropertyValue<T>(ManagementObjectSearcher searcher, string propertyName)
	{
		return searcher.Get().OfType<ManagementObject>().FirstOrDefault()?[propertyName] is T value ? value : default;
	}

	public static string GetCpuName()
	{
		using var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor");
		return GetFirstPropertyValue<string>(searcher, "Name");
	}

	public static string GetGpuName()
	{
		using var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_VideoController");
		return GetFirstPropertyValue<string>(searcher, "Name");
	}

	// FIXME: Ram size not correct.
	public static double GetRamSizeInGb()
	{
		using var searcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory");
		var capacity = GetFirstPropertyValue<ulong>(searcher, "Capacity");
		return capacity / (1024d * 1024d * 1024d);
	}

	public static string GetSystemVersion()
	{
		using var searcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem");
		return GetFirstPropertyValue<string>(searcher, "Caption");
	}

	public static string GetSystemArchitecture()
	{
		using var searcher = new ManagementObjectSearcher("SELECT OSArchitecture FROM Win32_OperatingSystem");
		return GetFirstPropertyValue<string>(searcher, "OSArchitecture");
	}

	public static string GetSystemLanguage()
	{
		using var searcher = new ManagementObjectSearcher("SELECT OSLanguage FROM Win32_OperatingSystem");
		return GetFirstPropertyValue<string>(searcher, "OSLanguage");
	}

	// NOTE: This method returns DateTime.
	public static DateTime GetSystemBootTime()
	{
		using var searcher = new ManagementObjectSearcher("SELECT LastBootUpTime FROM Win32_OperatingSystem");
		var lastBootUpTime = GetFirstPropertyValue<string>(searcher, "LastBootUpTime");
		return ManagementDateTimeConverter.ToDateTime(lastBootUpTime);
	}


	// NOTE: This method returns DateTime.
	public static DateTime GetSystemInstallTime()
	{
		using var searcher = new ManagementObjectSearcher("SELECT InstallDate FROM Win32_OperatingSystem");
		var installDate = GetFirstPropertyValue<string>(searcher, "InstallDate");
		return ManagementDateTimeConverter.ToDateTime(installDate);
	}

	public static string GetSystemManufacturer()
	{
		using var searcher = new ManagementObjectSearcher("SELECT Manufacturer FROM Win32_ComputerSystem");
		return GetFirstPropertyValue<string>(searcher, "Manufacturer");
	}

	public static string GetSystemModel()
	{
		using var searcher = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem");
		return GetFirstPropertyValue<string>(searcher, "Model");
	}

	// FIXME: This method causes exception.
	public static string GetSystemSerialNumber()
	{
		using var searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_ComputerSystem");
		return GetFirstPropertyValue<string>(searcher, "SerialNumber");
	}
}