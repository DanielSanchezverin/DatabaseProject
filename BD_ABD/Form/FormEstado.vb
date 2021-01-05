Public Class FormEstado
    Dim estado As New Estado
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbPais.Text = "" Or txtIdEstado.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdEstado.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            estado = New Estado(txtIdEstado.Text, estado.consultaIdPais(), cmbNombre.Text)
            estado.getSetIdEstado = txtIdEstado.Text
            estado.getSetIdPais = estado.consultaIdPais()
            estado.getSetNombre = cmbNombre.Text
            If estado.consultarID = False Then
                estado.insert()
            Else
                If estado.consultarRegistro Then
                    If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        estado.update()
                    End If
                Else
                    MessageBox.Show("Ya existe un registro con ese ID")
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cmbPais.Text = "" Or txtIdEstado.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdEstado.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            estado = New Estado(txtIdEstado.Text, estado.consultaIdPais(), cmbNombre.Text)
            estado.getSetIdEstado = txtIdEstado.Text
            estado.getSetIdPais = estado.consultaIdPais()
            estado.getSetNombre = cmbNombre.Text
            If estado.consultarRegistro Then
                estado.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If cmbPais.Text = "" Or txtIdEstado.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdEstado.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            estado = New Estado(txtIdEstado.Text, estado.consultaIdPais(), cmbNombre.Text)
            estado.getSetIdEstado = txtIdEstado.Text
            estado.getSetIdPais = estado.consultaIdPais()
            estado.getSetNombre = cmbNombre.Text
            If estado.consultarRegistro() Then
                If estado.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        estado.delete()
                    End If
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        cmbPais.Text = ""
        txtIdEstado.Text = ""
        cmbNombre.Text = ""
        poblarTodo()
    End Sub

    Private Sub FormEstado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblarTodo()
        estado.comboPais(cmbPais)
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtIdEstado.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbPais.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
        cmbNombre.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(2).Value
    End Sub
    Public Sub poblarTodo()
        estado.dataGirdView(dgv)
        estado.comboEstado(cmbNombre)
    End Sub

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        estado.comboEstado(cmbNombre)
    End Sub

    Private Sub txtIdEstado_TextChanged(sender As Object, e As EventArgs) Handles txtIdEstado.TextChanged
        If txtIdEstado.Text <> "" And IsNumeric(txtIdEstado.Text) = True Then
            estado.consultarID2()
        End If
    End Sub
End Class