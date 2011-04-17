using System.Windows.Forms;

namespace ViewWeaver.Interfaces
{
    public interface IModalView
    {
        DialogResult ShowDialog();
        void Close();
    }
}