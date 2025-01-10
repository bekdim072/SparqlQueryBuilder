Public Class QueryForm
    Private Sub QueryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = Me.Text + " EndPoint:" + endPointUrl

        JsonSettingsManager.LoadComboBoxFromList(cmbDataSources, "DataSources")


        ' Φόρτωση των αποθηκευμένων ερωτημάτων σε λίστα
        Dim savedQueries As List(Of String) = QueryManager.LoadQueries()

        ' Ενημέρωση του control (π.χ., ListBox)
        lstQueries.Items.Clear()
        lstQueries.Items.AddRange(savedQueries.ToArray())
    End Sub




    Private Sub btnLoadDataSource_Click(sender As Object, e As EventArgs) Handles btnLoadDataSource.Click
        treeView.Nodes.Clear()
        Dim query As String
        If cmbDataSources.Text <> "default" Then
            query =
            "SELECT DISTINCT ?graph
            WHERE    SERVICE <" + cmbDataSources.Text + "> { {
              GRAPH ?graph { ?s ?p ?o }
            }}"
        Else
            query =
            "SELECT DISTINCT ?graph
            WHERE {
              GRAPH ?graph { ?s ?p ?o }
            }"
        End If

        Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)
        For Each row As Dictionary(Of String, String) In results
            If row.ContainsKey("graph") Then
                Dim graph As String = row("graph")
                cmbGraphs.Items.Add(graph)
                'predicateList.Add(predicate)
            End If
        Next
        FillTreeViewFromGraphs(treeView, cmbGraphs)
    End Sub

    Private Sub treeView_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles treeView.BeforeExpand
        ' Φόρτωσε τους υποκόμβους δυναμικά
        Tree.LoadChildrenForNode(e.Node)
    End Sub

    Private Sub cmbGraphs_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbGraphs.SelectedIndexChanged

        cmbSubjects.SelectedItem = Nothing

        ' Παίρνουμε την επιλεγμένη κλάση
        Dim selectedGraph As String = cmbGraphs.Text

        If selectedGraph = Nothing Then Exit Sub
        'If searchCache.ContainsKey(selectedClass) Then
        '    ' Γέμισμα της λίστας από την cache
        '    cmbPredicates.Items.Clear()
        '    For Each predicate In searchCache(selectedClass)
        '        cmbPredicates.Items.Add(predicate)
        '    Next
        '    Return
        'End If

        Dim query As String =
            "SELECT DISTINCT ?type
            WHERE {
              GRAPH <" + selectedGraph + "> {  
                ?subject a ?type .                     
              }
            }
            ORDER BY ?type"


        ' Εκτέλεση του query και λήψη αποτελεσμάτων
        Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)
        cmbSubjects.Items.Clear()

        ' Προσθήκη των αποτελεσμάτων στη λίστα cmbPredicates
        For Each row As Dictionary(Of String, String) In results
            If row.ContainsKey("type") Then
                Dim subject As String = row("type")
                cmbSubjects.Items.Add(subject)

            End If
        Next




    End Sub

    Private Sub btnInsertClass_Click(sender As Object, e As EventArgs) Handles btnInsertClass.Click
        If cmbSubjects.SelectedItem = Nothing Then
            Exit Sub
        End If
        Dim statement As String
        Dim graphStatement = ""
        If cmbGraphs.Text <> "All" And cmbGraphs.Text.Trim <> "" Then graphStatement = "GRAPH <" + cmbGraphs.Text + ">"
        If statements.Count = 0 Then
            statement = graphStatement + " { ?c1 a <" + cmbSubjects.SelectedItem + "> . }"
            classVars.Add("?c1", cmbSubjects.SelectedItem)
            cmbSubjects.Items.Insert(0, "?c1")
            cmbSubjects.SelectedIndex = 0
            lstSelectList.Items.Add("?c1")
            statements.Add(statement)
        End If

        statementsString = ""
        For Each s In statements
            statementsString = statementsString + s + vbCrLf
        Next

        rtxtQuery.Text = prefixSelect + fromWhere + statementsString + closeQuery
    End Sub

    Private Sub btnInsertSelect_Click(sender As Object, e As EventArgs) Handles btnInsertSelect.Click
        Dim selectedItems As New List(Of String)

        ' Προσθήκη κάθε επιλεγμένου στοιχείου στη λίστα
        For Each selectedItem As String In lstSelectList.SelectedItems
            selectedItems.Add(selectedItem)
        Next

        ' Συγκέντρωση των τιμών σε μια συμβολοσειρά με κενό ανάμεσα
        selectString = String.Join(" ", selectedItems)

        'rtxtQuery.Text = prefixSelect + " " + selectString + " " + fromWhere + statementsString + closeQuery
        rtxtQuery.Text = prefixSelect + " " + selectString + " " + aggregateSelect + fromWhere + statementsString + closeQuery + groupByString
    End Sub

    Private Sub btnTestQuery_Click(sender As Object, e As EventArgs) Handles btnTestQuery.Click
        If Not rtxtQuery.Text.Split("SELECT")(1).Split("WHERE")(0).Contains("?") Then
            MsgBox("Δεν έχετε επιλέξει μεταβλητές στο Select")
            Exit Sub
        End If
        Dim f As New Results
        f.resultList = RunSparqlQuery(rtxtQuery.Text)

        ' Αποθήκευση του ερωτήματος στο αρχείο
        QueryManager.SaveQuery(rtxtQuery.Text)

        ' Φόρτωση των αποθηκευμένων ερωτημάτων σε λίστα
        Dim savedQueries As List(Of String) = QueryManager.LoadQueries()

        ' Ενημέρωση του control (π.χ., ListBox)
        lstQueries.Items.Clear()
        lstQueries.Items.AddRange(savedQueries.ToArray())

        If f.resultList.Count = 0 Then MsgBox("No results found")
        f.ShowDialog()

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click


        For i As Integer = cmbSubjects.Items.Count - 1 To 0 Step -1
            If cmbSubjects.Items(i).ToString.Contains("?") Then
                cmbSubjects.Items.RemoveAt(i)
            End If
        Next
        For i As Integer = cmbPredicates.Items.Count - 1 To 0 Step -1
            If cmbPredicates.Items(i).ToString.Contains("?") Then
                cmbPredicates.Items.RemoveAt(i)
            End If
        Next


        cmbSubjects.Text = ""
        cmbPredicates.Text = ""
        cmbObjects.Text = ""
        cmbGraphs.Text = ""

        statements.Clear()

        classVars.Clear()

        statementsString = ""
        groupByString = ""
        aggregateSelect = ""
        selectString = ""
        filterValue = ""
        lstSelectList.Items.Clear()
        rtxtQuery.Clear()
    End Sub

    Private Sub btnInsertWhere_Click(sender As Object, e As EventArgs) Handles btnInsertWhere.Click
        If cmbSubjects.Text = "" Or cmbPredicates.Text = "" Or cmbObjects.Text = "" Then
            MsgBox("Συμπληρώστε όλα τα πεδία")
            Exit Sub
        End If
        Dim statement As String
        If cmbPredicates.Text.ToString.StartsWith("?") Then
            'If Not predicateVars.ContainsKey(cmbPredicates.Text.ToString) Then predicateVars.Add(cmbPredicates.Text.ToString, "")
            If Not lstSelectList.Items.Contains(cmbPredicates.Text.ToString) Then lstSelectList.Items.Add(cmbPredicates.Text.ToString)
        End If
        'If cmbMainClasses.Text.ToString.StartsWith("?") Then
        '    If Not classVars.ContainsKey(cmbMainClasses.Text.ToString) Then classVars.Add(cmbMainClasses.Text.ToString, "")
        '    If Not lstSelectList.Items.Contains(cmbMainClasses.Text.ToString) Then lstSelectList.Items.Add(cmbMainClasses.Text.ToString)
        'End If
        If cmbObjects.Text.ToString.StartsWith("?") Then
            'If Not objectVars.ContainsKey(cmbObjects.Text.ToString) Then objectVars.Add(cmbObjects.Text.ToString, "")
            If Not lstSelectList.Items.Contains(cmbObjects.Text.ToString) Then lstSelectList.Items.Add(cmbObjects.Text.ToString)
        End If

        Dim graphStatement = ""
        If cmbGraphs.Text <> "All" And cmbGraphs.Text.Trim <> "" Then graphStatement = "GRAPH <" + cmbGraphs.Text + ">"
        If graphStatement <> "" Then
            statement = graphStatement + " { " + formatString(cmbSubjects.Text) + " " + formatString(cmbPredicates.Text) + " " + formatString(cmbObjects.Text) + ". }"
        Else
            statement = formatString(cmbSubjects.Text) + " " + formatString(cmbPredicates.Text) + " " + formatString(cmbObjects.Text) + "."
        End If





        statements.Add("    " + statement)
        'If Not txtFilter.Text = Nothing Then

        '    statements.Add(txtFilter.Text)
        'End If

        statementsString = ""
        For Each s In statements
            statementsString = statementsString + s + vbCrLf
        Next




        ' rtxtQuery.Text = prefixSelect + fromWhere + statementsString + closeQuery
        rtxtQuery.Text = prefixSelect + aggregateSelect + fromWhere + statementsString + closeQuery + groupByString
    End Sub
    Private Function formatString(inputString As String) As String
        If inputString.Contains("?") Then Return inputString
        Return "<" + inputString + ">"
    End Function

    Private Sub cmbSubjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubjects.SelectedIndexChanged
        cmbPredicates.SelectedItem = Nothing

        ' Παίρνουμε την επιλεγμένη κλάση
        Dim selectedSubject As String = cmbSubjects.Text

        If selectedSubject = Nothing Then Exit Sub
        'If searchCache.ContainsKey(selectedClass) Then
        '    ' Γέμισμα της λίστας από την cache
        '    cmbPredicates.Items.Clear()
        '    For Each predicate In searchCache(selectedClass)
        '        cmbPredicates.Items.Add(predicate)
        '    Next
        '    Return
        'End If
        If cmbSubjects.Text.Contains("?") Then
            selectedSubject = classVars("?c1")
        End If


        Dim graphText = "GRAPH <" + cmbGraphs.Text + "> "
        If cmbGraphs.Text = "All" Then graphText = ""
        Dim query As String =
            "
                        SELECT DISTINCT ?predicate
            WHERE { " + graphText + "   {
            
                ?s a <" + selectedSubject + ">  .
                ?s ?predicate ?o .
            }}
                 LIMIT 100
            
           "


        ' Εκτέλεση του query και λήψη αποτελεσμάτων
        Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)
        cmbPredicates.Items.Clear()

        ' Προσθήκη των αποτελεσμάτων στη λίστα cmbPredicates
        For Each row As Dictionary(Of String, String) In results
            If row.ContainsKey("predicate") Then
                Dim predicate As String = row("predicate")
                cmbPredicates.Items.Add(predicate)

            End If
        Next
    End Sub

    Private Sub btnSubjectsLoadAll_Click(sender As Object, e As EventArgs)
        cmbSubjects.SelectedItem = Nothing

        Dim query
        If cmbDataSources.Text <> "default" Then

            query =
                     "SELECT DISTINCT ?type
            WHERE  { SERVICE <" + cmbDataSources.Text + ">  {
              
                ?subject a ?type .                     
              
            }}
            ORDER BY ?type"
        Else
            query =
                     "SELECT DISTINCT ?type
            WHERE {
              
                ?subject a ?type .                     
              
            }
            ORDER BY ?type"
        End If
        ' Εκτέλεση του query και λήψη αποτελεσμάτων
        Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)
        cmbSubjects.Items.Clear()

        ' Προσθήκη των αποτελεσμάτων στη λίστα cmbPredicates
        For Each row As Dictionary(Of String, String) In results
            If row.ContainsKey("type") Then
                Dim subject As String = row("type")
                cmbSubjects.Items.Add(subject)

            End If
        Next


    End Sub

    Private Sub chkAllGraphs_CheckedChanged(sender As Object, e As EventArgs) Handles chkAllGraphs.CheckedChanged
        If chkAllGraphs.Checked Then
            cmbSubjects.SelectedItem = Nothing

            cmbGraphs.Text = "All"

            Dim query As String =
            "SELECT DISTINCT ?type
            WHERE {
               {  
                ?subject a ?type .                     
              }
            }
            ORDER BY ?type"


            ' Εκτέλεση του query και λήψη αποτελεσμάτων
            Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)
            cmbSubjects.Items.Clear()

            ' Προσθήκη των αποτελεσμάτων στη λίστα cmbPredicates
            For Each row As Dictionary(Of String, String) In results
                If row.ContainsKey("type") Then
                    Dim subject As String = row("type")
                    cmbSubjects.Items.Add(subject)

                End If
            Next

        Else
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(cmbDataSources.Text) Then
            MessageBox.Show("Παρακαλώ εισάγετε ή επιλέξτε ένα DataSource για αποθήκευση.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Έλεγχος αν το DataSource υπάρχει ήδη στη λίστα
        Dim exists As Boolean = JsonSettingsManager.IsValueInList("DataSources", cmbDataSources.Text)
        If exists Then
            MessageBox.Show($"Το DataSource '{cmbDataSources.Text}' υπάρχει ήδη στη λίστα.", "Πληροφορία", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            ' Προσθήκη του DataSource στη λίστα
            JsonSettingsManager.AddToListGeneric("DataSources", cmbDataSources.Text)

            ' Επαναφόρτωση της λίστας στο ComboBox
            JsonSettingsManager.LoadComboBoxFromList(cmbDataSources, "DataSources")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrWhiteSpace(cmbDataSources.Text) Then
            MessageBox.Show("Παρακαλώ επιλέξτε ένα DataSource για διαγραφή.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Αφαίρεση του DataSource από τη λίστα
        JsonSettingsManager.RemoveFromListGeneric("DataSources", cmbDataSources.Text)

        ' Επαναφόρτωση της λίστας στο ComboBox
        JsonSettingsManager.LoadComboBoxFromList(cmbDataSources, "DataSources")
    End Sub

    Private Sub btnGroupBy_Click(sender As Object, e As EventArgs) Handles btnGroupBy.Click
        Dim newGroupBy As New GroupBy

        For Each item As Object In lstSelectList.Items
            newGroupBy.lstGroupBy.Items.Add(item)
        Next




        newGroupBy.Show()
    End Sub

    Private Sub lstQueries_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstQueries.SelectedIndexChanged
        rtxtQuery.Text = lstQueries.Text
    End Sub

    Private Sub cmbPredicates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPredicates.SelectedIndexChanged
        cmbObjects.SelectedItem = Nothing

        ' Παίρνουμε την επιλεγμένη κλάση
        Dim selectedSubject As String = cmbSubjects.Text
        Dim selectedPredicate As String = cmbPredicates.Text

        If selectedSubject = Nothing Then Exit Sub
        If selectedPredicate = Nothing Then Exit Sub



        Dim graphText = "GRAPH <" + cmbGraphs.Text + "> "
        If cmbGraphs.Text = "All" Then graphText = ""
        Dim query As String =
            "
                        SELECT DISTINCT ?o
            WHERE { " + graphText + "   {
            
                ?s a <" + selectedSubject + ">  .
                ?s <" + selectedPredicate + "> ?o .
            }}
                 LIMIT 100
            
           "


        ' Εκτέλεση του query και λήψη αποτελεσμάτων
        Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)
        cmbObjects.Items.Clear()

        ' Προσθήκη των αποτελεσμάτων στη λίστα cmbPredicates
        For Each row As Dictionary(Of String, String) In results
            If row.ContainsKey("o") Then
                Dim o As String = row("o")
                cmbObjects.Items.Add(o)

            End If
        Next
    End Sub
End Class