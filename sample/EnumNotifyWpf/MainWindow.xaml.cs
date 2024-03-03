using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnumNotifyWpf;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
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
					Message.Shared.Language = EnumNotifyWpf.Language.Japanese;
					break;
				case "English":
					Message.Shared.Language = EnumNotifyWpf.Language.English;
					break;
			}
		}
	}
}