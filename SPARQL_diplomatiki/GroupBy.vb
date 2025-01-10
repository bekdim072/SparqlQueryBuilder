Public Class GroupBy

    Private Sub lstGroupBy_DoubleClick(sender As Object, e As EventArgs) Handles lstGroupBy.DoubleClick
        txtGroupBy.Text = txtGroupBy.Text + " " + lstGroupBy.SelectedItem

    End Sub

    Private Sub GroupBy_Load(sender As Object, e As EventArgs) Handles Me.Load

        'For Each item As Object In QueryForm.lstSelectList.Items
        '    lstGroupBy.Items.Add(item)
        'Next


        cmbAggregate.Items.Clear()

        ' Προσδιορισμός των διαθέσιμων συναρτήσεων συγκέντρωσης
        Dim aggregateFunctions As String() = {"COUNT", "SUM", "AVG", "MIN", "MAX"}

        ' Για κάθε στοιχείο στη λίστα lstGroupBy, προσθέτει τις επιλογές στο ComboBox
        For Each variableName As String In lstGroupBy.Items
            For Each func As String In aggregateFunctions
                ' Δημιουργεί το κείμενο για την κάθε συνάρτηση με τη μορφή SPARQL
                Dim aggregateOption As String = $"({func}({variableName}) AS {variableName}{func})"

                cmbAggregate.Items.Add(aggregateOption)
            Next
        Next
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        groupByString = "  GROUP BY " + txtGroupBy.Text
        aggregateSelect = txtAggregates.Text + vbCrLf
        newQueryForm.rtxtQuery.Text = prefixSelect + aggregateSelect + fromWhere + statementsString + closeQuery + groupByString
        Me.Hide()
    End Sub

    Private Sub cmbAggregate_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbAggregate.SelectedValueChanged
        txtAggregates.Text = txtAggregates.Text + " " + cmbAggregate.Text

    End Sub
End Class