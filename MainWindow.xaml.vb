Imports Microsoft.Win32
Imports System.IO
Class MainWindow

    Dim BrushBorder As New SolidColorBrush
    Dim BrushBackground As New SolidColorBrush
    Dim rtb As RenderTargetBitmap
    Private sfd As New SaveFileDialog

    Private Sub Slider7_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider7.ValueChanged
        Try
            BrushBorder.Color = Color.FromArgb(CType(Slider7.Value, Byte), CType(Slider8.Value, Byte), CType(Slider9.Value, Byte), CType(Slider10.Value, Byte))
            Border3.BorderBrush = BrushBorder
            TextBlock11.Text = CType(Slider7.Value, Byte)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Slider8_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider8.ValueChanged
        Try
            BrushBorder.Color = Color.FromArgb(CType(Slider7.Value, Byte), CType(Slider8.Value, Byte), CType(Slider9.Value, Byte), CType(Slider10.Value, Byte))
            Border3.BorderBrush = BrushBorder
            TextBlock12.Text = CType(Slider8.Value, Byte)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Slider9_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider9.ValueChanged
        Try
            BrushBorder.Color = Color.FromArgb(CType(Slider7.Value, Byte), CType(Slider8.Value, Byte), CType(Slider9.Value, Byte), CType(Slider10.Value, Byte))
            Border3.BorderBrush = BrushBorder
            TextBlock13.Text = CType(Slider9.Value, Byte)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Slider10_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider10.ValueChanged
        Try
            BrushBorder.Color = Color.FromArgb(CType(Slider7.Value, Byte), CType(Slider8.Value, Byte), CType(Slider9.Value, Byte), CType(Slider10.Value, Byte))
            Border3.BorderBrush = BrushBorder
            TextBlock14.Text = CType(Slider10.Value, Byte)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Slider11_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider11.ValueChanged
        Try
            BrushBackground.Color = Color.FromArgb(CType(Slider11.Value, Byte), CType(Slider12.Value, Byte), CType(Slider13.Value, Byte), CType(Slider14.Value, Byte))
            Border3.Background = BrushBackground
            TextBlock20.Text = CType(Slider11.Value, Byte)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Slider12_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider12.ValueChanged
        Try
            BrushBackground.Color = Color.FromArgb(CType(Slider11.Value, Byte), CType(Slider12.Value, Byte), CType(Slider13.Value, Byte), CType(Slider14.Value, Byte))
            Border3.Background = BrushBackground
            TextBlock21.Text = CType(Slider12.Value, Byte)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Slider13_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider13.ValueChanged
        Try
            BrushBackground.Color = Color.FromArgb(CType(Slider11.Value, Byte), CType(Slider12.Value, Byte), CType(Slider13.Value, Byte), CType(Slider14.Value, Byte))
            Border3.Background = BrushBackground
            TextBlock22.Text = CType(Slider13.Value, Byte)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Slider14_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider14.ValueChanged
        Try
            BrushBackground.Color = Color.FromArgb(CType(Slider11.Value, Byte), CType(Slider12.Value, Byte), CType(Slider13.Value, Byte), CType(Slider14.Value, Byte))
            Border3.Background = BrushBackground
            TextBlock23.Text = CType(Slider14.Value, Byte)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Window_Loaded(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles MyBase.Loaded
        For Each f In Fonts.SystemFontFamilies
            ComboBox1.Items.Add(f)
            ComboBox1.SelectedIndex = 0
        Next f
        For Each myBrushes In GetType(Brushes).GetProperties
            ComboBox2.Items.Add(myBrushes.Name)
            ComboBox2.SelectedIndex = 7
        Next
        Dim fontValues() As Integer = {8, 9, 10, 11, 12, 13, 14, 15, 16, 18, 20, 22, 24, 26, 28, 32, 36, 40, 48, 56, 64, 72, 96}
        For Each fs In fontValues
            ComboBox3.Items.Add(fs)
            ComboBox3.SelectedIndex = 4
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button1.Click
        Try
            rtb = New RenderTargetBitmap(CType(Border8.ActualWidth, Integer), CType(Border8.ActualHeight, Integer), 96, 96, PixelFormats.Pbgra32)
            rtb.Render(Border3)
            Image1.Source = rtb
            Image1.Stretch = Stretch.None
            sfd.Filter = "Png files (*.png)|*.png"
            sfd.Title = "Saving to file"
            sfd.FileName = "myImage"
            sfd.AddExtension = True
            If sfd.ShowDialog = True Then
                Dim png As New PngBitmapEncoder()
                png.Frames.Add(BitmapFrame.Create(rtb))
                Dim stm As Stream = File.Create(sfd.FileName)
                png.Save(stm)
                stm.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button2.Click
        Application.Current.Shutdown()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button3.Click
        If TextBox1.Text <> Nothing Then
            TextBlock29.Text = TextBox1.Text
        Else
            MessageBox.Show("github100", "azul100", MessageBoxButton.OK, MessageBoxImage.Error)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button4.Click
        TextBox1.Text = "github"
        TextBlock29.Text = String.Empty
        TextBlock29.Effect = Nothing
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button5.Click
        shadow = Not shadow
        If shadow = True Then
            If TextBox1.Text <> Nothing Then
                TextBlock29.Effect = New System.Windows.Media.Effects.DropShadowEffect
                Button5.Content = "github+1"
            Else
                MessageBox.Show("github100", "azul100", MessageBoxButton.OK, MessageBoxImage.Error)
            End If
        Else
            TextBlock29.Effect = Nothing
            Button5.Content = "github"
        End If
    End Sub

    Dim shadow As Boolean
    Dim sizeFont As New Size

    Private Sub ComboBox3_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox3.SelectionChanged
        TextBlock29.FontSize = ComboBox3.SelectedItem
    End Sub

End Class
