using CommandMVVM.Commands;
using CommandMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CommandMVVM.ViewModels.PageViewModels
{
    public class EditCarViewModel: NotificationService
    {
        private Car? car1;
        public Car? car { get => car1; set { car1 = value; OnPropertyChanged(); } }

        private Car? referance;
        public Car? Referance { get => referance; set { referance = value; OnPropertyChanged(); } }
        public ICommand CancelCommand { get; set; }
        public ICommand SaveCommand { get; set; }   
        public EditCarViewModel(Car? car)
        {
            Referance = car;

            this.car = new Car();
            this.car.Make = car?.Make;
            this.car.Model = car?.Model;
            this.car.Year = car?.Year;

            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);
        }

        public void Cancel(object? paramter)
        {
            (paramter as Window)?.Close();
        }

        public void Save(object? paramter) 
        {
            Referance!.Make = car?.Make;
            Referance!.Model = car?.Model;
            Referance!.Year = car?.Year;
        }


    }


}
