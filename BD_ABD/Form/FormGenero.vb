Public Class FormGenero
    Dim genero As New Genero
    Private Sub btnAtras_Click(sender As Object, e As EventArgs) Handles btnAtras.Click
        FormMain.Show()
        Me.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If txtIdGenero.Text = "" Or cmbGenero.Text = "" Or IsNumeric(txtIdGenero.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            genero = New Genero(txtIdGenero.Text, cmbGenero.Text)
            genero.getSetIdGenero = txtIdGenero.Text
            genero.getSetNombre = cmbGenero.Text
            If genero.consultarRegistro = False Then
                genero.insert()
            Else
                If MessageBox.Show("Este registro ya existe!, Quieres actualizarlo?", "Confirmar", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    genero.update()
                    MessageBox.Show("Se actualizo correctamente el registro!")
                End If
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        If txtIdGenero.Text = "" Or cmbGenero.Text = "" Or IsNumeric(txtIdGenero.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            genero = New Genero(txtIdGenero.Text, cmbGenero.Text)
            genero.getSetIdGenero = txtIdGenero.Text
            genero.getSetNombre = cmbGenero.Text
            If genero.consultarRegistro Then
                genero.update()
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If txtIdGenero.Text = "" Or cmbGenero.Text = "" Or IsNumeric(txtIdGenero.Text) = False Then
            MessageBox.Show("Datos incompletos o erroneos")
        Else
            genero = New Genero(txtIdGenero.Text, cmbGenero.Text)
            genero.getSetIdGenero = txtIdGenero.Text
            genero.getSetNombre = cmbGenero.Text
            If genero.consultarRegistro() Then
                If genero.validacion() = True Then
                    MessageBox.Show("No se puede dar de baja, tiene registros en otra tabla")
                Else
                    If MessageBox.Show("¿Esta seguro?", "CONFIRMAR", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                        genero.delete()
                    End If
                End If
            Else
                MessageBox.Show("No existe ese registro!, verifique los datos")
            End If
            poblarTodo()
        End If
    End Sub

    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        txtIdGenero.Text = ""
        cmbGenero.Text = ""
        poblarTodo()
    End Sub

    Private Sub FormGenero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        poblarTodo()
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Click para limpiar cajas de texto ...")
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Click para Guardar información en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnActualizar, "Click para Actualizar la informacion en el sistema...")
        Me.ToolTip1.SetToolTip(Me.btnBorrar, "Click para Eliminar información en el sistema...")
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        txtIdGenero.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(0).Value
        cmbGenero.Text = dgv.Rows(dgv.CurrentCellAddress.Y).Cells(1).Value
    End Sub

    Public Sub poblarTodo()
        genero.dataGirdView(dgv)
        genero.comboGenero(cmbGenero)
    End Sub

    Private Sub txtIdGenero_TextChanged(sender As Object, e As EventArgs) Handles txtIdGenero.TextChanged
        If txtIdGenero.Text <> "" And IsNumeric(txtIdGenero.Text) = True Then
            genero.consultarID()
        End If
    End Sub
End Class