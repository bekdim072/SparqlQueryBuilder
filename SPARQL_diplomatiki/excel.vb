
Imports ClosedXML.Excel
Module excel
    Public Sub OpenExcelFile(filePath As String)
        Try
            If IO.File.Exists(filePath) Then
                Process.Start("explorer.exe", filePath)
            Else
                MessageBox.Show("Το αρχείο Excel δεν βρέθηκε: " & filePath, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Σφάλμα κατά το άνοιγμα του Excel: " & ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CreateExcelFromSparqlResults(resultsList As List(Of Dictionary(Of String, String)), filePath As String)
        Try
            ' Δημιουργία ενός νέου αρχείου Excel
            Using workbook As New XLWorkbook()
                ' Δημιουργία νέου φύλλου εργασίας
                Dim worksheet As IXLWorksheet = workbook.Worksheets.Add("Sparql Results")

                ' Έλεγχος αν υπάρχουν αποτελέσματα
                If resultsList.Count > 0 Then
                    ' Λήψη των headers από το πρώτο dictionary
                    Dim headers As List(Of String) = resultsList(0).Keys.ToList()

                    ' Γράψιμο των headers στη γραμμή 1
                    For colIndex As Integer = 0 To headers.Count - 1
                        worksheet.Cell(1, colIndex + 1).Value = headers(colIndex)
                    Next

                    ' Γράψιμο των δεδομένων
                    For rowIndex As Integer = 0 To resultsList.Count - 1
                        Dim row As Dictionary(Of String, String) = resultsList(rowIndex)
                        For colIndex As Integer = 0 To headers.Count - 1
                            Dim header As String = headers(colIndex)
                            worksheet.Cell(rowIndex + 2, colIndex + 1).Value = row(header)
                        Next
                    Next
                Else
                    MessageBox.Show("Δεν υπάρχουν αποτελέσματα για εξαγωγή.", "Πληροφορία", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If

                ' Αποθήκευση του αρχείου Excel
                workbook.SaveAs(filePath)

                'MessageBox.Show("Το αρχείο Excel δημιουργήθηκε με επιτυχία: " & filePath, "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception
            MessageBox.Show("Σφάλμα κατά τη δημιουργία του Excel: " & ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
