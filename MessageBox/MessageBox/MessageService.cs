namespace Presenter.MessageBox
{
    public class MessageService : IMessageService
    {
        public void Show(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
    }
}
