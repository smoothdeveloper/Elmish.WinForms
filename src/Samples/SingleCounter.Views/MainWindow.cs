using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace SingleCounter.Views
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			this.Load += (_, __) => registerBindingOnLoad();
		}
	}
}