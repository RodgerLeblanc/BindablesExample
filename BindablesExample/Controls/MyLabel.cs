using Bindables;
using System.Windows;
using System.Windows.Controls;

namespace BindablesExample
{
    public class MyLabel : Label
    {
        [DependencyProperty(
            Options = FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
            OnPropertyChanged = nameof(OnSomeDPChanged),
            OnCoerceValue = nameof(OnSomeDPCoerce))]
        public string SomeDP { get; set; }

        private static void OnSomeDPChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MyLabel).Content = e.NewValue;
        }

        private static object OnSomeDPCoerce(DependencyObject d, object value)
        {
            if (value is string someDP)
                return $"SomeDP = {someDP}";

            return value;
        }



        [AttachedProperty(OnPropertyChanged = nameof(OnSomeAPChanged))]
        public static string SomeAP { get; set; }

        private static void OnSomeAPChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement frameworkElement)
                frameworkElement.Tag = e.NewValue;
        }

        public static string GetSomeAP(DependencyObject obj)
        {
            throw new WillBeImplementedByBindablesException(); // Cette ligne est obligatoire
        }

        public static void SetSomeAP(DependencyObject obj, string value)
        {
            // Doit être vide.
        }
    }
}
