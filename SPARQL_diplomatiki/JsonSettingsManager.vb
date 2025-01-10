Imports System.IO
Imports Newtonsoft.Json

Module JsonSettingsManager
    ' Ορισμός της διαδρομής του αρχείου ρυθμίσεων
    Private ReadOnly settingsFilePath As String = "settings.json"

    ''' <summary>
    ''' Ελέγχει αν το αρχείο ρυθμίσεων υπάρχει.
    ''' Αν δεν υπάρχει, το δημιουργεί με προεπιλεγμένες ρυθμίσεις.
    ''' </summary>
    Public Sub EnsureSettingsFileExists()
        If Not File.Exists(settingsFilePath) Then
            ' Δημιουργεί το αρχείο με προεπιλεγμένες ρυθμίσεις
            Dim defaultSettings As New Dictionary(Of String, Object) From {
            {"EndPoints", New List(Of String) From {"https://sparql.dblp.org/sparql", "https://dbpedia.org/sparql"}},
            {"DataSources", New List(Of String) From {"default", "DataSource2"}}
        }
            SaveSettings(defaultSettings)
        End If
    End Sub

    ''' <summary>
    ''' Φορτώνει τις ρυθμίσεις από το αρχείο JSON.
    ''' </summary>
    ''' <returns>Ένα Dictionary με τις ρυθμίσεις.</returns>
    Public Function LoadSettings() As Dictionary(Of String, Object)
        EnsureSettingsFileExists()
        Try
            ' Διαβάζει το περιεχόμενο του JSON αρχείου
            Dim json As String = File.ReadAllText(settingsFilePath)
            ' Μετατρέπει το JSON σε Dictionary
            Dim settings As Dictionary(Of String, Object) = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(json)
            Return settings
        Catch ex As Exception
            MessageBox.Show("Σφάλμα κατά τη φόρτωση των ρυθμίσεων: " & ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New Dictionary(Of String, Object)
        End Try
    End Function

    ''' <summary>
    ''' Αποθηκεύει τις ρυθμίσεις στο αρχείο JSON.
    ''' </summary>
    ''' <param name="settings">Ένα Dictionary με τις ρυθμίσεις που θα αποθηκευτούν.</param>
    Public Sub SaveSettings(settings As Dictionary(Of String, Object))
        Try
            ' Μετατρέπει το Dictionary σε JSON
            Dim json As String = JsonConvert.SerializeObject(settings, Formatting.Indented)
            ' Γράφει το JSON στο αρχείο
            File.WriteAllText(settingsFilePath, json)
        Catch ex As Exception
            MessageBox.Show("Σφάλμα κατά την αποθήκευση των ρυθμίσεων: " & ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Προσθέτει ένα στοιχείο σε μια λίστα στο αρχείο ρυθμίσεων.
    ''' </summary>
    ''' <param name="key">Το κλειδί της λίστας.</param>
    ''' <param name="value">Η τιμή που θα προστεθεί.</param>
    Public Sub AddToList(key As String, value As String)
        Dim settings As Dictionary(Of String, Object) = LoadSettings()

        If Not settings.ContainsKey(key) Then
            settings(key) = New List(Of String)()
        End If

        Dim list As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(settings(key).ToString())

        If Not list.Contains(value) Then
            list.Add(value)
        End If

        settings(key) = list
        SaveSettings(settings)

        Console.WriteLine($"Η τιμή '{value}' προστέθηκε στη λίστα '{key}'.")
    End Sub

    ''' <summary>
    ''' Αφαιρεί ένα στοιχείο από μια λίστα στο αρχείο ρυθμίσεων.
    ''' </summary>
    ''' <param name="key">Το κλειδί της λίστας.</param>
    ''' <param name="value">Η τιμή που θα αφαιρεθεί.</param>
    Public Sub RemoveFromList(key As String, value As String)
        Dim settings As Dictionary(Of String, Object) = LoadSettings()

        If settings.ContainsKey(key) Then
            Dim list As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(settings(key).ToString())

            If list.Contains(value) Then
                list.Remove(value)
                Console.WriteLine($"Η τιμή '{value}' αφαιρέθηκε από τη λίστα '{key}'.")
            Else
                Console.WriteLine($"Η τιμή '{value}' δεν βρέθηκε στη λίστα '{key}'.")
            End If

            settings(key) = list
            SaveSettings(settings)
        Else
            Console.WriteLine($"Η λίστα '{key}' δεν υπάρχει.")
        End If
    End Sub

    ''' <summary>
    ''' Φορτώνει μια λίστα από το αρχείο ρυθμίσεων και την προσθέτει σε ComboBox.
    ''' </summary>
    ''' <param name="cmb">Το ComboBox στο οποίο θα προστεθούν οι τιμές.</param>
    ''' <param name="key">Το κλειδί της λίστας.</param>
    Public Sub LoadComboBoxFromList(cmb As ComboBox, key As String)
        Dim settings As Dictionary(Of String, Object) = LoadSettings()
        cmb.SelectedItem = Nothing
        If settings.ContainsKey(key) Then
            Dim list As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(settings(key).ToString())
            cmb.Items.Clear()
            cmb.Items.AddRange(list.ToArray())
        End If
    End Sub

    ''' <summary>
    ''' Αποθηκεύει την επιλεγμένη τιμή από ένα ComboBox σε λίστα στο αρχείο ρυθμίσεων.
    ''' </summary>
    ''' <param name="cmb">Το ComboBox από το οποίο θα αποθηκευτεί η τιμή.</param>
    ''' <param name="key">Το κλειδί της λίστας.</param>
    Public Sub SaveSelectedComboBoxValue(cmb As ComboBox, key As String)
        If cmb.SelectedItem IsNot Nothing Then
            AddToList(key, cmb.SelectedItem.ToString())
        End If
    End Sub

    ''' <summary>
    ''' Επιστρέφει τη διαδρομή του αρχείου ρυθμίσεων.
    ''' </summary>
    ''' <returns>Η διαδρομή του αρχείου.</returns>
    Public Function GetSettingsFilePath() As String
        Return settingsFilePath
    End Function

    ''' <summary>
    ''' Ελέγχει αν ένα στοιχείο υπάρχει ήδη σε μια λίστα στο αρχείο ρυθμίσεων.
    ''' </summary>
    ''' <param name="listName">Το όνομα της λίστας.</param>
    ''' <param name="value">Η τιμή που θα ελεγχθεί.</param>
    ''' <returns>True αν υπάρχει, αλλιώς False.</returns>
    Public Function IsValueInList(listName As String, value As String) As Boolean
        Dim settings As Dictionary(Of String, Object) = LoadSettings()

        If settings.ContainsKey(listName) Then
            Dim list As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(settings(listName).ToString())
            Return list.Contains(value)
        End If

        Return False
    End Function

    ''' <summary>
    ''' Προσθέτει ένα στοιχείο σε μια λίστα στο αρχείο ρυθμίσεων.
    ''' </summary>
    ''' <param name="listName">Το όνομα της λίστας.</param>
    ''' <param name="value">Η τιμή που θα προστεθεί.</param>
    Public Sub AddToListGeneric(listName As String, value As String)
        Dim settings As Dictionary(Of String, Object) = LoadSettings()

        ' Αν η λίστα δεν υπάρχει, την αρχικοποιούμε
        If Not settings.ContainsKey(listName) Then
            settings(listName) = New List(Of String)()
        End If

        Dim list As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(settings(listName).ToString())

        ' Αν το στοιχείο δεν υπάρχει, το προσθέτουμε
        If Not list.Contains(value) Then
            list.Add(value)
        Else
            MessageBox.Show($"Το στοιχείο '{value}' υπάρχει ήδη στη λίστα '{listName}'.", "Πληροφορία", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        settings(listName) = list
        SaveSettings(settings)
        MessageBox.Show($"Το στοιχείο '{value}' προστέθηκε στη λίστα '{listName}'.", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Διαγράφει ένα στοιχείο από μια λίστα στο αρχείο ρυθμίσεων.
    ''' </summary>
    ''' <param name="listName">Το όνομα της λίστας.</param>
    ''' <param name="value">Η τιμή που θα διαγραφεί.</param>
    Public Sub RemoveFromListGeneric(listName As String, value As String)
        Dim settings As Dictionary(Of String, Object) = LoadSettings()

        If settings.ContainsKey(listName) Then
            Dim list As List(Of String) = JsonConvert.DeserializeObject(Of List(Of String))(settings(listName).ToString())

            ' Αν το στοιχείο υπάρχει, το αφαιρούμε
            If list.Contains(value) Then
                list.Remove(value)
                MessageBox.Show($"Το στοιχείο '{value}' αφαιρέθηκε από τη λίστα '{listName}'.", "Επιτυχία", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show($"Το στοιχείο '{value}' δεν βρέθηκε στη λίστα '{listName}'.", "Πληροφορία", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            settings(listName) = list
            SaveSettings(settings)
        Else
            MessageBox.Show($"Η λίστα '{listName}' δεν υπάρχει.", "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub




End Module
