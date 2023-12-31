﻿using MVVM_CalculatorApplication.Command;
using MVVM_CalculatorApplication.Model;
using System;
using System.Windows.Input;

namespace MVVM_CalculatorApplication.ViewModel
{
    class CalculatorViewModel
    {
        public CalculatorViewModel()
        {
            CalculatorModel = new CalculatorModel();
            ClearTextFields = new RelayCommand(HandleClearFields, HandleCanClearFields);
            PerformAddition = new RelayCommand(HadlePerformAddition, HandleCanPerformOperations);
            PerformSubtraction = new RelayCommand(HandleSubtraction, HandleCanPerformOperations);
            PerformMultiplication = new RelayCommand(HandleMultiplication, HandleCanPerformOperations);
            PerformDivision = new RelayCommand(HandleDivision, HandleCanPerformOperations);
        }

        private bool HandleCanClearFields(object arg)
        {
            if (!string.IsNullOrEmpty(CalculatorModel.FirstNumber) || !string.IsNullOrEmpty(CalculatorModel.SecondNumber))
            {
                return true;
            }

            return false;
        }

        private void HandleClearFields(object obj)
        {
            CalculatorModel.FirstNumber = string.Empty;
            CalculatorModel.SecondNumber = string.Empty;
        }

        public CalculatorModel CalculatorModel { get; set; }

        public ICommand ClearTextFields { get; set; }

        public ICommand PerformAddition { get; set; }

        public ICommand PerformSubtraction { get; set; }

        public ICommand PerformMultiplication { get; set; }

        public ICommand PerformDivision { get; set; }

        private bool HandleCanPerformOperations(object arg)
        {
            if (CalculatorModel.HasInputError || string.IsNullOrEmpty(CalculatorModel.FirstNumber) || string.IsNullOrEmpty(CalculatorModel.SecondNumber))
            {
                return false;
            }

            return true;
        }

        private void HadlePerformAddition(object obj)
        {
            CalculatorModel.Result = (Convert.ToDouble(CalculatorModel.FirstNumber) + Convert.ToDouble(CalculatorModel.SecondNumber));
        }

        private void HandleSubtraction(object obj)
        {
            CalculatorModel.Result = Convert.ToDouble(CalculatorModel.FirstNumber) - Convert.ToDouble(CalculatorModel.SecondNumber);
        }

        private void HandleMultiplication(object obj)
        {
            CalculatorModel.Result = Convert.ToDouble(CalculatorModel.FirstNumber) * Convert.ToDouble(CalculatorModel.SecondNumber);
        }

        private void HandleDivision(object obj)
        {
            CalculatorModel.Result = Math.Round((Convert.ToDouble(CalculatorModel.FirstNumber) / Convert.ToDouble(CalculatorModel.SecondNumber)), 2);
        }
    }
}
