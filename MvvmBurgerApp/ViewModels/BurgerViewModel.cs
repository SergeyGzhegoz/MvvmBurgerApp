﻿using MvvmBurgerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MvvmBurgerApp.ViewModels
{
    public class BurgerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        BurgerListViewModel lvm;
        public Burger Burger { get; set; }
        public List<TypeOfMeet> typeOfMeet { get; set; }
        public List<Additionally> additionally { get; set; }
        public ICommand UpCountCommand { protected set; get; }
        public ICommand DownCountCommand { protected set; get; }
        public ICommand UpACountCommand { protected set; get; }
        public ICommand DownACountCommand { protected set; get; }
        public ICommand UpBCountCommand { protected set; get; }
        public ICommand DownBCountCommand { protected set; get; }

        public BurgerViewModel()
        {
            UpCountCommand = new Command(UpCount);
            DownCountCommand = new Command(DownCount);
            UpACountCommand = new Command(UpACount);
            DownACountCommand = new Command(DownACount);
            UpBCountCommand = new Command(UpBCount);
            DownBCountCommand = new Command(DownBCount);
            Burger = new Burger();
            typeOfMeet = new List<TypeOfMeet>()
            {
                new TypeOfMeet("Говядина",12),
                new TypeOfMeet("Свинина",43),
                new TypeOfMeet("Курица",233)
            };
            Burger.Salat = new Additionally("Салат", 10, 0);
            Burger.Tomat = new Additionally("Томаты", 5, 0);
            //{
            //    new Additionally("Салат", 10, 12),
            //    new Additionally("Томаты", 5, 11),
            //    new Additionally("Лук", 5, 14),
            //    new Additionally("Огурцы", 15, 122)
            //};
        }

        TypeOfMeet selectedTypeOfMeet;
        public TypeOfMeet SelectedTypeOfMeet
        {
            get { return selectedTypeOfMeet; }
            set
            {
                if (selectedTypeOfMeet != value)
                {
                    Price = value.Price;
                    Title = value.Title;
                    RecalTotal();
                    selectedTypeOfMeet = value;
                    OnPropertyChanged("SelectedTypeOfMeet");
                }
            }
        }
        
        // Перерасчет итоговой стоимости.
        private void RecalTotal()
        {
            if (Count > 0)
            {
                Total = Count * Price + SalatCount * Burger.Salat.Price + TomatCount * Burger.Tomat.Price;
            }
        }

        private void UpCount()
        {
            Count += 1;
            RecalTotal();
        }

        private void DownCount()
        {
            if (Count > 0)
                Count -= 1;
            RecalTotal();
        }

        private void UpACount()
        {
            SalatCount += 1;
            RecalTotal();
        }

        private void DownACount()
        {
            if (SalatCount > 0)
                SalatCount -= 1;
            RecalTotal();
        }

        private void UpBCount()
        {
            TomatCount += 1;
            RecalTotal();
        }

        private void DownBCount()
        {
            if (TomatCount > 0)
                TomatCount -= 1;
            RecalTotal();
        }

        public BurgerListViewModel ListViewModel
        {
            get { return lvm; }
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public int SalatCount
        {
            get { return Burger.Salat.Count; }
            set
            {
                if (Burger.Salat.Count != value)
                {
                    Burger.Salat.Count = value;
                    OnPropertyChanged("SalatCount");
                }
            }
        }

        public int TomatCount
        {
            get { return Burger.Tomat.Count; }
            set
            {
                if (Burger.Tomat.Count != value)
                {
                    Burger.Tomat.Count = value;
                    OnPropertyChanged("TomatCount");
                }
            }
        }

        public int Total
        {
            get { return Burger.Total; }
            set
            {
                if (Burger.Total != value)
                {
                    Burger.Total = value;                    
                    OnPropertyChanged("Total");
                }
            }
        }

        public string Title
        {
            get { return Burger.Title; }
            set
            {
                if (Burger.Title != value)
                {   
                    Burger.Title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public int Count
        {
            get { return Burger.Count; }
            set
            {
                if (Burger.Count != value)
                {
                    Burger.Count = value;
                    RecalTotal();
                    OnPropertyChanged("Count");
                }
            }
        }

        public int Price
        {
            get { return Burger.Price; }
            set
            {
                if (Burger.Price != value)
                {
                    Burger.Price = value;                  
                    OnPropertyChanged("Price");
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
