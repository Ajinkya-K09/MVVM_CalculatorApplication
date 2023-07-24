using MVVM_CalculatorApplication.Command;
using MVVM_CalculatorApplication.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_CalculatorApplication.ViewModel
{
    class CalculatorViewModel
    {
        public CalculatorViewModel()
        {
            CalculatorModel = new CalculatorModel();
            PerformArithmaticOperation = new RelayCommand(HadlePerformAddition, HandleCanPerformOperations);
        }

        public CalculatorModel CalculatorModel { get; set; }

        public ICommand PerformArithmaticOperation { get; set; }

        private bool HandleCanPerformOperations(object arg)
        {
            if (CalculatorModel.FirstNumber == 0 || CalculatorModel.SecondNumber == 0)
            {
                return false;
            }

            return true;
        }

        private void HadlePerformAddition(object obj)
        {
            CalculatorModel.Result = CalculatorModel.FirstNumber + CalculatorModel.SecondNumber;
        }
    }
}
