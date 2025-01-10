<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnQueryBuilder = New System.Windows.Forms.Button()
        Me.cmbEndPoints = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnQueryBuilder
        '
        Me.btnQueryBuilder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.btnQueryBuilder.Location = New System.Drawing.Point(244, 98)
        Me.btnQueryBuilder.Name = "btnQueryBuilder"
        Me.btnQueryBuilder.Size = New System.Drawing.Size(189, 38)
        Me.btnQueryBuilder.TabIndex = 0
        Me.btnQueryBuilder.Text = "Open QueryBuilder"
        Me.btnQueryBuilder.UseVisualStyleBackColor = True
        '
        'cmbEndPoints
        '
        Me.cmbEndPoints.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.cmbEndPoints.FormattingEnabled = True
        Me.cmbEndPoints.Items.AddRange(New Object() {"https://id.nlm.nih.gov/mesh/sparql", "https://sparql.dblp.org"})
        Me.cmbEndPoints.Location = New System.Drawing.Point(219, 64)
        Me.cmbEndPoints.Name = "cmbEndPoints"
        Me.cmbEndPoints.Size = New System.Drawing.Size(328, 28)
        Me.cmbEndPoints.TabIndex = 1
        Me.cmbEndPoints.Text = "https://id.nlm.nih.gov/mesh/sparql"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(64, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Επιλέξτε End Point"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.Location = New System.Drawing.Point(553, 64)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(31, 30)
        Me.btnSave.TabIndex = 3
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(590, 64)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(32, 30)
        Me.btnDelete.TabIndex = 4
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(715, 220)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEndPoints)
        Me.Controls.Add(Me.btnQueryBuilder)
        Me.Name = "Form1"
        Me.Text = "MainMenu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnQueryBuilder As Button
    Friend WithEvents cmbEndPoints As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnDelete As Button
End Class
