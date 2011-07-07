using System.Windows.Forms;

namespace ViewWeaver.Interfaces
{
    public interface IModalView : IView
    {
        DialogResult ShowDialog();
        void Close();
    }
}