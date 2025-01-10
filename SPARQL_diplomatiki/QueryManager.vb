Imports System.IO

Module QueryManager
    ' Ορισμός του μονοπατιού του αρχείου
    Private ReadOnly filePath As String = "queries.txt"
    Private ReadOnly delimiter As String = "###" ' Ειδικός χαρακτήρας για διαχωρισμό

    ' Μέθοδος για έλεγχο αν το αρχείο υπάρχει, αλλιώς το δημιουργεί
    Private Sub EnsureFileExists()
        If Not File.Exists(filePath) Then
            File.Create(filePath).Dispose() ' Δημιουργία του αρχείου
        End If
    End Sub

    ' Μέθοδος για την προσθήκη ενός νέου ερωτήματος στο αρχείο
    Public Sub SaveQuery(query As String)
        EnsureFileExists()

        Dim existingQueries As List(Of String) = LoadQueries()
        ' Clean the query string
        Dim cleanedQuery As String = query.Trim().Replace(vbLf, "").Replace(vbCr, "").Replace(vbTab, "").Replace(" ", "")

        ' Clean existing queries and check for duplicates
        For Each existingQuery As String In existingQueries
            Dim cleanedExistingQuery As String = existingQuery.Trim().Replace(vbLf, "").Replace(vbCr, "").Replace(vbTab, "").Replace(" ", "")
            If cleanedExistingQuery.Equals(cleanedQuery, StringComparison.OrdinalIgnoreCase) Then
                Exit Sub ' Αν υπάρχει ήδη, δεν το αποθηκεύει
            End If
        Next

        Using writer As StreamWriter = New StreamWriter(filePath, append:=True)
            writer.WriteLine(query & delimiter) ' Αποθήκευση με ειδικό χαρακτήρα διαχωρισμού
        End Using
    End Sub

    ' Μέθοδος για την ανάγνωση όλων των ερωτημάτων από το αρχείο σε λίστα
    Public Function LoadQueries() As List(Of String)
        EnsureFileExists()
        Dim queries As New List(Of String)

        Using reader As StreamReader = New StreamReader(filePath)
            Dim content As String = reader.ReadToEnd()
            Dim lines As String() = content.Split(New String() {delimiter}, StringSplitOptions.RemoveEmptyEntries)
            queries.AddRange(lines)
        End Using

        Return queries
    End Function
End Module



