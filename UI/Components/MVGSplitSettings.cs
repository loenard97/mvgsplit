using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.UI.Components
{
    public partial class MVGSplitSettings : UserControl
    {
        public bool Display2Rows { get; set; }
        public LayoutMode Mode { get; set; }
        public enum ResetChanceAccuracy
        {
            ZeroDecimal,
            OneDecimal,
            TwoDecimal
        }
        public ResetChanceAccuracy Accuracy { get; set; }

        public MVGSplitSettings()
        {
            InitializeComponent();
            Display2Rows = false;
            Accuracy = ResetChanceAccuracy.ZeroDecimal;
        }

        private void ResetChanceSettings_Load(object sender, EventArgs e)
        {
            if (Mode == LayoutMode.Horizontal)
            {
                chkTwoRows.Enabled = false;
                chkTwoRows.DataBindings.Clear();
                chkTwoRows.Checked = true;
            }
            else
            {
                chkTwoRows.Enabled = true;
                chkTwoRows.DataBindings.Clear();
                chkTwoRows.DataBindings.Add("Checked", this, "Display2Rows", false, DataSourceUpdateMode.OnPropertyChanged);
            }
            rdoDecimalZero.Checked = Accuracy == ResetChanceAccuracy.ZeroDecimal;
            rdoDecimalOne.Checked = Accuracy == ResetChanceAccuracy.OneDecimal;
            rdoDecimalTwo.Checked = Accuracy == ResetChanceAccuracy.TwoDecimal;
        }

        private void UpdateAccuracy()
        {
            if (rdoDecimalZero.Checked)
                Accuracy = ResetChanceAccuracy.ZeroDecimal;
            else if (rdoDecimalOne.Checked)
                Accuracy = ResetChanceAccuracy.OneDecimal;
            else
                Accuracy = ResetChanceAccuracy.TwoDecimal;
        }

        private void rdoDecimalZero_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAccuracy();
        }

        private void rdoDecimalOne_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAccuracy();
        }

        private void rdoDecimalTwo_CheckedChanged(object sender, EventArgs e)
        {
            UpdateAccuracy();
        }

        private int CreateSettingsNode(XmlDocument document, XmlElement parent)
        {
            return SettingsHelper.CreateSetting(document, parent, "Version", "1.0") ^
                SettingsHelper.CreateSetting(document, parent, "Accuracy", Accuracy) ^
                SettingsHelper.CreateSetting(document, parent, "Display2Rows", Display2Rows);
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            var parent = document.CreateElement("Settings");
            CreateSettingsNode(document, parent);
            return parent;
        }

        public int GetSettingsHashCode()
        {
            return CreateSettingsNode(null, null);
        }

        public void SetSettings(XmlNode node)
        {
            var element = (XmlElement)node;
            Accuracy = SettingsHelper.ParseEnum<ResetChanceAccuracy>(element["Accuracy"]);
            Display2Rows = SettingsHelper.ParseBool(element["Display2Rows"], false);
        }
    }
}
