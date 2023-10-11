using BL;
using Presenter;
using Presenter.MessageBox;
using System;
using System.Windows.Forms;

namespace View
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MessageService message = new MessageService();
            MainWindow view = new MainWindow(message);
            MainBL bl = new MainBL(message, @"E:\\test.db");
            MainPresenter mainPresenter = new MainPresenter(view, bl, message);
            
            Application.Run(view);
        }
    }
}
