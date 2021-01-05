Public Class FormCiudad
    Dim ciudad As New Ciudad
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If cmbPais.Text = "" Or cmbEstado.Text = "" Or txtIdCiudad.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCiudad.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            ciudad = New Ciudad(txtIdCiudad.Text, ciudad.consultaIdEstado(), cmbNombre.Text)
            ciudad.getSetIdCiudad = txtIdCiudad.Text
            ciudad.getSetIdEstado = ciudad.consultaIdEstado()
            ciudad.getSetNombre = cmbNombre.Text
            If ciudad.consultarID = False Then
                ciudad.insert()
            Else
                If ciudad.consultarRegistro Then
                    If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        ciudad.update()
                        MessageBox.Show("Se actualizo correctamente el registro!")
                    End If
                Else
                    MessageBox.Show("Ya existe un registro con ese ID")
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If cmbPais.Text = "" Or cmbEstado.Text = "" Or txtIdCiudad.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCiudad.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            ciudad = New Ciudad(txtIdCiudad.Text, ciudad.consultaIdEstado(), cmbNombre.Text)
            ciudad.getSetIdCiudad = txtIdCiudad.Text
            ciudad.getSetIdEstado = ciudad.consultaIdEstado()
            ciudad.getSetNombre = cmbNombre.Text
            If ciudad.consultarRegistro Then
                ciudad.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If cmbPais.Text = "" Or cmbEstado.Text = "" Or txtIdCiudad.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdCiudad.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            ciudad = New Ciudad(txtIdCiudad.Text, ciudad.consultaIdEstado(), cmbNombre.Text)
            ciudad.getSetIdCiudad = txtIdCiudad.Text
            ciudad.getSetIdEstado = ciudad.consultaIdEstado()
            ciudad.getSetNombre = cmbNombre.Text
            If ciudad.consultarRegistro() Then
                If ciudad.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        ciudad.delete()
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
        txtIdCiudad.Text = ""
        cmbNombre.Text = ""
        poblarTodo()
    End Sub

    Private Sub FormCiudad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ciudad.comboPais(cmbPais)
        poblarTodo()
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub

    Public Sub poblarTodo()
        ciudad.dataGirdView(dgv)
        ciudad.comboCiudad(cmbNombre)
    End Sub

    Private Sub cmbPais_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPais.SelectedIndexChanged
        ciudad.comboEstado(cmbEstado)
    End Sub

    Private Sub cmbEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEstado.SelectedIndexChanged
        ciudad.comboCiudad(cmbNombre)
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtIdCiudad.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbPais.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
        cmbEstado.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(2).Value
        cmbNombre.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(3).Value
    End Sub

    Private Sub txtIdCiudad_TextChanged(sender As Object, e As EventArgs) Handles txtIdCiudad.TextChanged
        If txtIdCiudad.Text <> "" And IsNumeric(txtIdCiudad.Text) Then
            ciudad.consultarID2()
        End If
    End Sub
End Class