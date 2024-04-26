namespace SubStyle.Views;

using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

public partial class PackChoiceView : UserControl
{
    public static readonly StyledProperty<string> PromptProperty = AvaloniaProperty.Register<PackChoiceView, string>(nameof(Prompt), defaultValue: "yo", defaultBindingMode: BindingMode.TwoWay);

    public PackChoiceView()
    {
        this.InitializeComponent();
    }

    public string Prompt
    {
        get => this.GetValue(PromptProperty);
        set => this.SetValue(PromptProperty, value);
    }
}
