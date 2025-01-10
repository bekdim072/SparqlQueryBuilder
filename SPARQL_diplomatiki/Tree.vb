
Imports System.Drawing


Module Tree
    Public Sub FillTreeViewFromGraphs(treeView As TreeView, cmbGraphs As ComboBox)
        ' Καθαρισμός TreeView πριν την εισαγωγή νέων κόμβων
        treeView.Nodes.Clear()

        ' Προσθήκη ριζικών κόμβων από το cmbGraphs
        For Each item As String In cmbGraphs.Items
            Dim rootNode As TreeNode = treeView.Nodes.Add(item)

            ' Ορισμός του Tag ως "Graph" για τον κόμβο επιπέδου Graph
            rootNode.Tag = "Graph"

            ' Προσθήκη dummy υποκόμβου για να εμφανιστεί το "+"
            rootNode.Nodes.Add("dummy")
        Next
    End Sub

    Public Sub LoadChildrenForNode(node As TreeNode)
        ' Έλεγχος για το επίπεδο του κόμβου
        If node.Tag IsNot Nothing Then
            Select Case node.Tag.ToString()
                Case "Graph"
                    ' Φόρτωση Types
                    If node.Nodes.Count = 1 AndAlso node.Nodes(0).Text = "dummy" Then
                        node.Nodes.Clear()

                        Dim graph As String = node.Text
                        Dim query As String =
                            $"SELECT DISTINCT ?type
                        WHERE {{
                          GRAPH <{graph}> {{  
                            ?subject a ?type .                     
                          }}
                        }}
                        ORDER BY ?type"
                        Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)

                        For Each row As Dictionary(Of String, String) In results
                            If row.ContainsKey("type") Then
                                Dim type As String = row("type")
                                Dim typeNode As TreeNode = node.Nodes.Add(type)
                                typeNode.Tag = "Type" ' Επίπεδο: Type
                                typeNode.Nodes.Add("dummy") ' Dummy κόμβος για επόμενο επίπεδο
                            End If
                        Next
                    End If

                Case "Type"
                    ' Φόρτωση Predicates
                    If node.Nodes.Count = 1 AndAlso node.Nodes(0).Text = "dummy" Then
                        node.Nodes.Clear()

                        Dim graph As String = node.Parent.Text
                        Dim type As String = node.Text
                        Dim query As String =
                            $"SELECT DISTINCT ?predicate
                        WHERE {{
                          GRAPH <{graph}> {{  
                            ?subject a <{type}> ;
                                     ?predicate ?object .
                          }}
                        }}
                        ORDER BY ?predicate"
                        Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)

                        For Each row As Dictionary(Of String, String) In results
                            If row.ContainsKey("predicate") Then
                                Dim predicate As String = row("predicate")
                                Dim predicateNode As TreeNode = node.Nodes.Add(predicate)
                                predicateNode.Tag = "Predicate" ' Επίπεδο: Predicate
                                predicateNode.Nodes.Add("dummy") ' Dummy κόμβος για επόμενο επίπεδο
                            End If
                        Next
                    End If

                Case "Predicate"
                    ' Φόρτωση Objects
                    If node.Nodes.Count = 1 AndAlso node.Nodes(0).Text = "dummy" Then
                        node.Nodes.Clear()

                        Dim graph As String = node.Parent.Parent.Text
                        Dim type As String = node.Parent.Text
                        Dim predicate As String = node.Text
                        Dim query As String =
                            $"SELECT DISTINCT ?object
                        WHERE {{
                          GRAPH <{graph}> {{  
                            ?subject a <{type}> ;
                                     <{predicate}> ?object .
                          }}
                        }}
                        ORDER BY ?object"
                        Dim results As List(Of Dictionary(Of String, String)) = RunSparqlQuery(query)

                        For Each row As Dictionary(Of String, String) In results
                            If row.ContainsKey("object") Then
                                Dim [object] As String = row("object")
                                Dim objectNode As TreeNode = node.Nodes.Add([object])
                                objectNode.Tag = "Object" ' Επίπεδο: Object
                            End If
                        Next
                    End If
            End Select
        End If
    End Sub





End Module
