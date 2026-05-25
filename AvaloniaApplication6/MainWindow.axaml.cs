using System;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication6.Models;


namespace AvaloniaApplication6;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        AuthAppCtx.DB = new AuthAppCtx();
    }

    private void AuthButton(object? sender, RoutedEventArgs e)
    {
        if (String.IsNullOrWhiteSpace(Login.Text) && String.IsNullOrWhiteSpace(Password.Text))
        {
            ErrText.Content = "Ошибка: Не все поля заполнены!";
            return;
        }
        
        User? tempUser = AuthAppCtx.DB.Users.Where(u=>u.Login == Login.Text && u.Password == Password.Text).FirstOrDefault();

        if (tempUser == null)
        {
            ErrText.Content = "Ошибка: Неверный логин или пароль!";
            return;
        }
        
        AuthAppCtx.User = tempUser;

        if (tempUser.Role == 0)
        {
            new UserPanel().Show();
            this.Close();
        } else if (tempUser.Role == 1)
        {
            new AdminPanel().Show();
            this.Close();
        }
    }
}