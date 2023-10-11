namespace Presenter.MessageBox
{
    public interface IMessageService
    {
        void Show(string message);
    }

    public class MessageService : IMessageService
    {
        public void Show(string message)
        {
            System.Windows.Forms.MessageBox.Show(message);
        }
    }
}
