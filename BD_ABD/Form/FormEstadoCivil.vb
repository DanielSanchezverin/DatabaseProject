Public Class FormEstadoCivil
    Dim estadoCivil As New EstadoCivil
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtIdCivil.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCivil.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            estadoCivil = New EstadoCivil(txtIdCivil.Text, cmbNombre.Text)
            estadoCivil.getSetIdCivil = txtIdCivil.Text
            estadoCivil.getSetNombre = cmbNombre.Text
            If estadoCivil.consultarRegistro = False Then
                estadoCivil.insert()
            Else
                If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    estadoCivil.update()
                    MessageBox.Show("Se actualizo correctamente el registro!")
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtIdCivil.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCivil.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            estadoCivil = New EstadoCivil(txtIdCivil.Text, cmbNombre.Text)
            estadoCivil.getSetIdCivil = txtIdCivil.Text
            estadoCivil.getSetNombre = cmbNombre.Text
            If estadoCivil.consultarRegistro Then
                estadoCivil.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If txtIdCivil.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCivil.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            estadoCivil = New EstadoCivil(txtIdCivil.Text, cmbNombre.Text)
            estadoCivil.getSetIdCivil = txtIdCivil.Text
            estadoCivil.getSetNombre = cmbNombre.Text
            If estadoCivil.consultarRegistro() Then
                If estadoCivil.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        estadoCivil.delete()
                    End If
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIdCivil.Text = ""
        cmbNombre.Text = ""
        poblarTodo()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtIdCivil.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbNombre.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
    End Sub

    Public Sub poblarTodo()
        estadoCivil.dataGirdView(dgv)
        estadoCivil.comboEstadoCivil(cmbNombre)
    End Sub

    Private Sub FormEstadoCivil_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblarTodo()
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub

    Private Sub txtIdCivil_TextChanged(sender As Object, e As EventArgs) Handles txtIdCivil.TextChanged
        If txtIdCivil.Text <> "" And IsNumeric(txtIdCivil.Text) = True Then
            estadoCivil.consultarID()
        End If
    End Sub
End Class