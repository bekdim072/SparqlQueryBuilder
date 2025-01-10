Public Class Results
    Public resultList As List(Of Dictionary(Of String, String))
    Dim filePath As String
    Private Sub Results_Load(sender As Object, e As EventArgs) Handles Me.Load
        rtxtQueryResults.Text = ConvertListToString(resultList)

        DataGridView1.DataSource = ConvertToDataTable(resultList)
        ' Ρυθμίσεις DataGridView
        With DataGridView1
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        End With

        ' Ορισμός διαδρομής για το Excel
        filePath = "SparqlResults.xlsx"

        ' Δημιουργία του Excel αρχείου
        CreateExcelFromSparqlResults(resultList, filePath)

    End Sub

    Public Function ConvertToDataTable(resultsList As List(Of Dictionary(Of String, String))) As DataTable
        Dim dataTable As New DataTable()

        ' Επιστροφή κενής DataTable αν δεν υπάρχουν αποτελέσματα
        If resultsList.Count = 0 Then
            Return dataTable
        End If

        ' Προσθήκη στηλών
        For Each column As String In resultsList(0).Keys
            dataTable.Columns.Add(column)
        Next

        ' Προσθήκη γραμμών
        For Each row As Dictionary(Of String, String) In resultsList
            Dim dataRow As DataRow = dataTable.NewRow()
            For Each column As String In row.Keys
                dataRow(column) = row(column)
            Next
            dataTable.Rows.Add(dataRow)
        Next

        Return dataTable
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        OpenExcelFile(filePath)
    End Sub
End Class