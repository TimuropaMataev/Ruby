using System.Windows;
using Ruby.DAL.Objects;

namespace Ruby.PL;

public partial class UserWindow : Window
{
    public User User { get; private set; }

    public UserWindow(User user)
    {
        InitializeComponent();
        User = user;
        DataContext = User;
    }

    private void CancelClick(object sender, RoutedEventArgs e)
        => Close();

    private void SaveClick(object sender, RoutedEventArgs e)
        => DialogResult = true;
}