
Imports com.epson.pos

''' <summary>
	''' ドロアが閉まるかエラーステータスが返されるまでループ
	''' </summary>
	''' <remarks></remarks>
	Private Sub loopCloseDrawer()

		AddHandler m_objAPI.StatusCallback, AddressOf PrinterStatusMonitoring

		Try
			' プリンタと通信開始
			If m_objAPI.OpenMonPrinter(driver.OpenType.TYPE_PRINTER, レシートプリンタ名) = driver.ErrorCode.SUCCESS Then

				isDrawerSignal = False

				'コールバックとイベント関数の連動開始
				If m_objAPI.SetStatusBack() = driver.ErrorCode.SUCCESS Then

					Do
						If isDrawerSignal Then
							m_objAPI.CancelStatusBack()
						End If
					Loop While Not isDrawerSignal

				Else
					MessageBox.Show("コールバック関数の登録に失敗しました。", "Program09", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If

				If Not m_objAPI.CloseMonPrinter = driver.ErrorCode.SUCCESS Then
					MessageBox.Show("監視プリンタのクローズに失敗しました。", "Program09", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				End If
			Else
				MessageBox.Show("監視プリンタのオープンに失敗しました。", "Program09", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If

		Catch ex As Exception
			MessageBox.Show("StatusAPIのロードに失敗しました。", "Program09", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
		Finally
			m_objAPI.CancelStatusBack()
		End Try

	End Sub