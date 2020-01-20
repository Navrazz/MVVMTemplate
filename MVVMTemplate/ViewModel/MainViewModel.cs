using System;
using System.Collections.Generic;
using System.Windows.Input;
using MVVMTemplate.DataAccess;
using MVVMTemplate.DialogServiceTools;
using MVVMTemplate.Extensions;
using MVVMTemplate.Model;

namespace MVVMTemplate.ViewModel
{
    public class MainViewModel : ViewModelBase, IDialogRequestClose
    {
        private RelayCommand loadDataCommand;
        private RelayCommand closeCommand;

        private DataItemRepository dataItemRepository;

        public event EventHandler<DialogCloseRequestedEventArgs> RequestClose;


        public List<DataItem> DataItems { get => dataItemRepository.DataItems; }
        public DataItem SelectedItem { get; set; }

        public MainViewModel()
        {
            this.dataItemRepository = new DataItemRepository();
        }

        public ICommand LoadDataCommand
        {
            get
            {
                if (this.loadDataCommand == null)
                    this.loadDataCommand = new RelayCommand(x => OnRequestLoadData());

                return this.loadDataCommand;
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                if (this.closeCommand == null)
                    this.closeCommand = new RelayCommand(x => OnRequestClose());

                return this.closeCommand;
            }
        }

        private void OnRequestLoadData()
        {
            dataItemRepository.LoadData();
            OnPropertyChanged("DataItems");
        }

        private void OnRequestClose()
        {
            this.RequestClose?.Invoke(this, new DialogCloseRequestedEventArgs(false));
        }
    }
}
