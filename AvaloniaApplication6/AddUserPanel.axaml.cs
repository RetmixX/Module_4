using System;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication6.Models;


namespace AvaloniaApplication6;

public partial class AddUserPanel : Window
{
    public AddUserPanel()
    {
        InitializeComponent();
    }

    private void AddNewUser(object? sender, RoutedEventArgs e)
    {
        if (String.IsNullOrWhiteSpace(Login.Text) && String.IsNullOrWhiteSpace(Password.Text)
                                                  && String.IsNullOrWhiteSpace(Role.Text))
        {
            ErrorMsg.Content = "Ошибка: Не все поля заполнены!";
            return;
        }

        bool checkRole = int.TryParse(Role.Text, out int data);
        if (!checkRole)
        {
            ErrorMsg.Content = "Ошибка: Роль от 0 до 1!";
            return;
        }
        
        User? tempUser = AuthAppCtx.DB.Users.Where(u=>u.Login == Login.Text).FirstOrDefault();

        if (tempUser != null)
        {
            ErrorMsg.Content = "Ошибка: Пользователь с таким логином уже существует!";
            return;
        }

        AuthAppCtx.DB.Users.Add(new User()
        {
            Login = Login.Text,
            Password = Password.Text,
            Role = data
        });
        AuthAppCtx.DB.SaveChanges();
        new AdminPanel().Show();
        this.Close();
    }
}