Public Class FormMateriaPorCarrera
    Dim materia As New MateriaPorCarrera
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbCarrera.Text = "" Or txtIdMateria.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdMateria.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            materia = New MateriaPorCarrera(txtIdMateria.Text, materia.consultaIdCarrera(), cmbNombre.Text)
            materia.getSetIdMateria = txtIdMateria.Text
            materia.getSetIdCarrera() = materia.consultaIdCarrera()
            materia.getSetNombre() = cmbNombre.Text
            If materia.consultarRegistro = False Then
                materia.insert()
            Else
                If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    materia.update()
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cmbCarrera.Text = "" Or txtIdMateria.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdMateria.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            materia = New MateriaPorCarrera(txtIdMateria.Text, materia.consultaIdCarrera(), cmbNombre.Text)
            materia.getSetIdMateria = txtIdMateria.Text
            materia.getSetIdCarrera() = materia.consultaIdCarrera()
            materia.getSetNombre() = cmbNombre.Text
            If materia.consultarRegistro Then
                materia.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If cmbCarrera.Text = "" Or txtIdMateria.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdMateria.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            materia = New MateriaPorCarrera(txtIdMateria.Text, materia.consultaIdCarrera(), cmbNombre.Text)
            materia.getSetIdMateria = txtIdMateria.Text
            materia.getSetIdCarrera() = materia.consultaIdCarrera()
            materia.getSetNombre() = cmbNombre.Text
            If materia.consultarRegistro() Then
                If materia.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        materia.delete()
                    End If
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbCarrera.Text = ""
        txtIdMateria.Text = ""
        cmbNombre.Text = ""
        poblarTodo()
    End Sub

    Private Sub FormMateriaPorCarrera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        materia.dataGirdView(dgv)
        materia.comboCarrera(cmbCarrera)
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtIdMateria.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbCarrera.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
        cmbNombre.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(2).Value
    End Sub
    Public Sub poblarTodo()
        materia.dataGirdView(dgv)
        materia.comboCarrera(cmbCarrera)
    End Sub

    Private Sub cmbCarrera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCarrera.SelectedIndexChanged
        materia.comboMateria(cmbNombre)
    End Sub

    Private Sub txtIdMateria_TextChanged(sender As Object, e As EventArgs) Handles txtIdMateria.TextChanged
        If txtIdMateria.Text <> "" And IsNumeric(txtIdMateria.Text) = True Then
            materia.consultarID()
        End If
    End Sub
End Class