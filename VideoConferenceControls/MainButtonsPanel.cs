using System.Windows.Forms;

namespace VideoConferenceControls
{
    public partial class MainButtonsPanel : UserControl
    {
        public MainButtonsPanel()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public Button Button1
        {
            get { return button1; }
            set { button1 = value; }
        }
        public Button Button2
        {
            get { return button2; }
            set { button2 = value; }
        }
        public Button Button3
        {
            get { return button3; }
            set { button3 = value; }
        }
        public Button Button4
        {
            get { return button4; }
            set { button4 = value; }
        }
        public Button Button5
        {
            get { return button5; }
            set { button5 = value; }
        }
        public Button Button6
        {
            get { return button6; }
            set { button6 = value; }
        }
    }
}
