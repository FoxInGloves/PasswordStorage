using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using PasswordStorage.ViewModels.Implementation;

namespace Notes_MAUI.Views;

public partial class DataPage : ContentPage
{
    public DataPage(DataPageViewModel dataPageViewModel)
    {
        InitializeComponent();
        
        BindingContext = dataPageViewModel;
    }
}