<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CodeGen
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtOutputFolder = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.InputWithList = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtLegend = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.txtIWLPageTitle = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.txtIWLFileName = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.InputWithoutList = New System.Windows.Forms.TabPage()
        Me.NonJsonWS = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtDetailTName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHeaderTName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtParserName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rtbStringWS = New System.Windows.Forms.RichTextBox()
        Me.JSONWS = New System.Windows.Forms.TabPage()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtJsonKey = New System.Windows.Forms.TextBox()
        Me.rtbJsonString = New System.Windows.Forms.RichTextBox()
        Me.btnGenerate = New System.Windows.Forms.Button()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtJsonParserName = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtJsonObjectName = New System.Windows.Forms.TextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.InputWithList.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.NonJsonWS.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.JSONWS.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(442, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Author : Zaldy"
        '
        'txtOutputFolder
        '
        Me.txtOutputFolder.Location = New System.Drawing.Point(7, 17)
        Me.txtOutputFolder.Name = "txtOutputFolder"
        Me.txtOutputFolder.Size = New System.Drawing.Size(158, 20)
        Me.txtOutputFolder.TabIndex = 3
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnBrowse)
        Me.GroupBox3.Controls.Add(Me.txtOutputFolder)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 353)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(255, 52)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Output Folder"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(171, 15)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 4
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.TabControl1)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(515, 335)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Setting"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.InputWithList)
        Me.TabControl1.Controls.Add(Me.InputWithoutList)
        Me.TabControl1.Controls.Add(Me.NonJsonWS)
        Me.TabControl1.Controls.Add(Me.JSONWS)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(509, 316)
        Me.TabControl1.TabIndex = 0
        '
        'InputWithList
        '
        Me.InputWithList.Controls.Add(Me.GroupBox6)
        Me.InputWithList.Controls.Add(Me.GroupBox2)
        Me.InputWithList.Controls.Add(Me.txtIWLPageTitle)
        Me.InputWithList.Controls.Add(Me.GroupBox1)
        Me.InputWithList.Controls.Add(Me.txtIWLFileName)
        Me.InputWithList.Controls.Add(Me.Label7)
        Me.InputWithList.Controls.Add(Me.Label8)
        Me.InputWithList.Location = New System.Drawing.Point(4, 22)
        Me.InputWithList.Name = "InputWithList"
        Me.InputWithList.Size = New System.Drawing.Size(501, 290)
        Me.InputWithList.TabIndex = 2
        Me.InputWithList.Text = "Input With List"
        Me.InputWithList.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.TextBox1)
        Me.GroupBox6.Controls.Add(Me.txtLegend)
        Me.GroupBox6.Controls.Add(Me.Label5)
        Me.GroupBox6.Location = New System.Drawing.Point(332, 3)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(166, 284)
        Me.GroupBox6.TabIndex = 12
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Format Input"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 197)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Label6"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(7, 161)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(153, 34)
        Me.TextBox1.TabIndex = 2
        '
        'txtLegend
        '
        Me.txtLegend.Location = New System.Drawing.Point(7, 20)
        Me.txtLegend.Name = "txtLegend"
        Me.txtLegend.ReadOnly = True
        Me.txtLegend.Size = New System.Drawing.Size(153, 20)
        Me.txtLegend.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Label5"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RichTextBox2)
        Me.GroupBox2.Location = New System.Drawing.Point(172, 61)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(154, 226)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Grid Column"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(6, 19)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(142, 201)
        Me.RichTextBox2.TabIndex = 0
        Me.RichTextBox2.Text = "No" & Global.Microsoft.VisualBasic.ChrW(10) & "Kota" & Global.Microsoft.VisualBasic.ChrW(10) & "Tipe Faktur" & Global.Microsoft.VisualBasic.ChrW(10) & "Jenis Kendaraan" & Global.Microsoft.VisualBasic.ChrW(10) & "Target Maksimal Penyelesaian STNK" & Global.Microsoft.VisualBasic.ChrW(10) & "Status" & Global.Microsoft.VisualBasic.ChrW(10) & "crud" &
    ";veaid"
        '
        'txtIWLPageTitle
        '
        Me.txtIWLPageTitle.Location = New System.Drawing.Point(121, 35)
        Me.txtIWLPageTitle.Name = "txtIWLPageTitle"
        Me.txtIWLPageTitle.Size = New System.Drawing.Size(205, 20)
        Me.txtIWLPageTitle.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RichTextBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(161, 226)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Field List"
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(6, 19)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(149, 201)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = "Kota;txt" & Global.Microsoft.VisualBasic.ChrW(10) & "Tipe Faktur;ddl" & Global.Microsoft.VisualBasic.ChrW(10) & "Jenis Kendaraan;ddl" & Global.Microsoft.VisualBasic.ChrW(10) & "Target Maksimal Penyelesaian STNK;tx" &
    "t" & Global.Microsoft.VisualBasic.ChrW(10) & "Status;ddl" & Global.Microsoft.VisualBasic.ChrW(10) & "Baru;b" & Global.Microsoft.VisualBasic.ChrW(10) & "Simpan;b" & Global.Microsoft.VisualBasic.ChrW(10) & "Cari;b" & Global.Microsoft.VisualBasic.ChrW(10) & "Kembali;b"
        '
        'txtIWLFileName
        '
        Me.txtIWLFileName.Location = New System.Drawing.Point(121, 9)
        Me.txtIWLFileName.Name = "txtIWLFileName"
        Me.txtIWLFileName.Size = New System.Drawing.Size(205, 20)
        Me.txtIWLFileName.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(3, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Page Title"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(3, 12)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "File Name without Ext"
        '
        'InputWithoutList
        '
        Me.InputWithoutList.Location = New System.Drawing.Point(4, 22)
        Me.InputWithoutList.Name = "InputWithoutList"
        Me.InputWithoutList.Size = New System.Drawing.Size(501, 290)
        Me.InputWithoutList.TabIndex = 3
        Me.InputWithoutList.Text = "Input Without List"
        Me.InputWithoutList.UseVisualStyleBackColor = True
        '
        'NonJsonWS
        '
        Me.NonJsonWS.Controls.Add(Me.GroupBox5)
        Me.NonJsonWS.Location = New System.Drawing.Point(4, 22)
        Me.NonJsonWS.Name = "NonJsonWS"
        Me.NonJsonWS.Padding = New System.Windows.Forms.Padding(3)
        Me.NonJsonWS.Size = New System.Drawing.Size(501, 290)
        Me.NonJsonWS.TabIndex = 0
        Me.NonJsonWS.Text = "NonJson WS"
        Me.NonJsonWS.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtDetailTName)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Controls.Add(Me.txtHeaderTName)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.txtParserName)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.rtbStringWS)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(489, 278)
        Me.GroupBox5.TabIndex = 5
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "WS String"
        '
        'txtDetailTName
        '
        Me.txtDetailTName.Location = New System.Drawing.Point(115, 149)
        Me.txtDetailTName.Name = "txtDetailTName"
        Me.txtDetailTName.Size = New System.Drawing.Size(144, 20)
        Me.txtDetailTName.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 152)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Detail Table Name"
        '
        'txtHeaderTName
        '
        Me.txtHeaderTName.Location = New System.Drawing.Point(115, 123)
        Me.txtHeaderTName.Name = "txtHeaderTName"
        Me.txtHeaderTName.Size = New System.Drawing.Size(144, 20)
        Me.txtHeaderTName.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 126)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Header Table Name"
        '
        'txtParserName
        '
        Me.txtParserName.Location = New System.Drawing.Point(115, 97)
        Me.txtParserName.Name = "txtParserName"
        Me.txtParserName.Size = New System.Drawing.Size(144, 20)
        Me.txtParserName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Parser Filename"
        '
        'rtbStringWS
        '
        Me.rtbStringWS.Location = New System.Drawing.Point(6, 17)
        Me.rtbStringWS.Name = "rtbStringWS"
        Me.rtbStringWS.Size = New System.Drawing.Size(477, 74)
        Me.rtbStringWS.TabIndex = 0
        Me.rtbStringWS.Text = ""
        '
        'JSONWS
        '
        Me.JSONWS.Controls.Add(Me.GroupBox7)
        Me.JSONWS.Location = New System.Drawing.Point(4, 22)
        Me.JSONWS.Name = "JSONWS"
        Me.JSONWS.Size = New System.Drawing.Size(501, 290)
        Me.JSONWS.TabIndex = 1
        Me.JSONWS.Text = "JSON WS"
        Me.JSONWS.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 206)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "WS Key"
        '
        'txtJsonKey
        '
        Me.txtJsonKey.Location = New System.Drawing.Point(87, 203)
        Me.txtJsonKey.Name = "txtJsonKey"
        Me.txtJsonKey.Size = New System.Drawing.Size(100, 20)
        Me.txtJsonKey.TabIndex = 1
        '
        'rtbJsonString
        '
        Me.rtbJsonString.Location = New System.Drawing.Point(6, 19)
        Me.rtbJsonString.Name = "rtbJsonString"
        Me.rtbJsonString.Size = New System.Drawing.Size(482, 178)
        Me.rtbJsonString.TabIndex = 0
        Me.rtbJsonString.Text = ""
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(273, 353)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(155, 52)
        Me.btnGenerate.TabIndex = 6
        Me.btnGenerate.Text = "Generate"
        Me.btnGenerate.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(434, 353)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(90, 13)
        Me.LinkLabel1.TabIndex = 7
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Copy ASPX Code"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(434, 373)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(76, 13)
        Me.LinkLabel2.TabIndex = 8
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Copy VB Code"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(433, 392)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(79, 13)
        Me.LinkLabel3.TabIndex = 9
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "Save to Output"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 232)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Parser Name"
        '
        'txtJsonParserName
        '
        Me.txtJsonParserName.Location = New System.Drawing.Point(87, 229)
        Me.txtJsonParserName.Name = "txtJsonParserName"
        Me.txtJsonParserName.Size = New System.Drawing.Size(100, 20)
        Me.txtJsonParserName.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 258)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Object Name"
        '
        'txtJsonObjectName
        '
        Me.txtJsonObjectName.Location = New System.Drawing.Point(87, 255)
        Me.txtJsonObjectName.Name = "txtJsonObjectName"
        Me.txtJsonObjectName.Size = New System.Drawing.Size(100, 20)
        Me.txtJsonObjectName.TabIndex = 5
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.rtbJsonString)
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.txtJsonKey)
        Me.GroupBox7.Controls.Add(Me.txtJsonObjectName)
        Me.GroupBox7.Controls.Add(Me.Label9)
        Me.GroupBox7.Controls.Add(Me.Label10)
        Me.GroupBox7.Controls.Add(Me.txtJsonParserName)
        Me.GroupBox7.Location = New System.Drawing.Point(4, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(494, 283)
        Me.GroupBox7.TabIndex = 7
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "WS String"
        '
        'CodeGen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(540, 416)
        Me.Controls.Add(Me.LinkLabel3)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.btnGenerate)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "CodeGen"
        Me.Text = "DNet Scaffolder"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.InputWithList.ResumeLayout(False)
        Me.InputWithList.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.NonJsonWS.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.JSONWS.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents txtOutputFolder As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents NonJsonWS As TabPage
    Friend WithEvents rtbStringWS As RichTextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents btnGenerate As Button
    Friend WithEvents txtDetailTName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtHeaderTName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtParserName As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents InputWithList As TabPage
    Friend WithEvents JSONWS As TabPage
    Friend WithEvents InputWithoutList As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtIWLPageTitle As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtIWLFileName As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents txtLegend As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents Label9 As Label
    Friend WithEvents txtJsonKey As TextBox
    Friend WithEvents rtbJsonString As RichTextBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtJsonObjectName As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtJsonParserName As TextBox
End Class
