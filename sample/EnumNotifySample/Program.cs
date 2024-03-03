namespace EnumNotifySample;

using EnumNotifyGenerator;
using System.ComponentModel;

public enum NotifyType
{
	A,
	B,
	C
}
public enum NotifyType2
{
	A,
	B,
	C
}
public enum NotifyType3
{
	A,
	B,
	C
}
public enum NotifyType4
{
	A,
	B,
	C
}

public enum LanguageType
{
	Japanese,
	English,
}

[EnumNotify(typeof(LanguageType), "Type")]
public partial class Message
{
	private static Message instance = new Message();
	public static Message Instance => instance;


	[EnumValue(LanguageType.Japanese, "エラー")]
	[EnumValue(LanguageType.English, "Error")]
	private string error = $"Unknown({nameof(error)})";

}


[EnumNotify(typeof(NotifyType))]
[EnumNotify(typeof(NotifyType2))]
[EnumNotify(typeof(NotifyType3), "type")]
[EnumNotify(typeof(NotifyType4), nameof(NotifyType3))]
public partial class Test : INotifyPropertyChanged
{
	private static Test instance = new Test();
	public static Test Instance => instance;

	[EnumValue(NotifyType.A, "aaa")]
	public string aaa = "";

	[EnumValue(NotifyType.A, -100)]
	[EnumValue(NotifyType.B, -200)]
	public int b = 0;


	[EnumValue(NotifyType.A, -100L)]
	[EnumValue(NotifyType.C, -100L)]
	[EnumValue(NotifyType.B, -200L)]
	public long c;

	[EnumValue(NotifyType.A, 'c')]
	[EnumValue(NotifyType.B, 'd')]
	[EnumValue(NotifyType.C, 'a')]
	public char d;

	[EnumValue(NotifyType.A, $"c\nc" +
		$"aa" + @"aa" + nameof(d))]
	public string bbb = "";

	public event PropertyChangedEventHandler? PropertyChanged;
}

internal class Program
{
	static void Main(string[] args)
	{
		Message.Instance.Type = LanguageType.Japanese;
		var err = Message.Instance.Error;
		Message.Instance.Type = LanguageType.English;
		var err2 = Message.Instance.Error;
		Message.Instance.Type = (LanguageType)(-1);
		var err3 = Message.Instance.Error;

		Console.WriteLine("Hello, World!");
	}
}
