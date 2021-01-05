Public Class FormColonia
    Dim colonia As New Colonia
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbPais.Text = "" Or cmbEstado.Text = "" Or cmbCiudad.Text = "" Or txtIdColonia.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdColonia.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            colonia = New Colonia(txtIdColonia.Text, colonia.consultaIdCiudad(), cmbNombre.Text)
            colonia.getSetIdColonia() = txtIdColonia.Text
            colonia.getSetIdCiudad() = colonia.consultaIdCiudad()
            colonia.getSetNombre() = cmbNombre.Text
            If colonia.consultarID = False Then
                colonia.insert()
            Else
                If colonia.consultarRegistro Then
                    If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        colonia.update()
                    End If
                Else
                    MessageBox.Show("Ya existe un registro con ese ID")
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cmbPais.Text = "" Or cmbEstado.Text = "" Or cmbCiudad.Text = "" Or txtIdColonia.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdColonia.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            colonia = New Colonia(txtIdColonia.Text, colonia.consultaIdCiudad(), cmbNombre.Text)
            colonia.getSetIdColonia() = txtIdColonia.Text
            colonia.getSetIdCiudad() = colonia.consultaIdCiudad()
            colonia.getSetNombre() = cmbNombre.Text
            If colonia.consultarRegistro Then
                colonia.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If cmbPais.Text = "" Or cmbEstado.Text = "" Or cmbCiudad.Text = "" Or txtIdColonia.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdColonia.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            colonia = New Colonia(txtIdColonia.Text, colonia.consultaIdCiudad(), cmbNombre.Text)
            colonia.getSetIdColonia() = txtIdColonia.Text
            colonia.getSetIdCiudad() = colonia.consultaIdCiudad()
            colonia.getSetNombre() = cmbNombre.Text
            If colonia.consultarRegistro() Then
                If colonia.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        colonia.delete()
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
        cmbEstado.Text = ""
        cmbCiudad.Text = ""
        txtIdColonia.Text = ""
        cmbNombre.Text = ""
        poblarTodo()
    End Sub

    Private Sub FormColonia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        colonia.dataGirdView(dgv)
        colonia.comboPais(cmbPais)
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub
    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        colonia.comboEstado(cmbEstado)
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        colonia.comboCiudad(cmbCiudad)
    End Sub

    Private Sub cmbCiudad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCiudad.SelectedIndexChanged
        colonia.comboColonia(cmbNombre)
    End Sub

    Public Sub poblarTodo()
        colonia.dataGirdView(dgv)
        colonia.comboColonia(cmbNombre)
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtIdColonia.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbPais.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
        cmbEstado.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(2).Value
        cmbCiudad.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(3).Value
        cmbNombre.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(4).Value
    End Sub

    Private Sub txtIdColonia_TextChanged(sender As Object, e As EventArgs) Handles txtIdColonia.TextChanged
        If txtIdColonia.Text <> "" And IsNumeric(txtIdColonia.Text) Then
            colonia.consultarID2()
        End If
    End Sub
End Class