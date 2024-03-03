using Avalonia.Controls;

namespace EnumNotifyAvalonia;
public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}
	private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if (sender is ComboBox comboBox &&
			comboBox.SelectedItem is ComboBoxItem comboBoxItem &&
			comboBoxItem.Content is string comboBoxItemContent)
		{
			switch (comboBoxItemContent)
			{
				case "Japanese":
					Message.Shared.Language = EnumNotifyAvalonia.Language.Japanese;
					break;
				case "English":
					Message.Shared.Language = EnumNotifyAvalonia.Language.English;
					break;
			}
		}
	}
}