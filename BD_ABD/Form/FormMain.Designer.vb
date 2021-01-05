<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AlumnoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalificacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargaMateriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AlumnoToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MateriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CarreraToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GeneroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoCivilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PaisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CiudadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColoniaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lblConectado = New System.Windows.Forms.Label()
        Me.lblIngresa = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.dgv2 = New System.Windows.Forms.DataGridView()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.ControlDark
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 14.0!)
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AlumnoToolStripMenuItem, Me.OtrosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(782, 40)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'AlumnoToolStripMenuItem
        '
        Me.AlumnoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalificacionToolStripMenuItem, Me.CargaMateriaToolStripMenuItem, Me.AlumnoToolStripMenuItem2})
        Me.AlumnoToolStripMenuItem.Name = "AlumnoToolStripMenuItem"
        Me.AlumnoToolStripMenuItem.Size = New System.Drawing.Size(214, 36)
        Me.AlumnoToolStripMenuItem.Text = "Tablas principales"
        '
        'CalificacionToolStripMenuItem
        '
        Me.CalificacionToolStripMenuItem.Name = "CalificacionToolStripMenuItem"
        Me.CalificacionToolStripMenuItem.Size = New System.Drawing.Size(253, 36)
        Me.CalificacionToolStripMenuItem.Text = "Calificacion"
        '
        'CargaMateriaToolStripMenuItem
        '
        Me.CargaMateriaToolStripMenuItem.Name = "CargaMateriaToolStripMenuItem"
        Me.CargaMateriaToolStripMenuItem.Size = New System.Drawing.Size(253, 36)
        Me.CargaMateriaToolStripMenuItem.Text = "Carga Materia"
        '
        'AlumnoToolStripMenuItem2
        '
        Me.AlumnoToolStripMenuItem2.Name = "AlumnoToolStripMenuItem2"
        Me.AlumnoToolStripMenuItem2.Size = New System.Drawing.Size(253, 36)
        Me.AlumnoToolStripMenuItem2.Text = "Alumno"
        '
        'OtrosToolStripMenuItem
        '
        Me.OtrosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MateriaToolStripMenuItem, Me.CarreraToolStripMenuItem1, Me.GeneroToolStripMenuItem, Me.EstadoCivilToolStripMenuItem, Me.PaisToolStripMenuItem, Me.EstadoToolStripMenuItem, Me.CiudadToolStripMenuItem, Me.ColoniaToolStripMenuItem})
        Me.OtrosToolStripMenuItem.Name = "OtrosToolStripMenuItem"
        Me.OtrosToolStripMenuItem.Size = New System.Drawing.Size(224, 36)
        Me.OtrosToolStripMenuItem.Text = "Tablas secundarias"
        '
        'MateriaToolStripMenuItem
        '
        Me.MateriaToolStripMenuItem.Name = "MateriaToolStripMenuItem"
        Me.MateriaToolStripMenuItem.Size = New System.Drawing.Size(226, 36)
        Me.MateriaToolStripMenuItem.Text = "Materia"
        '
        'CarreraToolStripMenuItem1
        '
        Me.CarreraToolStripMenuItem1.Name = "CarreraToolStripMenuItem1"
        Me.CarreraToolStripMenuItem1.Size = New System.Drawing.Size(226, 36)
        Me.CarreraToolStripMenuItem1.Text = "Carrera"
        '
        'GeneroToolStripMenuItem
        '
        Me.GeneroToolStripMenuItem.Name = "GeneroToolStripMenuItem"
        Me.GeneroToolStripMenuItem.Size = New System.Drawing.Size(226, 36)
        Me.GeneroToolStripMenuItem.Text = "Genero"
        '
        'EstadoCivilToolStripMenuItem
        '
        Me.EstadoCivilToolStripMenuItem.Name = "EstadoCivilToolStripMenuItem"
        Me.EstadoCivilToolStripMenuItem.Size = New System.Drawing.Size(226, 36)
        Me.EstadoCivilToolStripMenuItem.Text = "Estado Civil"
        '
        'PaisToolStripMenuItem
        '
        Me.PaisToolStripMenuItem.Name = "PaisToolStripMenuItem"
        Me.PaisToolStripMenuItem.Size = New System.Drawing.Size(226, 36)
        Me.PaisToolStripMenuItem.Text = "Pais"
        '
        'EstadoToolStripMenuItem
        '
        Me.EstadoToolStripMenuItem.Name = "EstadoToolStripMenuItem"
        Me.EstadoToolStripMenuItem.Size = New System.Drawing.Size(226, 36)
        Me.EstadoToolStripMenuItem.Text = "Estado"
        '
        'CiudadToolStripMenuItem
        '
        Me.CiudadToolStripMenuItem.Name = "CiudadToolStripMenuItem"
        Me.CiudadToolStripMenuItem.Size = New System.Drawing.Size(226, 36)
        Me.CiudadToolStripMenuItem.Text = "Ciudad"
        '
        'ColoniaToolStripMenuItem
        '
        Me.ColoniaToolStripMenuItem.Name = "ColoniaToolStripMenuItem"
        Me.ColoniaToolStripMenuItem.Size = New System.Drawing.Size(226, 36)
        Me.ColoniaToolStripMenuItem.Text = "Colonia"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(651, 485)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 60)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Salir"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lblConectado
        '
        Me.lblConectado.AutoSize = True
        Me.lblConectado.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConectado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblConectado.Location = New System.Drawing.Point(302, 491)
        Me.lblConectado.Name = "lblConectado"
        Me.lblConectado.Size = New System.Drawing.Size(177, 36)
        Me.lblConectado.TabIndex = 15
        Me.lblConectado.Text = "Conectado!"
        Me.lblConectado.Visible = False
        '
        'lblIngresa
        '
        Me.lblIngresa.AutoSize = True
        Me.lblIngresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIngresa.Location = New System.Drawing.Point(214, 99)
        Me.lblIngresa.Name = "lblIngresa"
        Me.lblIngresa.Size = New System.Drawing.Size(373, 36)
        Me.lblIngresa.TabIndex = 14
        Me.lblIngresa.Text = "Ingresa a tu base de datos!"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(329, 422)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 60)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Conectar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblPass
        '
        Me.lblPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPass.Location = New System.Drawing.Point(253, 330)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(270, 34)
        Me.lblPass.TabIndex = 12
        Me.lblPass.Text = "Ingresa tu contraseña"
        Me.lblPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUser
        '
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(258, 239)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(265, 34)
        Me.lblUser.TabIndex = 11
        Me.lblUser.Text = "Ingresa tu usuario"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(258, 367)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(265, 34)
        Me.txtPass.TabIndex = 10
        '
        'txtUser
        '
        Me.txtUser.AutoCompleteCustomSource.AddRange(New String() {"BD_ABD"})
        Me.txtUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.txtUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(258, 276)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(265, 34)
        Me.txtUser.TabIndex = 9
        '
        'dgv2
        '
        Me.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv2.Location = New System.Drawing.Point(369, 76)
        Me.dgv2.Name = "dgv2"
        Me.dgv2.RowHeadersWidth = 51
        Me.dgv2.RowTemplate.Height = 24
        Me.dgv2.Size = New System.Drawing.Size(401, 406)
        Me.dgv2.TabIndex = 18
        Me.dgv2.Visible = False
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgv.Location = New System.Drawing.Point(8, 76)
        Me.dgv.Name = "dgv"
        Me.dgv.RowHeadersWidth = 51
        Me.dgv.RowTemplate.Height = 24
        Me.dgv.Size = New System.Drawing.Size(268, 406)
        Me.dgv.TabIndex = 19
        Me.dgv.Visible = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 23)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Tablas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(369, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(401, 23)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Vista Previa"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Label2.Visible = False
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 553)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.dgv2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.lblConectado)
        Me.Controls.Add(Me.lblIngresa)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Main"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgv2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AlumnoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CalificacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OtrosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CargaMateriaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AlumnoToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents GeneroToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoCivilToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PaisToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstadoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CiudadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColoniaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MateriaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CarreraToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Button2 As Button
    Friend WithEvents lblConectado As Label
    Friend WithEvents lblIngresa As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblPass As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents txtPass As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents dgv2 As DataGridView
    Friend WithEvents dgv As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
