[![NuGet version](https://badge.fury.io/nu/EnumNotifyGenerator.svg)](https://badge.fury.io/nu/EnumNotifyGenerator)

# EnumNotifyGenerator
EnumAttributeGenerator is a C# source generator that facilitates the automatic generation of attributed properties based on changes to specified enum values.   
When an enum value is modified, properties adorned with specific attributes are automatically updated.

## Usage

### Install by NuGet
PM> Install-Package [EnumNotifyGenerator](https://www.nuget.org/packages/EnumNotifyGenerator)

### Base Source
```csharp
using EnumNotifyGenerator;
public enum LanguageType
{
	Japanese,
	English,
}
[EnumNotify(typeof(LanguageType),"CurrentLanguage")]
public partial class Message : INotifyPropertyChanged
{
	private static Message? instance = null;
	public static Message Shared => instance ??= new Message();

	public event PropertyChangedEventHandler? PropertyChanged;

	[EnumValue(LanguageType.Japanese, "成功")]
	[EnumValue(LanguageType.English, "Success")]
	private string successMessage = string.Empty;

	[EnumValue(LanguageType.Japanese,"エラー")]
	[EnumValue(LanguageType.English, "Error")]
	private string errorMessage = string.Empty;

}

```

### Generated Source

```csharp
partial class Message
{
	private global::EnumNotifyWpf.LanguageType _CurrentLanguage;
	public global::EnumNotifyWpf.LanguageType CurrentLanguage
	{
		get
		{
			return _CurrentLanguage;
		}
		set
		{
			if(_CurrentLanguage == value)
			{
				return;
			}
			_CurrentLanguage = value;
			if(PropertyChanged != null)
			{
				PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("CurrentLanguage"));
				PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("SuccessMessage"));
				PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("ErrorMessage"));
			}
		}
	}

	public string SuccessMessage
	{
		get
		{
			switch(_CurrentLanguage)
			{
				case (global::EnumNotifyWpf.LanguageType)0:
					return @"成功";
				case (global::EnumNotifyWpf.LanguageType)1:
					return @"Success";
				default:
					break;
			}
			return successMessage;
		}
	}
	public string ErrorMessage
	{
		get
		{
			switch(_CurrentLanguage)
			{
				case (global::EnumNotifyWpf.LanguageType)0:
					return @"エラー";
				case (global::EnumNotifyWpf.LanguageType)1:
					return @"Error";
				default:
					break;
			}
			return errorMessage;
		}
	}
}
```
### Usage(WPF)
![image](https://github.com/EX-EXE/EnumNotifyGenerator/assets/114784289/0633a519-38e0-4a9f-8eba-fcb3337120f9)
#### MessageBinding.cs
```csharp
public class MessageBinding(string path) : MarkupExtension
{
	public string Path { get; set; } = path;

	public override object ProvideValue(IServiceProvider serviceProvider)
	{
		var binding =  new Binding(Path)
		{
			Source = Message.Shared,
			Mode = BindingMode.OneWay,
		};
		return binding.ProvideValue(serviceProvider);
	}
}
```

#### MainWindow.xaml
```xaml
<Window x:Class="EnumNotifyWpf.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:EnumNotifyWpf"
        mc:Ignorable="d"
        Title="MainWindow" Height="200" Width="300">

    <StackPanel>
        <ComboBox SelectionChanged="ComboBox_SelectionChanged">
            <ComboBoxItem>Japanese</ComboBoxItem>
            <ComboBoxItem>English</ComboBoxItem>
        </ComboBox>
        <TextBlock Text="{local:MessageBinding SuccessMessage}"></TextBlock>
        <TextBlock Text="{local:MessageBinding ErrorMessage}"></TextBlock>
    </StackPanel>
</Window>
```

#### MainWindow.xaml.cs
```csharp
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if(sender is ComboBox comboBox && 
			comboBox.SelectedItem is ComboBoxItem comboBoxItem &&
			comboBoxItem.Content is string comboBoxItemContent)
		{
			switch(comboBoxItemContent)
			{
				case "Japanese":
					Message.Shared.CurrentLanguage = LanguageType.Japanese;
					break;
				case "English":
					Message.Shared.CurrentLanguage = LanguageType.English;
					break;
			}
		}
	}
}
```


