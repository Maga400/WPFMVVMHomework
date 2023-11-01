using CommandMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandMVVM.ViewModels.PageViewModels
{
    public class EditCarViewModel: NotificationService
    {
        private Car car1;
        public Car car { get => car1; set { car1 = value; OnPropertyChanged(); } }

        public EditCarViewModel(Car car)
        {
            this.car = car;
        }
    }
}
