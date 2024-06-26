﻿using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HoteApp.Desktop
{
    /// <summary>
    /// Interaction logic for CheckInForm.xaml
    /// </summary>
    public partial class CheckInForm : Window
    {
        private BookingsFullModel _data = null;
        public CheckInForm(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        public IDatabaseData _db { get; }

        public void PopulateCheckInInfo(BookingsFullModel data)
        {
            _data = data;
            firstNameText.Text = _data.FirstName;
            lastNameText.Text = _data.LastName;
            titleText.Text = _data.RoomTypeTitle;
            roomNumberText.Text = _data.RoomNumber;
            totalCostText.Text = String.Format("0.C", _data.TotalCost);
        }

        private void CheckInUser_Click(object sender, RoutedEventArgs e)
        {
            _db.CheckInGuest(_data.ID);
            this.Close();
        }
    }
}
