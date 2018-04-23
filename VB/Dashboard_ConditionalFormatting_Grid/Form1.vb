Imports DevExpress.DashboardCommon
Imports System.Drawing

Namespace Grid_GradientRangeCondition
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Public Sub New()
            InitializeComponent()
            Dim dashboard As New Dashboard()
            dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
            dashboardViewer1.Dashboard = dashboard
            Dim grid As GridDashboardItem =
                CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
            Dim extendedPrice As GridMeasureColumn = CType(grid.Columns(1), GridMeasureColumn)

            Dim rangeRule As New GridItemFormatRule(extendedPrice)
            Dim rangeCondition As _
                New FormatConditionRangeGradient(FormatConditionRangeGradientPredefinedType.RedBlue)
            rangeRule.Condition = rangeCondition

            grid.FormatRules.AddRange(rangeRule)
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles button1.Click
            Dim grid As GridDashboardItem =
                CType(dashboardViewer1.Dashboard.Items(0), GridDashboardItem)
            Dim rangeRule As GridItemFormatRule = grid.FormatRules(0)

            Dim rangeCondition As FormatConditionRangeGradient =
                CType(rangeRule.Condition, FormatConditionRangeGradient)
            rangeCondition.Generate(New AppearanceSettings(Color.PaleVioletRed), _
                                    New AppearanceSettings(Color.PaleGreen), 9)
            Dim middleRange As RangeInfo = rangeCondition.RangeSet(4)
            middleRange.StyleSettings = New AppearanceSettings(Color.SkyBlue)

            rangeRule.Condition = rangeCondition
        End Sub
    End Class
End Namespace
