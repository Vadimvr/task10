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
            string path = "";
            string name = "MyDatabase.sqlite";
            string fullPath = path + name;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MessageService message = new MessageService();
            StepsEditor stepsEditor = new StepsEditor(message);
            ModeEditor modeEditor = new ModeEditor(message);
            MainWindow view = new MainWindow(message);
            MainBL bl = new MainBL(message, fullPath);
            MainPresenter mainPresenter = new MainPresenter(view, stepsEditor, modeEditor, bl, message);

            Application.Run(view);
        }
    }
}
