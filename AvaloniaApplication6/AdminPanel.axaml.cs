using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication6.Models;
using Microsoft.EntityFrameworkCore;

namespace AvaloniaApplication6;

public partial class AdminPanel : Window
{
    public AdminPanel()
    {
        InitializeComponent();
        LoadUsers();
    }

    private void LoadUsers()
    {
        UsersData.ItemsSource = AuthAppCtx.DB.Users.ToList();
    }

    private void AddNewUser(object? sender, RoutedEventArgs e)
    {
        new AddUserPanel().Show();
        this.Close();
    }
}