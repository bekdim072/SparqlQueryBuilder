Imports VDS.RDF.Query
Imports System.Net.Http
Imports System.Text
Imports Newtonsoft.Json.Linq
Module General




    'Public Function RunSparqlQuery(query As String) As List(Of Dictionary(Of String, String))
    '    ' Δημιουργία του HttpClient
    '    Dim httpClient As New HttpClient()

    '    ' Ορισμός του HTTP αιτήματος
    '    Dim requestContent As New StringContent($"query={Uri.EscapeDataString(query)}", Encoding.UTF8, "application/x-www-form-urlencoded")

    '    ' Ρύθμιση του Accept header για JSON αποτελέσματα
    '    httpClient.DefaultRequestHeaders.Add("Accept", "application/sparql-results+json")

    '    ' Λίστα για την αποθήκευση των αποτελεσμάτων
    '    Dim resultsList As New List(Of Dictionary(Of String, String))

    '    Try
    '        ' Αποστολή του HTTP POST αιτήματος
    '        Dim response As HttpResponseMessage = httpClient.PostAsync(endPointUrl, requestContent).Result

    '        ' Βεβαίωση ότι η απάντηση είναι επιτυχής
    '        If response.IsSuccessStatusCode Then
    '            ' Ανάγνωση της απάντησης ως string
    '            Dim jsonResponse As String = response.Content.ReadAsStringAsync().Result

    '            ' Μετατροπή της JSON απάντησης σε αντικείμενο
    '            Dim sparqlResults As JObject = JObject.Parse(jsonResponse)

    '            ' Επεξεργασία των αποτελεσμάτων
    '            For Each result As JObject In sparqlResults("results")("bindings")
    '                Dim rowResult As New Dictionary(Of String, String)
    '                For Each variable As JProperty In result.Properties()
    '                    rowResult(variable.Name) = variable.Value("value").ToString()
    '                Next
    '                resultsList.Add(rowResult)
    '            Next
    '        Else
    '            Throw New Exception($"HTTP Request failed: {response.StatusCode} - {response.ReasonPhrase}")
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Σφάλμα στην εκτέλεση του ερωτήματος: " & ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    '    ' Επιστροφή της λίστας αποτελεσμάτων
    '    Return resultsList
    'End Function
    Public Function IsEndpointAvailable(endPointUrl As String) As Boolean
        Try
            ' Δημιουργούμε ένα απλό SPARQL query
            Dim query As String = "ASK { ?s ?p ?o }"

            ' Δημιουργία ενός SPARQL endpoint
            Dim endpoint As New SparqlRemoteEndpoint(New Uri(endPointUrl))

            ' Εκτέλεση του query
            Dim result As Boolean = endpoint.QueryWithResultSet(query).Count > 0

            ' Αν το query επιστρέψει αποτέλεσμα, το endpoint είναι διαθέσιμο
            Return True
        Catch ex As Exception
            ' Αν υπάρξει οποιοδήποτε σφάλμα, το endpoint δεν είναι διαθέσιμο
            MessageBox.Show("Σφάλμα κατά τον έλεγχο διαθεσιμότητας του endpoint: " & ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function



    Public Function RunSparqlQuery(query As String) As List(Of Dictionary(Of String, String))
        ' Ορίζουμε το URL του SPARQL endpoint


        ' Λίστα για την αποθήκευση των αποτελεσμάτων
        Dim resultsList As New List(Of Dictionary(Of String, String))

        Try
            ' Δημιουργία ενός SPARQL endpoint
            Dim endpoint As New SparqlRemoteEndpoint(New Uri(endPointUrl))


            ' Εκτέλεση του query και λήψη των αποτελεσμάτων
            Dim sparqlResults As SparqlResultSet = endpoint.QueryWithResultSet(query)

            ' Επεξεργασία των αποτελεσμάτων
            For Each result As SparqlResult In sparqlResults
                ' Δημιουργούμε ένα dictionary για κάθε γραμμή
                Dim rowResult As New Dictionary(Of String, String)

                ' Διατρέχουμε όλα τα variables του αποτελέσματος
                For Each variable As String In result.Variables
                    If result.HasValue(variable) Then
                        rowResult(variable) = result(variable).ToString()
                    End If
                Next

                ' Προσθέτουμε το dictionary στη λίστα
                resultsList.Add(rowResult)
            Next
        Catch ex As Exception
            MessageBox.Show("Σφάλμα στην εκτέλεση του ερωτήματος: " & query & " " & ex.Message, "Σφάλμα", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ' Επιστροφή των αποτελεσμάτων ως λίστα από dictionaries
        Return resultsList
    End Function
    Public Function ConvertListToString(data As List(Of Dictionary(Of String, String))) As String
        Dim result As New List(Of String)

        ' Διατρέχουμε κάθε dictionary στη λίστα
        For Each dict As Dictionary(Of String, String) In data
            ' Μετατρέπουμε το κάθε key-value ζεύγος σε συμβολοσειρά "key: value"
            Dim dictItems As New List(Of String)
            For Each kvp As KeyValuePair(Of String, String) In dict
                dictItems.Add($"{kvp.Key}: {kvp.Value}")
            Next

            ' Συνδυάζουμε τα key-value ζεύγη κάθε dictionary σε μια γραμμή και προσθέτουμε στη συνολική λίστα
            result.Add(String.Join(", ", dictItems))
        Next

        ' Επιστρέφουμε όλες τις γραμμές ενωμένες με νέα γραμμή για κάθε dictionary
        Return String.Join(Environment.NewLine, result)
    End Function
End Module
