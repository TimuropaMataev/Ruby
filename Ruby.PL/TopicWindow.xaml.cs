using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Ruby.PL;

public partial class TopicWindow : Window
{
    public TopicWindow()
    {
        InitializeComponent();
        List<string> styles = new() { "Light", "Dark", "Green", "Orange" };
        CBStyles.SelectionChanged += ChoiceStyle;
        CBStyles.ItemsSource = styles;
        CBStyles.SelectedItem = "Dark";
    }

    private void ChoiceStyle(object sender, SelectionChangedEventArgs e)
    {
        string? style = CBStyles.SelectedItem as string;
        var uri = new Uri(style + ".xaml", UriKind.Relative);
        ResourceDictionary? rd = Application.LoadComponent(uri)
            as ResourceDictionary;

        Application.Current.Resources.Clear();
        Application.Current.Resources.MergedDictionaries.Add(rd);
    }
}