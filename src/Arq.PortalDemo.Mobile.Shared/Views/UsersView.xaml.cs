﻿using Arq.PortalDemo.Models.Users;
using Arq.PortalDemo.ViewModels;
using Xamarin.Forms;

namespace Arq.PortalDemo.Views
{
    public partial class UsersView : ContentPage, IXamarinView
    {
        public UsersView()
        {
            InitializeComponent();
        }

        public async void ListView_OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            await ((UsersViewModel) BindingContext).LoadMoreUserIfNeedsAsync(e.Item as UserListModel);
        }
    }
}