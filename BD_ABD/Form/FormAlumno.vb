Public Class FormAlumno
    Dim alumno As New Alumno
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbNoControl.Text = "" Or cmbCarrera.Text = "" Or cmbEdoCivil.Text = "" Or cmbGenero.Text = "" Or cmbPais.Text = "" Or cmbEstado.Text = "" Or cmbCiudad.Text = "" Or
            cmbColonia.Text = "" Or txtNombre.Text = "" Or txtPaterno.Text = "" Or txtMaterno.Text = "" Or IsNumeric(cmbNoControl.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            alumno = New Alumno(cmbNoControl.Text, alumno.consultaIdCarrera(), alumno.consultaIdCivil(), alumno.consultaIdGenero(), alumno.consultaIdColonia(), txtNombre.Text,
                                txtPaterno.Text, txtMaterno.Text)
            alumno.getSetNoControl = cmbNoControl.Text
            alumno.getSetIdCarrera = alumno.consultaIdCarrera
            alumno.getSetIdCivil = alumno.consultaIdCivil
            alumno.getSetIdGenero = alumno.consultaIdGenero
            alumno.getSetIdColonia = alumno.consultaIdColonia
            alumno.getSetNombre = txtNombre.Text
            alumno.getSetPaterno = txtPaterno.Text
            alumno.getSetMaterno = txtMaterno.Text
            If alumno.consultarID = False Then
                alumno.insert()
            Else
                If alumno.consultarRegistro Then
                    If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        alumno.update()
                    End If
                Else
                    MessageBox.Show("Ya existe un registro con ese ID")
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cmbNoControl.Text = "" Or cmbCarrera.Text = "" Or cmbEdoCivil.Text = "" Or cmbGenero.Text = "" Or cmbPais.Text = "" Or cmbEstado.Text = "" Or cmbCiudad.Text = "" Or
            cmbColonia.Text = "" Or txtNombre.Text = "" Or txtPaterno.Text = "" Or txtMaterno.Text = "" Or IsNumeric(cmbNoControl.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            alumno = New Alumno(cmbNoControl.Text, alumno.consultaIdCarrera(), alumno.consultaIdCivil(), alumno.consultaIdGenero(), alumno.consultaIdColonia(), txtNombre.Text,
                                txtPaterno.Text, txtMaterno.Text)
            alumno.getSetNoControl = cmbNoControl.Text
            alumno.getSetIdCarrera = alumno.consultaIdCarrera
            alumno.getSetIdCivil = alumno.consultaIdCivil
            alumno.getSetIdGenero = alumno.consultaIdGenero
            alumno.getSetIdColonia = alumno.consultaIdColonia
            alumno.getSetNombre = txtNombre.Text
            alumno.getSetPaterno = txtPaterno.Text
            alumno.getSetMaterno = txtMaterno.Text
            If alumno.consultarRegistro Then
                alumno.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If cmbNoControl.Text = "" Or cmbCarrera.Text = "" Or cmbEdoCivil.Text = "" Or cmbGenero.Text = "" Or cmbPais.Text = "" Or cmbEstado.Text = "" Or cmbCiudad.Text = "" Or
            cmbColonia.Text = "" Or txtNombre.Text = "" Or txtPaterno.Text = "" Or txtMaterno.Text = "" Or IsNumeric(cmbNoControl.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            alumno = New Alumno(cmbNoControl.Text, alumno.consultaIdCarrera(), alumno.consultaIdCivil(), alumno.consultaIdGenero(), alumno.consultaIdColonia(), txtNombre.Text,
                                txtPaterno.Text, txtMaterno.Text)
            alumno.getSetNoControl = cmbNoControl.Text
            alumno.getSetIdCarrera = alumno.consultaIdCarrera
            alumno.getSetIdCivil = alumno.consultaIdCivil
            alumno.getSetIdGenero = alumno.consultaIdGenero
            alumno.getSetIdColonia = alumno.consultaIdColonia
            alumno.getSetNombre = txtNombre.Text
            alumno.getSetPaterno = txtPaterno.Text
            alumno.getSetMaterno = txtMaterno.Text
            If alumno.consultarRegistro() Then
                If alumno.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        alumno.delete()
                    End If
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbNoControl.Text = ""
        cmbCarrera.Text = ""
        cmbEdoCivil.Text = ""
        cmbGenero.Text = ""
        cmbPais.Text = ""
        cmbEstado.Text = ""
        cmbCiudad.Text = ""
        cmbColonia.Text = ""
        txtNombre.Text = ""
        txtPaterno.Text = ""
        txtMaterno.Text = ""
        poblarTodo()
    End Sub
    Public Sub poblarTodo()
        alumno.dataGirdView(dgv)
        alumno.comboNoControl(cmbNoControl)
    End Sub

    Private Sub FormAlumno_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblarTodo()
        alumno.comboCarrera(cmbCarrera)
        alumno.comboEstadoCivil(cmbEdoCivil)
        alumno.comboGenero(cmbGenero)
        alumno.comboPais(cmbPais)
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        alumno.comboEstado(cmbEstado)
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        alumno.comboCiudad(cmbCiudad)
    End Sub

    Private Sub cmbCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCiudad.SelectedIndexChanged
        alumno.comboColonia(cmbColonia)
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        cmbNoControl.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbCarrera.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
        cmbEdoCivil.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(2).Value
        cmbGenero.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(3).Value
        cmbColonia.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(4).Value
        cmbCiudad.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(5).Value
        cmbEstado.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(6).Value
        cmbPais.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(7).Value
        txtNombre.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(8).Value
        txtPaterno.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(9).Value
        txtMaterno.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(10).Value
    End Sub

    Private Sub cmbNoControl_TextChanged(sender As Object, e As EventArgs) Handles cmbNoControl.TextChanged
        If cmbNoControl.Text <> "" And IsNumeric(cmbNoControl.Text) Then
            alumno.consultarID2()
        End If
    End Sub
End Class