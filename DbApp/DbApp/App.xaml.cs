using Microsoft.EntityFrameworkCore;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DbApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override async void OnStart()
        {
            // await TryPCLAsync();
            await TryEFCoreAsync();
            // Handle when your app starts
        }

        async Task TryEFCoreAsync()
        {
            using (AppDbContext db = new AppDbContext())
            {
                await db.Database.EnsureCreatedAsync();
                //await db.Database.MigrateAsync();
            }
        }

        async Task TryPCLAsync()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");
            var database = new SQLiteAsyncConnection(dbPath);
            await database.CreateTableAsync(typeof(Employee));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
