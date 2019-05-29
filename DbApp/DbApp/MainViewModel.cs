using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DbApp
{
    public class MainViewModel : BindableObject
    {
        private ObservableCollection<Employee> employees;

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged();
            }
        }

        public Employee AddEmployee { get; set; }

        public Command AddCMD { get; set; }

        public MainViewModel()
        {
            AddEmployee = new Employee();
            AddCMD = new Command(async () => await AddAsync());
        }

        public async Task AddAsync()
        {
            using (var db = new AppDbContext())
            {
                await db.AddAsync(AddEmployee);
                await db.SaveChangesAsync();
            }
            await InitAsync();
        }

        public async Task InitAsync()
        {
            using (var db = new AppDbContext())
                Employees = new ObservableCollection<Employee>(await db.Employees.ToArrayAsync());
        }

    }
}
