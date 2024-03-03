using Avalonia.Data;
using Avalonia.Markup.Xaml;
using EnumNotifyGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumNotifyAvalonia;

public enum Language
{
	Japanese,
	English,
}

[EnumNotifyGenerator.EnumNotify(typeof(Language))]
public partial class Message : INotifyPropertyChanged
{
	private static Message? instance = null;
	public static Message Shared => instance ??= new Message();

	public event PropertyChangedEventHandler? PropertyChanged;

	[EnumValue(Language.Japanese, "成功")]
	[EnumValue(Language.English, "Success")]
	private string successMessage = string.Empty;

	[EnumValue(Language.Japanese, "エラー")]
	[EnumValue(Language.English, "Error")]
	private string errorMessage = string.Empty;

}

public class MessageBinding(string path) : MarkupExtension
{
	public string Path { get; set; } = path;

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		var binding = new Binding(Path, BindingMode.OneWay)
		{
			Source = Message.Shared,
		};
		return binding;
	}
}