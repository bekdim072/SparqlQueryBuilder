Public Class Form1
    Private Sub btnQueryBuilder_Click(sender As Object, e As EventArgs) Handles btnQueryBuilder.Click

        If cmbEndPoints.Text = "" Then
            Exit Sub
        End If
        Dim endPointAvaible = IsEndpointAvailable(cmbEndPoints.Text)
        If Not endPointAvaible Then Exit Sub
        endPointUrl = cmbEndPoints.Text
        newQueryForm = New QueryForm
        newQueryForm.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        JsonSettingsManager.EnsureSettingsFileExists()

        ' Φορτώστε τη λίστα των EndPoints στο ComboBox
        JsonSettingsManager.LoadComboBoxFromList(cmbEndPoints, "EndPoints")


        ' Αν υπάρχει έστω ένα EndPoint, επιλέξτε το πρώτο
        If cmbEndPoints.Items.Count > 0 Then
            cmbEndPoints.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(cmbEndPoints.Text) Then
            MessageBox.Show("Παρακαλώ εισάγετε ή επιλέξτε ένα EndPoint για έλεγχο.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim exists As Boolean = JsonSettingsManager.IsValueInList("EndPoints", cmbEndPoints.Text)
        If exists Then
            MessageBox.Show($"Το EndPoint '{cmbEndPoints.Text}' υπάρχει στη λίστα.", "Πληροφορία", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            If String.IsNullOrWhiteSpace(cmbEndPoints.Text) Then
                MessageBox.Show("Παρακαλώ εισάγετε ένα EndPoint.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            JsonSettingsManager.AddToListGeneric("EndPoints", cmbEndPoints.Text)

            ' Επαναφόρτωση της λίστας στο ComboBox
            JsonSettingsManager.LoadComboBoxFromList(cmbEndPoints, "EndPoints")
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrWhiteSpace(cmbEndPoints.Text) Then
            MessageBox.Show("Παρακαλώ επιλέξτε ένα EndPoint για διαγραφή.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        JsonSettingsManager.RemoveFromListGeneric("EndPoints", cmbEndPoints.Text)

        ' Επαναφόρτωση της λίστας στο ComboBox
        JsonSettingsManager.LoadComboBoxFromList(cmbEndPoints, "EndPoints")
    End Sub
End Class
