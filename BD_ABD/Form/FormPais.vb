Public Class FormPais
    Dim pais As New Pais
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtIdPais.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdPais.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            pais = New Pais(txtIdPais.Text, cmbNombre.Text)
            pais.getSetIdPais = txtIdPais.Text
            pais.getSetNombre = cmbNombre.Text
            If pais.consultarRegistro = False Then
                pais.insert()
            Else
                If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    pais.update()
                    MessageBox.Show("Se actualizo correctamente el registro!")
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtIdPais.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdPais.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            pais = New Pais(txtIdPais.Text, cmbNombre.Text)
            pais.getSetIdPais = txtIdPais.Text
            pais.getSetNombre = cmbNombre.Text
            If pais.consultarRegistro Then
                pais.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If txtIdPais.Text = "" Or cmbNombre.Text = "" Or IsNumeric(txtIdPais.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            pais = New Pais(txtIdPais.Text, cmbNombre.Text)
            pais.getSetIdPais = txtIdPais.Text
            pais.getSetNombre = cmbNombre.Text
            If pais.consultarRegistro() Then
                If pais.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        pais.delete()
                    End If
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIdPais.Text = ""
        cmbNombre.Text = ""
        poblarTodo()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtIdPais.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbNombre.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
    End Sub

    Private Sub FormPais_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblarTodo()
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub
    Public Sub poblarTodo()
        pais.dataGirdView(dgv)
        pais.comboPais(cmbNombre)
    End Sub

    Private Sub txtIdPais_TextChanged(sender As Object, e As EventArgs) Handles txtIdPais.TextChanged
        If txtIdPais.Text <> "" And IsNumeric(txtIdPais.Text) = True Then
            pais.consultarID()
        End If
    End Sub
End Class