﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DAL;
using BL;

namespace SatisUI.UserControls
{
    /// <summary>
    /// Interaction logic for UCReport.xaml
    /// </summary>
    public partial class UCReport : UserControl
    {
        public UCReport()
        {
            InitializeComponent();
        }

        private void SatisRaporList()
        {
            ExceptionCatcher.ExceptionFinder(() => {
                DAL.DAL dal = new DAL.DAL();
                List<SatisEntity> raporList = dal.SatisRaporList();
                gridcontrol_report.ItemsSource = raporList;
            });          
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SatisRaporList();
        }
    }
}
