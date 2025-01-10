Module Globals

    Public newQueryForm As QueryForm

    Public endPointUrl As String = ""
    Public statements As List(Of String) = New List(Of String)
    Public classVars As New Dictionary(Of String, String)

    Public prefixSelect As String = "

SELECT "
    Public fromWhere As String = "
WHERE {
    "
    'Public fromWhere As String = "FROM <http://id.nlm.nih.gov/mesh>
    '    WHERE {
    '    "


    Public statementsString As String = ""
    Public closeQuery As String = "} "
    Public selectString As String = ""
    Public filterValue As String = ""
    Public groupByString As String = ""
    Public aggregateSelect As String = ""
End Module
