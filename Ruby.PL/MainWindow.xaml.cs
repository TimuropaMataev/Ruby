using System.Collections.Generic;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Ruby.DAL.Data;
using Ruby.DAL.Objects;

namespace Ruby.PL;

public partial class MainWindow : Window
{
    private ApplicationContext _context = new();

    public MainWindow()
    {
        InitializeComponent();
        Loaded += MainWindow_Loaded;
        List<string> styles = new() { "Light", "Dark", "Green", "Orange" };
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        _context.Database.EnsureCreated();
        _context.Users.Load();
        DataContext = _context.Users.Local.ToObservableCollection();
    }

    private void AdditionClick(object sender, RoutedEventArgs e)
    {
        UserWindow window = new(new User());
        if (window.ShowDialog() == true)
        {
            User user = window.User;
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }

    private void EditClick(object sender, RoutedEventArgs e)
    {
        User? user = ListUsers.SelectedItem as User;
        if (user is null) return;

        UserWindow window = new(new User
        {
            Id = user.Id,
            Number = user.Number,
            Name = user.Name,
            Age = user.Age,
            Phone = user.Phone,
            Skill = user.Skill,
            Salary = user.Salary,
            DateTime = user.DateTime,
        });

        if (window.ShowDialog() == true)
        {
            user = _context.Users.Find(window.User.Id);
            if (user is not null)
            {
                user.Number = window.User.Number;
                user.Name = window.User.Name;
                user.Age = window.User.Age;
                user.Phone = window.User.Phone;
                user.Skill = window.User.Skill;
                user.Salary = window.User.Salary;
                user.DateTime = window.User.DateTime;
                _context.SaveChanges();
                ListUsers.Items.Refresh();
            }
        }
    }

    private void DeleteClick(object sender, RoutedEventArgs e)
    {
        User? user = ListUsers.SelectedItem as User;
        if (user is null) return;

        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    private void TopicClick(object sender, RoutedEventArgs e)
    {
        TopicWindow window = new();
        window.Show();
    }
}