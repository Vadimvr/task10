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
            StepsEditor stepsEditor = new StepsEditor(message);
            ModeEditor modeEditor = new ModeEditor(message);
            MainWindow view = new MainWindow(message, stepsEditor);
            MainBL bl = new MainBL(message, @"E:\\test.db");
            MainPresenter mainPresenter = new MainPresenter(view, stepsEditor, modeEditor, bl, message);

            Application.Run(view);
        }
    }
}
