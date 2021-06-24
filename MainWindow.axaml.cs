using NCalc;
using System;
using Avalonia;
using Avalonia.Media;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Interactivity;
using Avalonia.Layout;

namespace CalculatorChallenge
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public async void Button_OnClick(object? sender, RoutedEventArgs e)  {
            try {
                var expression = new Expression(this.FindControl<TextBox>("Input").Text);
                var output = expression.Evaluate();
                this.FindControl<TextBox>("Output").Text = output.ToString();
            } catch (Exception ex) {
                var window = new Window
                {
                    Width = 400,
                    Height = 200,
                    Background = new SolidColorBrush(new Color(255, 37, 37, 38)),
                    Content = new TextBlock
                    {
                        Text = "An exception occured: " + ex.Message,
                        FontFamily = "Cascadia Code, Segoe UI, Tahoma, Deja Vu, Times New Roman",
                        Foreground = new SolidColorBrush(new Color(255, 241, 241, 241)),
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center
                    },
                    WindowStartupLocation = WindowStartupLocation.CenterOwner
                };
                await window.ShowDialog((Window)VisualRoot);
            }
        }
    }
}