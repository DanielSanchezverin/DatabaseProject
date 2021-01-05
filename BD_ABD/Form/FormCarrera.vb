Public Class FormCarrera
    Dim carrera As New Carrera
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtIdCarrera.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCarrera.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            carrera = New Carrera(txtIdCarrera.Text, cmbNombre.Text)
            carrera.getSetIdCarrera() = txtIdCarrera.Text
            carrera.getSetNombre() = cmbNombre.Text
            If carrera.consultarRegistro = False Then
                carrera.insert()
            Else
                If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    carrera.update()
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtIdCarrera.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCarrera.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            carrera = New Carrera(txtIdCarrera.Text, cmbNombre.Text)
            carrera.getSetIdCarrera() = txtIdCarrera.Text
            carrera.getSetNombre() = cmbNombre.Text
            If carrera.consultarRegistro Then
                carrera.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If txtIdCarrera.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCarrera.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            carrera = New Carrera(txtIdCarrera.Text, cmbNombre.Text)
            carrera.getSetIdCarrera() = txtIdCarrera.Text
            carrera.getSetNombre() = cmbNombre.Text
            If carrera.consultarRegistro() Then
                If carrera.validacion() = True And carrera.validacion2() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        carrera.delete()
                    End If
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIdCarrera.Text = ""
        cmbNombre.Text = ""
        poblarTodo()
    End Sub

    Private Sub FormCarrera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblarTodo()
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub
    Public Sub poblarTodo()
        carrera.dataGirdView(dgv)
        carrera.comboCarrera(cmbNombre)
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtIdCarrera.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbNombre.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
    End Sub

    Private Sub txtIdCarrera_TextChanged(sender As Object, e As EventArgs) Handles txtIdCarrera.TextChanged
        If txtIdCarrera.Text <> "" And IsNumeric(txtIdCarrera.Text) = True Then
            carrera.consultarID()
        End If
    End Sub
End Class