Imports Oracle.DataAccess.Client
Public Class FormMain
    Private Sub CalificacionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalificacionToolStripMenuItem.Click
        FormCalificacion.Show()
        Me.Hide()
    End Sub

    Private Sub CargaMateriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargaMateriaToolStripMenuItem.Click
        FormCargaMateria.Show()
        Me.Hide()
    End Sub

    Private Sub GeneroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneroToolStripMenuItem.Click
        FormGenero.Show()
        Me.Hide()
    End Sub

    Private Sub EstadoCivilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoCivilToolStripMenuItem.Click
        FormEstadoCivil.Show()
        Me.Hide()
    End Sub

    Private Sub PaisToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PaisToolStripMenuItem.Click
        FormPais.Show()
        Me.Hide()
    End Sub

    Private Sub EstadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EstadoToolStripMenuItem.Click
        FormEstado.Show()
        Me.Hide()
    End Sub

    Private Sub CiudadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CiudadToolStripMenuItem.Click
        FormCiudad.Show()
        Me.Hide()
    End Sub

    Private Sub ColoniaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColoniaToolStripMenuItem.Click
        FormColonia.Show()
        Me.Hide()
    End Sub

    Private Sub CarreraToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CarreraToolStripMenuItem1.Click
        FormCarrera.Show()
        Me.Hide()
    End Sub

    Private Sub MateriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MateriaToolStripMenuItem.Click
        FormMateriaPorCarrera.Show()
        Me.Hide()
    End Sub

    Private Sub AlumnoToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AlumnoToolStripMenuItem2.Click
        FormAlumno.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtUser.Text = "BD_ABD" And txtPass.Text = "12345" Then
            Button1.Hide()
            lblConectado.Show()
            lblIngresa.Visible = False
            lblIngresa.Text = "Bienvenido a su Administrador de base de datos!"
            lblIngresa.SetBounds(25, 40, 373, 36)
            txtUser.Visible = False
            txtPass.Visible = False
            lblUser.Visible = False
            lblPass.Visible = False
            Label1.Visible = True
            MenuStrip1.Visible = True
            dgv.Visible = True
            dataGirdView(dgv)
        Else
            MsgBox("Usuario o contraseña incorrecta!")
        End If
    End Sub
    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        dgv2.Visible = True
        Label2.Visible = True
        Label2.Text = "Vista Previa Tabla " & dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        dataGirdView2(dgv2)
    End Sub
    Public Function consultarTabla() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT TABLE_NAME FROM USER_TABLES"
        consultarTabla = conOracle.objetoDataAdapter(query)
    End Function
    Public Sub dataGirdView(ByVal dgv As DataGridView)
        dgv.DataSource = consultarTabla()
        dgv.Refresh()
        dgv.Columns.Item(0).Width = 150
    End Sub

    Public Function consultar() As Object
        Dim query As String
        Dim conOracle As New Oracle
        query = "SELECT * FROM " & dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        consultar = conOracle.objetoDataAdapter(query)
    End Function
    Public Sub dataGirdView2(ByVal dgv As DataGridView)
        dgv.DataSource = consultar()
        dgv.Refresh()
    End Sub
End Class
