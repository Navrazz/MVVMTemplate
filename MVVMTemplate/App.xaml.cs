using System.Windows;
using MVVMTemplate.DialogServiceTools;
using MVVMTemplate.View;
using MVVMTemplate.ViewModel;

namespace MVVMTemplate
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IDialogService dialogService = new DialogService();
            dialogService.Register<MainViewModel, MainView>();

            var mainViewModel = new MainViewModel();
            dialogService.ShowDialog(mainViewModel);
        }
    }
}
