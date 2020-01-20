using System.Windows;
using MVVMTemplate.DialogServiceTools;

namespace MVVMTemplate.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window, IDialog
    {
        public MainView()
        {
            InitializeComponent();
        }
    }
}
