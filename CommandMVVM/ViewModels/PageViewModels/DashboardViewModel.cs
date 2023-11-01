using CommandMVVM.Commands;
using CommandMVVM.Services;
using CommandMVVM.Views.Windows;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CommandMVVM.ViewModels.PageViewModels;

public class DashboardViewModel : NotificationService
{
    private Car? car1;
    public Car? car { get => car1; set { car1 = value; OnPropertyChanged(); } }

    public ObservableCollection<Car> Cars { get; set; }
    public ICommand AddCommand{ get; set; }
    public ICommand GetAllCommand{ get; set; }
    public ICommand EditCommand { get; set; }
    public ICommand CancelCommand { get; set; }
    public ICommand SaveCommand { get; set; }
    public ICommand RemoveCommand { get; set; }




    public DashboardViewModel()
    {
        Cars = new ObservableCollection<Car>()
        {
            new("Kia", "Optima", "2012"),
            new("Hyundai", "Elantra", "2014"),
            new("Audi", "Q7", "2023"),
        };

        car = new();


        AddCommand = new RelayCommand(AddCar, CanAddCar);
        GetAllCommand = new RelayCommand(GetAllCars, CanAllCars);
        EditCommand = new RelayCommand(EditCar, CanEditCar);
        CancelCommand = new RelayCommand(Cancel);
        SaveCommand = new RelayCommand(Save, CanSave);
        RemoveCommand = new RelayCommand(Remove, CanRemove);
    }

    public void Remove(object? parameter)    
    {
        Cars.RemoveAt((int)parameter);
    }

    public bool CanRemove(object? parameter)
    {
        return (int?)parameter != -1;
    }

    public void Cancel(object? paramter)
    {
        
        (paramter as Window)?.Close();
    }

    public void Save(object? paramter)
    {
        Cars.RemoveAt((int)paramter);
        Cars.Insert((int)paramter, car);

    }

    public bool CanSave(object? parameter)
    {
        return !string.IsNullOrEmpty(car?.Make) &&
           !string.IsNullOrEmpty(car?.Model) &&
           !string.IsNullOrEmpty(car?.Year);
    }

    public void EditCar(object? parameter)
    {
        car = Cars[(int)parameter];
        EditView? editView = new EditView();
        editView.saveButton.CommandParameter = parameter;
        editView!.DataContext = this;
        editView.ShowDialog();
        car = new();
    }

    public bool CanEditCar(object? parameter)
    {
        var param = (int)parameter;
        return param != -1;
    }

    public void GetAllCars(object? parameter)
    {
        var getAllView = new AllCarView();
        getAllView.DataContext = new GetAllCarViewModel(Cars);
        getAllView.ShowDialog();
    }

    public bool CanAllCars(object? parameter)
    {
        return Cars.Count >= 5;
    }


    public void AddCar(object? parameter)
    {
       
        Cars.Add(car!);
        car = new();
        
    }

    public bool CanAddCar(object? parameter)
    {
        return !string.IsNullOrEmpty(car?.Make) &&
               !string.IsNullOrEmpty(car?.Model) &&
               !string.IsNullOrEmpty(car?.Year);
    }
}
