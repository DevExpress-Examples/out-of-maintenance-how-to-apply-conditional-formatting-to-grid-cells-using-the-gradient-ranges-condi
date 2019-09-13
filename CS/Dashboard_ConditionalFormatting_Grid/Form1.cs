using DevExpress.DashboardCommon;
using DevExpress.DashboardWin;
using System.Drawing;

namespace Grid_GradientRangeCondition {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            dashboardViewer1.CustomizeDashboardTitle += DashboardViewer1_CustomizeDashboardTitle;
            Dashboard dashboard = new Dashboard();
            dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboardViewer1.Dashboard = dashboard;
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items["gridDashboardItem1"];
            GridMeasureColumn extendedPrice = (GridMeasureColumn)grid.Columns[1];

            GridItemFormatRule rangeRule = new GridItemFormatRule(extendedPrice);
            FormatConditionRangeGradient rangeCondition = 
                new FormatConditionRangeGradient(FormatConditionRangeGradientPredefinedType.RedBlue);
            rangeRule.Condition = rangeCondition;

            grid.FormatRules.AddRange(rangeRule);
        }

        private void DashboardViewer1_CustomizeDashboardTitle(object sender, CustomizeDashboardTitleEventArgs e)
        {
            DashboardToolbarItem itemUpdate = new DashboardToolbarItem(
                (args) => UpdateFormatting())
            {
                Caption = "Update Formatting",
            };
            e.Items.Add(itemUpdate);
        }

        private void UpdateFormatting() {
            GridDashboardItem grid = (GridDashboardItem)dashboardViewer1.Dashboard.Items[0];
            GridItemFormatRule rangeRule = grid.FormatRules[0];

            FormatConditionRangeGradient rangeCondition = 
                (FormatConditionRangeGradient)rangeRule.Condition;
            rangeCondition.Generate(new AppearanceSettings(Color.PaleVioletRed), 
                                    new AppearanceSettings(Color.PaleGreen), 9);
            RangeInfo middleRange = rangeCondition.RangeSet[4];
            middleRange.StyleSettings = new AppearanceSettings(Color.SkyBlue);

            rangeRule.Condition = rangeCondition;
        }
    }
}
