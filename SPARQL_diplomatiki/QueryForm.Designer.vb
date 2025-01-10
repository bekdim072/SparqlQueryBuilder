<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class QueryForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(QueryForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbSubjects = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbGraphs = New System.Windows.Forms.ComboBox()
        Me.btnInsertClass = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lstSelectList = New System.Windows.Forms.ListBox()
        Me.rtxtQuery = New System.Windows.Forms.RichTextBox()
        Me.btnTestQuery = New System.Windows.Forms.Button()
        Me.btnInsertSelect = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnInsertWhere = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbObjects = New System.Windows.Forms.ComboBox()
        Me.cmbPredicates = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkAllGraphs = New System.Windows.Forms.CheckBox()
        Me.treeView = New System.Windows.Forms.TreeView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbDataSources = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnLoadDataSource = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGroupBy = New System.Windows.Forms.Button()
        Me.lstQueries = New System.Windows.Forms.ComboBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Subjects"
        '
        'cmbSubjects
        '
        Me.cmbSubjects.FormattingEnabled = True
        Me.cmbSubjects.Location = New System.Drawing.Point(88, 47)
        Me.cmbSubjects.Name = "cmbSubjects"
        Me.cmbSubjects.Size = New System.Drawing.Size(515, 21)
        Me.cmbSubjects.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Graphs"
        '
        'cmbGraphs
        '
        Me.cmbGraphs.FormattingEnabled = True
        Me.cmbGraphs.Location = New System.Drawing.Point(88, 20)
        Me.cmbGraphs.Name = "cmbGraphs"
        Me.cmbGraphs.Size = New System.Drawing.Size(515, 21)
        Me.cmbGraphs.TabIndex = 12
        '
        'btnInsertClass
        '
        Me.btnInsertClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnInsertClass.Location = New System.Drawing.Point(609, 45)
        Me.btnInsertClass.Name = "btnInsertClass"
        Me.btnInsertClass.Size = New System.Drawing.Size(47, 23)
        Me.btnInsertClass.TabIndex = 15
        Me.btnInsertClass.Text = "+"
        Me.btnInsertClass.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(718, 339)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(50, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Variables"
        '
        'lstSelectList
        '
        Me.lstSelectList.FormattingEnabled = True
        Me.lstSelectList.Location = New System.Drawing.Point(721, 355)
        Me.lstSelectList.Name = "lstSelectList"
        Me.lstSelectList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.lstSelectList.Size = New System.Drawing.Size(56, 264)
        Me.lstSelectList.TabIndex = 16
        '
        'rtxtQuery
        '
        Me.rtxtQuery.Location = New System.Drawing.Point(25, 351)
        Me.rtxtQuery.Name = "rtxtQuery"
        Me.rtxtQuery.Size = New System.Drawing.Size(690, 261)
        Me.rtxtQuery.TabIndex = 18
        Me.rtxtQuery.Text = ""
        '
        'btnTestQuery
        '
        Me.btnTestQuery.Image = CType(resources.GetObject("btnTestQuery.Image"), System.Drawing.Image)
        Me.btnTestQuery.Location = New System.Drawing.Point(298, 628)
        Me.btnTestQuery.Name = "btnTestQuery"
        Me.btnTestQuery.Size = New System.Drawing.Size(53, 43)
        Me.btnTestQuery.TabIndex = 19
        Me.btnTestQuery.Tag = ""
        Me.btnTestQuery.UseVisualStyleBackColor = True
        '
        'btnInsertSelect
        '
        Me.btnInsertSelect.Location = New System.Drawing.Point(596, 322)
        Me.btnInsertSelect.Name = "btnInsertSelect"
        Me.btnInsertSelect.Size = New System.Drawing.Size(119, 23)
        Me.btnInsertSelect.TabIndex = 20
        Me.btnInsertSelect.Text = "Insert Select"
        Me.btnInsertSelect.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.Location = New System.Drawing.Point(357, 628)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(50, 43)
        Me.btnClear.TabIndex = 21
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnInsertWhere
        '
        Me.btnInsertWhere.Location = New System.Drawing.Point(25, 322)
        Me.btnInsertWhere.Name = "btnInsertWhere"
        Me.btnInsertWhere.Size = New System.Drawing.Size(119, 23)
        Me.btnInsertWhere.TabIndex = 22
        Me.btnInsertWhere.Text = "Insert Where"
        Me.btnInsertWhere.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Objects"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Predicates"
        '
        'cmbObjects
        '
        Me.cmbObjects.FormattingEnabled = True
        Me.cmbObjects.Location = New System.Drawing.Point(88, 104)
        Me.cmbObjects.Name = "cmbObjects"
        Me.cmbObjects.Size = New System.Drawing.Size(515, 21)
        Me.cmbObjects.TabIndex = 24
        '
        'cmbPredicates
        '
        Me.cmbPredicates.FormattingEnabled = True
        Me.cmbPredicates.Location = New System.Drawing.Point(88, 76)
        Me.cmbPredicates.Name = "cmbPredicates"
        Me.cmbPredicates.Size = New System.Drawing.Size(515, 21)
        Me.cmbPredicates.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.chkAllGraphs)
        Me.GroupBox1.Controls.Add(Me.cmbObjects)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbSubjects)
        Me.GroupBox1.Controls.Add(Me.cmbPredicates)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbGraphs)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnInsertClass)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 140)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(709, 152)
        Me.GroupBox1.TabIndex = 27
        Me.GroupBox1.TabStop = False
        '
        'chkAllGraphs
        '
        Me.chkAllGraphs.AutoSize = True
        Me.chkAllGraphs.Location = New System.Drawing.Point(612, 22)
        Me.chkAllGraphs.Name = "chkAllGraphs"
        Me.chkAllGraphs.Size = New System.Drawing.Size(37, 17)
        Me.chkAllGraphs.TabIndex = 27
        Me.chkAllGraphs.Text = "All"
        Me.chkAllGraphs.UseVisualStyleBackColor = True
        '
        'treeView
        '
        Me.treeView.BackColor = System.Drawing.SystemColors.Control
        Me.treeView.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.treeView.Location = New System.Drawing.Point(797, 78)
        Me.treeView.Name = "treeView"
        Me.treeView.Size = New System.Drawing.Size(671, 587)
        Me.treeView.TabIndex = 28
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbDataSources)
        Me.GroupBox2.Controls.Add(Me.btnDelete)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Controls.Add(Me.btnLoadDataSource)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(25, 65)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(582, 51)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "DataSource"
        '
        'cmbDataSources
        '
        Me.cmbDataSources.FormattingEnabled = True
        Me.cmbDataSources.Items.AddRange(New Object() {"default", "https://dbpedia.org/sparql"})
        Me.cmbDataSources.Location = New System.Drawing.Point(21, 19)
        Me.cmbDataSources.Name = "cmbDataSources"
        Me.cmbDataSources.Size = New System.Drawing.Size(361, 21)
        Me.cmbDataSources.TabIndex = 0
        Me.cmbDataSources.Text = "default"
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(425, 13)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(32, 30)
        Me.btnDelete.TabIndex = 29
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(388, 13)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(31, 30)
        Me.btnSave.TabIndex = 28
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnLoadDataSource
        '
        Me.btnLoadDataSource.Location = New System.Drawing.Point(463, 13)
        Me.btnLoadDataSource.Name = "btnLoadDataSource"
        Me.btnLoadDataSource.Size = New System.Drawing.Size(109, 30)
        Me.btnLoadDataSource.TabIndex = 1
        Me.btnLoadDataSource.Text = "Load Data Source"
        Me.btnLoadDataSource.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(39, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Data Source"
        '
        'btnGroupBy
        '
        Me.btnGroupBy.Location = New System.Drawing.Point(150, 322)
        Me.btnGroupBy.Name = "btnGroupBy"
        Me.btnGroupBy.Size = New System.Drawing.Size(119, 23)
        Me.btnGroupBy.TabIndex = 32
        Me.btnGroupBy.Text = "GroupBy"
        Me.btnGroupBy.UseVisualStyleBackColor = True
        '
        'lstQueries
        '
        Me.lstQueries.FormattingEnabled = True
        Me.lstQueries.Location = New System.Drawing.Point(21, 19)
        Me.lstQueries.Name = "lstQueries"
        Me.lstQueries.Size = New System.Drawing.Size(1396, 21)
        Me.lstQueries.TabIndex = 34
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lstQueries)
        Me.GroupBox3.Location = New System.Drawing.Point(25, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1434, 53)
        Me.GroupBox3.TabIndex = 35
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Saved Queries"
        '
        'QueryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.ClientSize = New System.Drawing.Size(1471, 678)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnGroupBy)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.treeView)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnInsertWhere)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnInsertSelect)
        Me.Controls.Add(Me.btnTestQuery)
        Me.Controls.Add(Me.rtxtQuery)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lstSelectList)
        Me.Name = "QueryForm"
        Me.Text = "QueryForm"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbSubjects As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbGraphs As ComboBox
    Friend WithEvents btnInsertClass As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lstSelectList As ListBox
    Friend WithEvents rtxtQuery As RichTextBox
    Friend WithEvents btnTestQuery As Button
    Friend WithEvents btnInsertSelect As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnInsertWhere As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbObjects As ComboBox
    Friend WithEvents cmbPredicates As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents treeView As TreeView
    Friend WithEvents chkAllGraphs As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbDataSources As ComboBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnLoadDataSource As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGroupBy As Button
    Friend WithEvents lstQueries As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
End Class
