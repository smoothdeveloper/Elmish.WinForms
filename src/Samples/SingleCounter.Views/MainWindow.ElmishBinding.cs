using System.ComponentModel;
using System.Windows.Forms;
using System.Windows.Input;

namespace SingleCounter.Views
{
	public partial class MainWindow : Form
	{
		private INotifyPropertyChanged viewModel => (INotifyPropertyChanged)Tag;
		void registerBindingOnLoad()
		{
			/*readonly*/
			var currentModel = ((dynamic)viewModel);
			void update(string name)
			{
				switch (name)
				{
					case "CounterValue":
						lblCount.Text = $"Count: {currentModel.CounterValue.ToString()}";
						break;
					case "StepSize":
						labelStepSize.Text = $"StepSize: {currentModel.StepSize.ToString()}";
						trackBar1.Value = currentModel.StepSize;
						break;
				}
			}
			/*readonly*/
			var inpc = (INotifyPropertyChanged)viewModel;
			inpc.PropertyChanged += (_, args) => update(args.PropertyName);
			/*readonly*/
			var incrementCmd = (ICommand)currentModel.Increment;
			/*readonly*/
			var decrementCmd = (ICommand)currentModel.Decrement;
			/*readonly*/
			var resetCmd = (ICommand)currentModel.Reset;
			this.btnMinus.Click += (_, __) => decrementCmd.Execute(currentModel);
			this.btnPlus.Click += (_, __) => incrementCmd.Execute(currentModel);
			this.btnReset.Click += (_, __) => resetCmd.Execute(currentModel);
			this.trackBar1.ValueChanged += (_, __) => { currentModel.StepSize = trackBar1.Value; };
			update("CounterValue");
			update("StepSize");
		}
	}
}
