Option Explicit


';;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;
';変換ファイルのリンクを探して検索リストを作成
';
';更新履歴
';2012/09/20		変換ファイルのリストのみに対応			Ver2.0.0
':2012/09/24		エクセルなしで起動可能にした			Ver2.0.1
':2012/09/25		コメント整理、起動トラップ追加			Ver2.0.2
';2012/09/26		変換失敗時のハンドラ追加			Ver2.0.3
';2012/10/02		親の検索に対応、川北君のToolに対応		Ver3.0.0
':2012/10/05		部品毎に取得する場所をデータ変換に合わせる	Ver3.0.1
':2012/10/11		Versionチェックの処理を入れる			Ver3.0.2
';2013/09/24		Analyzer用にレイヤー情報を取得する		Ver3.0.3
';2013/12/17		データ変換ツールxxx.xlsなどに対応		Ver3.0.4
';2013/12/26		部品に,が入っていた場合の対策			Ver3.0.5
';2013/12/27		関数で◎などが入っていた場合も検索可能にする	Ver3.0.6
';2014/02/14		音部と波形の親子に対応				Ver3.0.7
';2014/02/21		セルの中に改行コードが入っていたら無視		Ver3.0.8
';2014/03/24		ファイルの有効チェックを先に行う。		Ver3.0.9
';			レジューム機能の搭載				　　〃	
';2014/03/31		レジュームファイル削除のタイミングの変更	Ver3.0.10
';			出力ファイル名が同一の場合リネームできない不具合　　〃
';2014/04/23		同じ日付がある場合はトラップを入れる。		Ver3.0.11
';2014/05/16		resumファイルの特定でxlsmを追加			Ver3.0.12
';2014/05/26		エクセルリンクの更新を行うように仕様変更	Ver3.0.13
';2014/06/05		データ変換ツールと同じシートトラップを入れる。	Ver3.0.14
';			変換中のエラーを無視していたの有効に		　　〃
';2014/06/12		スレッド処理に変更				Ver3.1.0
';2014/06/19		作成後にデータの整合性をチェックする機能を追加	Ver3.1.1
';2014/07/08		xls側のVerUpに伴い名称とリンク先を変更		Ver4.1.0
';2015/02/24		シート名は前方一致でＯＫ、頭に文字が入ると排除	Ver4.1.1
';2015/03/23		In						Ver4.1.2
';2016/01/29		リンク切れの場合アドレスも出力
';			ファイルの置き場所が変更されたのでリンク変更	Ver4.1.3
';2017/07/31		workbook_open()ﾄﾘｶﾞが動かないのでvisible操作	Ver4.1.4
';;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


'====スレッド数　１～５ぐらいで設定してください。（ＣＰＵパワーが必要）
Const THREAD = 5






Const ForAppending = 8
Const ForReading = 1
Const ForWriting = 2

Const XlsMacroPath = "V:\Soft\その他\000_個人フォルダ\島田\マクロ\AddInAuto部品検索V4.xla"
Const strPathFile = "V:\Soft\その他\000_個人フォルダ\島田\マクロ\path.txt"
Const DataHead = "◎PathV4"
Const VersionMe = "V:\Soft\その他\000_個人フォルダ\島田\マクロ\◎PathVer4.1.4.vbs"
Const ThreadPath = "V:\Soft\その他\000_個人フォルダ\島田\マクロ\Lib\◎PathThreadVer1.0.0.vbs"



'--データ変換ツールに合わせる
Const l_lampSetSheet = "ランプ設定"
Const l_lampDataSheet = "ランプ部品"
Const l_sacSheet = "ＳＡＣ表"
Const l_soundDataSheet = "サウンド部品"
Const l_motorSheet = "モータ設定"
Const l_motorDataSheet = "モータ部品"
Const l_selectSheet = "選択テーブル部品"
Const l_selectSheet2 = "ｓｅｌ"
Const l_patternSheet = "パターン"
Const l_patternSheet2 = "ｐａｔ"
Const l_subTableSheet = "ＴＢ"
Const l_funcDataSheet = "関数部品"
Const l_mainCommandSheet = "メインコマンド設定"
Const l_inWatchSheet = "入力監視設定"
Const l_serialSetSheet = "シリアル設定"
Const l_soundCHSetSheet = "サウンドＣＨ設定"
Const l_soundPhraseMapSheet = "サウンドフレーズマップ"
Const l_soundPhraseDataSheet = "サウンドフレーズ部品"
Const l_subCommandSheet = "サブコマンド設定"
Const l_insCommandSheet = "内部コマンド設定"
Const l_serialLampRateSheet = "シリアルランプ輝度設定"
'-------------------------------------------------------------------
Const DataStart = "<!--Data Start-->"

Dim vrFileName				'//対象ディレクトリ内のFilesオブジェクト
Dim vrSheetName				'//対象ファイルの全シート
Dim vrSubFolder				'//子ディレクトリ
Dim vrSplit				'//フルパスを配列化した
Dim vrWkBook
Dim vrLinkName


Dim objFso				'//FileSystemObject
Dim objSrc				'//FolderObject

Dim objLogStream			'//レジューム用のファイルストリーム
Dim objExcel
Dim objRange
Dim objErrStream
Dim objShell
Dim objFileNameDic			'//最後のチェックする辞書

Dim objFile
Dim objInStr
		

Dim strStart				'//検索開始時のエクセルｱﾄﾞﾚｽを保持
Dim strDate
Dim strFileName()
Dim strFileName2			'//作成済みファイルの配列
Dim strResumePath
Dim strSheet				'//シートトラップの配列

Dim strStreamPath			'//大元のstreamのパス
Dim strStreamPathAy()			'//objStreamのパス Thred処理分作成
Dim strStreamPathAyPid()

Dim objStream				'//まとめたファイル。
Dim objStreamOpenCheck			'//開けるかのチェック用
Dim objStreamOutPutErr			'//出力ファイル失敗リスト


Dim sh					'//Shell
Dim arg					'//データ変換ツールの場所（引数で取得）

Dim blErr

Dim i,x
Dim vrDust

Dim strFileAdd()



	'//スレッド数のチェック
	If THREAD > 5 Or THREAD =< 0	Then
		MsgBox "スレッド数が正常ではありません", 2, "起動できません"
		WScript.Quit
	End If



	'//最初の処理
	strDate = Replace(date, "/", "")
	Set objFso = CreateObject("Scripting.FileSystemObject")
	Set objShell = CreateObject("Shell.Application")
	'//Versionチェックの処理
	If objFso.FileExists(VersionMe) = False Then
		If MsgBox("新しいバージョンが出ている可能性があります。" & Chr(13) & "見に行きますか？", 64 + 4 ,"New Version") = 6 Then
			objShell.Explore( objFso.GetParentFolderName(VersionMe))
			Set objFso = Nothing
			Set objShell = Nothing
			Wscript.Quit
		End If
	End If
	
	
	Set objExcel = CreateObject("Excel.Application")
	Set objInStr = new CharWideNarrow	'//使わせていただいている文字変換クラス	
	strSheet = Array(l_lampSetSheet,l_lampDataSheet,l_sacSheet,l_soundDataSheet,l_motorSheet,l_motorDataSheet,l_selectSheet,l_selectSheet2,l_patternSheet,l_patternSheet2,_
			l_subTableSheet,l_funcDataSheet,l_mainCommandSheet,l_inWatchSheet,l_serialSetSheet,l_soundCHSetSheet,l_soundPhraseMapSheet,l_soundPhraseDataSheet,_
			l_subCommandSheet,l_insCommandSheet,l_serialLampRateSheet)

	objExcel.DisplayAlerts = False


	'//pidファイルの掃除
	For x = 0 To 5
		If objFso.FileExists( objFso.GetSpecialFolder(2) & "\" & "\PathLink" & "Th" & x & ".pid" ) Then
			objFso.DeleteFile objFso.GetSpecialFolder(2) & "\" & "\PathLink" & "Th" & x & ".pid" , true
		End If
	Next






If WScript.Arguments.Count = 0 Then
'//ダブルクリック時
	'//起動トラップを追加
	IF MsgBox ("直下のディレクトリ全て検索するので少し時間がかかります", 4 + 48, "注意事項") = 6 Then '//vbYes
		Call Current	'//自分の居場所から再起処理
	Else
		Wscript.Quit
	End IF
Else
'//ファイルを渡された場合

	'//パスの構造で格納
	vrSplit = Split(WScript.Arguments(0),"\")
	arg = WScript.Arguments(0)

	'//xlsを渡されたときはデータ変換ツールか否かを判定する
	Select Case objFso.GetExtensionName(vrSplit(Ubound(vrsplit)))
		Case "xls","xlsm"
			Call DataConvert	'//データ変換ファイルからテキストを作成
	
		Case "txt"
			Call NSSsearch		'//テキストから部品検索を呼び出す
			
		Case "resume"
			Call psResume
		
		Case Else
			WScript.Echo "データ変換ツール.xlsもしくは作成されたテキストを渡してください"
			Call ErrorException			
	End Select

End If



Sub Current()
'//再帰処理を行い全◎を吸い出す


	'//Ver3.0.11の同一ネームのトラップ 【はい】⇒6　【いいえ】⇒7
	If objFso.FileExists( objFso.GetFolder(".") & "\PathAll" & strDate & "V4.txt" ) Then
		If MsgBox("同一の日付が存在します" & Chr(13) & "処理を続けますか？" , 32+4 , "注意!!") = 7 Then
			'//処理を終了する
			Call ErrorException
		End If
	End If



	strStreamPath = objFso.GetFolder(".") & "\PathAll" & strDate & "V4.txt"
	Set objStream = objFso.OpenTextFile(strStreamPath, ForWriting, True)
	objStream.WriteLine Date		'//固定データの出力
	objStream.WriteLine DataHead
	objStream.WriteLine "パス" & Chr(9) & "シート" & Chr(9) & "アドレス" & Chr(9) & "部品名" & Chr(9) & "子情報" & Chr(9) & "制御情報" & Chr(9) & "トリガー" & Chr(9) & "レイヤー"
	ReDim strFileName(0)
	psLoop2 objFso.GetFolder(".")

	'//最後に取得したファイル名と、実際に吐き出したファイル名の整合チェックを行う。(V4.1.1)
	strFileName2 = strFileName

		
	'//データ変換が途中で失敗してもレジューム可能にした（V3.0.9）
	strResumePath = objFso.GetFolder(".") & "\PathLinkLog" & strDate & "V41.resume"
	Set objLogStream = objFso.OpenTextFile(strResumePath, ForWriting, True)
	objLogStream.WriteLine Date		'//固定データの出力
	objLogStream.WriteLine DataHead & ".1"
	objLogStream.WriteLine strStreamPath
	objLogStream.WriteLine objFso.GetFolder(".")	'//実行パス
	objLogStream.WriteLine "パス" & Chr(9) & "ファイルオープン" & Chr(9) &"開始時間" & Chr(9) & "終了時間" & Chr(9) & "ファイルサイズ"
	objLogStream.WriteLine DataStart
	objLogStream.Close				'//一旦閉じる
	'//ファイル出力モジュール
	Call DataOutPut(THREAD)
	
End Sub



Sub psLoop2(ByVal src)




	Set objSrc = objFso.GetFolder(src)
	For Each vrFileName In objSrc.Files
		If objFso.GetExtensionName(vrFileName) = "xlsx" or  objFso.GetExtensionName(vrFileName) = "xls"  Then
			ReDim Preserve strFileName(UBound(strFileName)+1)
			Set objFile = objFso.GetFile(vrFileName)
			strFileName(Ubound(strFileName)-1) = objFile.path
		End If
	Next
	
	'//再帰処理
	For Each vrSubFolder In objSrc.SubFolders
		psLoop2 vrSubFolder
	Next

End Sub





Sub DataConvert()

Dim blSheet



	'//変換ファイルを渡されたとき以外は終了
	If Not InStrWord( vrSplit(Ubound(vrSplit)) ,"データ変換ツール" , True )  Then	'//文字含み判定
		WScript.Echo "データ変換ツール.xlsを渡してください"
		Call ErrorException
	End If
	
	
	'//該当シートを検索するなかったら終了
	Set vrWkBook = objExcel.Workbooks.Open (WScript.Arguments(0),1 , True)
	For Each vrSheetName In vrWkBook.Sheets
		If vrSheetName.Name = "変換設定" Then
			blSheet = True
		End If
	Next

	If blSheet = False Then
		WScript.Echo "シート【変換設定】が見つかりません"
		Call ErrorException
	End If
	Set objRange = vrWkBook.Sheets("変換設定").Cells.Find("◎",,,1,,,0)	'//シート名固定
	
	

	ReDim strFileName(0)
	'//デバッグ
	ReDim strFileAdd(0)
	If Not objRange Is Nothing Then
		strStart = objRange.ADDRESS
		i = 1
		Do
			Do While objRange.Offset(i,1).Value = "変換ファイル名（フルパス）"	'//このキーで探す
				If objRange.Offset(i,2).value <> "" Then
					ReDim Preserve strFileName(Ubound(strFileName)+1)
					ReDim Preserve strFileAdd(Ubound(strFileAdd)+1)
					strFileName(Ubound(strFileName)-1) = objRange.Offset(i,2).value
				'//	デバッグ
					strFileAdd(Ubound(strFileAdd)-1) = objRange.Offset(i,2).address
				End If
				i = i + 1
			Loop
			Set objRange = vrWkBook.Sheets("変換設定").Cells.FindNext(objRange)
			i = 1
		Loop While Not objRange Is Nothing And objRange.ADDRESS <> strStart
	End If
	vrWkBook.Saved = True
	vrWkBook.Close	


	'//ファイルの有効性チェックのみを先に行う(V3.0.9)
	'//3.0.8までは同時に行っていたので途中未完で終了する。
	For i = 0 To Ubound(strFileName)-1
		If objFso.FileExists(strFileName(i)) = False Then
			'//ファイルが見つからなかった場合はリンクが死んでいることを通知する
			If blErr = False Then
				Set objErrStream = objFso.OpenTextFile(objFso.GetParentFolderName(arg) & "\PathLinkErr" & strDate & "V4.txt", ForWriting, True)
				blErr = True
			End If
			objErrStream.Write strFileName(i)
			objErrStream.WriteLine strFileAdd(i)
		End If
	Next
	
	
	If blErr Then
		Set objErrStream = Nothing
		set objExcel = Nothing
		set objFso = Nothing
		MsgBox "変換ファイルの中に見つからないリンクがありました。" & Chr(13) & _
			"エラーログを吐き出しましたのでご確認ください" , 48 , "注意!!"
		Wscript.Quit
	End If


	'//Ver3.0.11の同一ネームのトラップ 【はい】⇒6　【いいえ】⇒7
	If objFso.FileExists( objFso.GetParentFolderName(arg) & "\PathLink" & strDate & "V4.txt") Then
		If MsgBox("同一の日付が存在します" & Chr(13) & "処理を続けますか？" , 32+4 , "注意!!") = 7 Then
			'//処理を終了する
			Call ErrorException
		End If
	End If

	'//最後に取得したファイル名と、実際に吐き出したファイル名の整合チェックを行う。(V3.1.1)
	strFileName2 = strFileName	
	

	'//データ変換が途中で失敗してもレジューム可能にした（V3.0.9）
	strResumePath = objFso.GetParentFolderName(arg) & "\PathLinkLog" & strDate & "V41.resume"
	Set objLogStream = objFso.OpenTextFile(strResumePath, ForWriting, True)	
	objLogStream.WriteLine Date		'//固定データの出力
	objLogStream.WriteLine DataHead & ".1"

	'//Thread用にオブジェクトの作成
	ReDim strStreamPathAy(THREAD-1)
	ReDim strStreamPathAyPid(THREAD-1)
	For x = 0 To THREAD-1
		'//既に存在している場合は削除
		strStreamPathAy(x) = objFso.GetParentFolderName(arg) & "\PathLink" & strDate & ".Th" & x
		If objFso.FileExists( strStreamPathAy(x) ) Then
			objFso.DeleteFile  strStreamPathAy(x) , true
		End If
		objLogStream.WriteLine strStreamPathAy(x)
		strStreamPathAyPid(x) = objFso.GetSpecialFolder(2) & "\" & "\PathLink" & "Th" & x & ".pid"
	Next
	objLogStream.WriteLine ""		'//空行を入れる。
	objLogStream.WriteLine arg		'//データ変換Tool
	objLogStream.WriteLine "パス" & Chr(9) & "ファイルオープン" & Chr(9) &"開始時間" & Chr(9) & "終了時間" & Chr(9) & "ファイルサイズ"
	objLogStream.WriteLine DataStart
	objLogStream.Close				'//一旦閉じる
	
	Call DataOutPut(THREAD)

End Sub

Sub DataOutPut(ByVal argTHREAD)
'//初回実行時とレジューム時のスレッド数を合わせる為引数を追加

Const Dlm = "@.@"	'//splitのデリミット
Const Dlm2 = "*.*"	'//スペースのデリミット

Dim objExec()	'//実行オブジェクト
Dim objPidStream
Dim args	'//ファイル名などにスペース等が有っても引数として使えるようにする。

'//ここから処理を分割して共通化する。
	Set sh = CreateObject("WScript.Shell")
	ReDim objExec(0)
	For x = 0 To argTHREAD-1
		ReDim Preserve objExec(x)
	Next
	
	
	'//全て完了がわかるようにダミープログラムをまずは走らせる。
	For x = 0 To argTHREAD-1
		Set objExec(x) = sh.Exec("wscript.exe " & ThreadPath & " " & "DMY")
	Next
	

	'//１本目は手動で起動させる。
	i = 0
	For x = 0 To argTHREAD-1
		If i >= UBound(strFileName) Then
			Exit For
		End If
		'//Thread毎にPIDを記録する。
		args = strStreamPathAy(x) & Dlm & strFileName(i) & Dlm & strResumePath & Dlm & strStreamPathAyPid(x)
		args = RePlace(args," ",Dlm2)	'//スペースを文字に変えて、引数を渡した先で戻す。
		Set objPidStream  = objFso.OpenTextFile( strStreamPathAyPid(x) , ForWriting, true)
		Set objExec(x) = sh.Exec("wscript.exe " & ThreadPath  & " " & args)
		objPidStream.Write objExec(x).ProcessID			
		objPidStream.Close
		Set objPidStream = Nothing
		i = i + 1
	Next

	'//２本目からはstatusを確認してpidを管理する。
	'//引数１：出力ファイルパス、　引数２：処理ファイル、　引数３：リジュームパス、　引数４：PIDパス
	Do While true
		If i => UBound(strFileName) Then
			Exit Do
		End If
		For x = 0 To argTHREAD-1
			If objExec(x).status = 1 Then
				args = strStreamPathAy(x) & Dlm & strFileName(i) & Dlm & strResumePath & Dlm & strStreamPathAyPid(x)
				args = RePlace(args," ",Dlm2)	'//スペースを文字に変えて、引数を渡した先で戻す。
				Set objPidStream  = objFso.OpenTextFile( strStreamPathAyPid(x) , ForWriting, true)
				Set objExec(x) = sh.Exec("wscript.exe " & ThreadPath & " " & args)				
				objPidStream.Write objExec(x).ProcessID			
				objPidStream.Close
				Set objPidStream = Nothing
				i = i + 1
				If i >= UBound(strFileName) Then
					Exit For
				End If
				Wscript.Sleep(300)	'//リソースを返す。
			End If
		Next
	Loop


	'//全てのstatusが完了になるまで待機
	For x = 0 To argTHREAD-1
		Do while objExec(x).status = 0
			Wscript.Sleep(10)
		Loop
	Next
	




	'//全て完了した後に変更する。(Ver3.1.0)
	'//エラーじゃない場合にLinkファイルを作成するようにタイミングを変更(V3.0.10)
	strStreamPath = objFso.GetParentFolderName(arg) & "\PathLink" & strDate & "V4.txt"
	Set objStream = objFso.OpenTextFile(strStreamPath, ForWriting, True)
	objStream.WriteLine Date		'//固定データの出力
	objStream.WriteLine DataHead
	objStream.WriteLine "パス" & Chr(9) & "シート" & Chr(9) & "アドレス" & Chr(9) & "部品名" & Chr(9) & "子情報" & Chr(9) & "制御情報" & Chr(9) & "トリガー" & Chr(9) & "レイヤー"

	'//各出力ファイルを１つにまとめる。
	For x = 0 To argTHREAD-1
		Set objStreamOpenCheck = objFso.OpenTextFile(strStreamPathAy(x) , ForReading, False)
		objStream.Write objStreamOpenCheck.ReadAll
		objStreamOpenCheck.Close
		objFso.DeleteFile strStreamPathAy(x) ,true
	Next
	objStream.Close
	Wscript.Sleep(50)
	
	
	
	'//全て完了した時点でファイルの整合チェックを行う（Ver3.1.1）
	'//作成したリジュームパスから配列を作成する。


	Set objFileNameDic = CreateObject("Scripting.Dictionary")
	Set objLogStream = objFso.OpenTextFile(strResumePath, ForReading,False)
	
	'// <!--Data Start>までカット
	Do while true
		vrDust = objLogStream.ReadLine
		If vrDust = DataStart Then
			Exit Do
		End If
	Loop
	
	
	'//log出力ファイルを辞書に登録
	Do Until objLogStream.AtEndOfLine
		vrSplit = Split(objLogStream.ReadLine, Chr(9))
		objFileNameDic.Add vrSplit(0),vrSplit(0)
	Loop
	
	'//strFileName2と比較し、データ変換ツール記載のファイル名が出力されていない場合はlogファイルに出力する。
	x = 0
	Do Until x = Ubound(strFileName2)-1
		If Not objFileNameDic.Exists( strFileName2(x) ) Then
			If Not objFso.FileExists(strStreamPath & ".Err") Then
				Set objStreamOutPutErr = objFso.OpenTextFile( strStreamPath & ".Err",ForWriting,True)
				objStreamOutPutErr.WriteLine	Date
				objStreamOutPutErr.WriteLine	DataHead & ".1"
			End If
			objStreamOutPutErr.WriteLine strFileName2(x)
		End If
		x = x + 1
	Loop
	
	If objFso.FileExists(strStreamPath & ".Err") Then
		objStreamOutPutErr.Close
		msgbox "出力されていないファイルが見つかりました。" & Chr(13) & strStreamPath & ".Errでご確認ください"
	End If
	
	msgbox  "全リンク完了"
	
	set objStreamOutPutErr = Nothing
	set objExcel = Nothing
	set objStream= Nothing
	set objLogStream = Nothing
	set objFso = Nothing


End Sub



Function LF_Del(Byval inStr)
'//渡されたデータからLFデータ( chr(10)）を抜いて返す


	LF_Del = Replace(inStr, chr(10), "")



End Function




Sub psResume()
'//レジュームファイルを渡された時の処理を行う。


Dim oldStream
Dim vrDust
Dim blSheet


Dim splPathLink		'//パスリンクファイルのスプリットデータ
Dim splResume		'//レジュームファイルのスプリットデータ

Dim strPathLinkFile()	'//Version4から配列で処理
Dim strPathLinkCheck

Dim strRunPath		'//実行パス
Dim x,y

Dim objDicResumeList	'//問題なしの辞書

	ReDim strPathLinkFile(0)

	'//辞書の作成
	Set objDicResumeList = CreateObject("Scripting.Dictionary")
	
	'//レジュームファイルの読み取りモードで開く
	strResumePath = WScript.Arguments(0)
	Set objLogStream = objFso.OpenTextFile(strResumePath, ForReading, True)
	vrDust = objLogStream.ReadLine	'//日付
	If objLogStream.ReadLine <> DataHead & ".1" Then	'//バージョンチェック
		MsgBox "バージョンが異なります。" & Chr(13) & _
			"本バージョンは:Ver3.1系になります。" , 48 , "注意!!"	
		objLogStream.close
		set objLogStream = Nothing
		Wscript.Quit
	End If
	
	'//PathLinkのファイルパス
	Do While True
		strPathLinkCheck = objLogStream.ReadLine
		If strPathLinkCheck = "" Then
			Exit Do
		End If
		ReDim Preserve strPathLinkFile(Ubound(strPathLinkFile)+1)
		strPathLinkFile(UBound(strPathLinkFile)-1) = strPathLinkCheck
	Loop
	
	
	strRunPath = objLogStream.ReadLine		'//ファイルなのか、実行パスなのかの判定が必要
	vrDust = objLogStream.ReadLine			'//レジュームファイルの項目
	

	'//レジュームファイルのリード位置を最後にＯＫが出た位置まで移動
	Do Until objLogStream.AtEndOfLine
		vrDust = objLogStream.ReadLine
		splResume = Split(vrDust,Chr(9))
		objDicResumeList.Add splResume(0),splResume(0)	'//完了ファイル名を辞書に登録
	Loop

	'//Threadファイルを開き、完了ファイル名と一致した場合は_newに書込む
	For x = 0 To UBound(strPathLinkFile) -1
		Set oldStream = objFso.OpenTextFile(strPathLinkFile(x), ForReading,true)
		Set objStream = objFso.OpenTextFile(strPathLinkFile(x) & "_new" , ForWriting, True)
		Do Until oldStream.AtEndOfLine
			vrDust = oldStream.ReadLine 
			splPathLink = Split(vrDust,Chr(9))	'//左のファイル名を取得）
			If objDicResumeList.Exists( splPathLink(0)) = True Then
				objStream.WriteLine vrDust
			End If
		Loop
		oldStream.Close
		objStream.Close	
	
	
	Next
	
	Set oldStream = Nothing


	For x = 0 To UBound(strPathLinkFile)-1
		objFso.CopyFile strPathLinkFile(x) & "_new", strPathLinkFile(x), True  '//OverWrite
		objFso.DeleteFile strPathLinkFile(x) & "_new" ,True 			 '//強制削除
	Next
			
	
	
	ReDim strFileName(0)
	If objFso.GetExtensionName(strRunPath) = "xls" or objFso.GetExtensionName(strRunPath) = "xlsx"  or objFso.GetExtensionName(strRunPath) = "xlsm"Then
		'//該当シートを検索するなかったら終了
		Set vrWkBook = objExcel.Workbooks.Open (strRunPath,3 , True)
		For Each vrSheetName In vrWkBook.Sheets
			If vrSheetName.Name = "変換設定" Then
				blSheet = True
			End If
		Next

		If blSheet = False Then
			WScript.Echo "シート【変換設定】が見つかりません"
			Call ErrorException
		End If
		Set objRange = vrWkBook.Sheets("変換設定").Cells.Find("◎",,,1,,,0)	'//シート名固定

		If Not objRange Is Nothing Then
			strStart = objRange.ADDRESS
			i = 1
			Do
				Do While objRange.Offset(i,1).Value = "変換ファイル名（フルパス）"	'//このキーで探す
					If objRange.Offset(i,2).value <> "" Then
						ReDim Preserve strFileName(Ubound(strFileName)+1)
						strFileName(Ubound(strFileName)-1) = objRange.Offset(i,2).value
					End If
					i = i + 1
				Loop
				Set objRange = vrWkBook.Sheets("変換設定").Cells.FindNext(objRange)
				i = 1
			Loop While Not objRange Is Nothing And objRange.ADDRESS <> strStart
		End If
		vrWkBook.Saved = True
		vrWkBook.Close	

			
	Else
		psLoop2 objFso.GetFolder(strRunPath)
	End If
		
	'//strFileNameの配列を作成して、完了しているものを排除する。
	strFileName2 = strFileName
	Redim strFileName(0)	'//一旦クリア
	
	'//辞書に登録の無いやつのみ再配置
	For y = 0 To Ubound(strFileName2) -1
		If objDicResumeList.Exists(strFileName2(y)) = False Then
			Redim Preserve strFileName(UBound(strFileName)+1)
			strFileName(Ubound(strFileName)-1) = strFileName2(y)
			objDicResumeList.Add strFileName2(y), strFileName2(y)
		End If
	Next
	Set objDicResumeList = Nothing
	


	'//レジュームファイル、datファイルを末尾から追記モードで開く
	ReDim strStreamPathAy(UBound(strPathLinkFile)-1)
	ReDim strStreamPathAyPid(UBound(strPathLinkFile)-1)
	
	For x = 0 To UBound(strPathLinkFile)-1
		strStreamPathAy(x) = objFso.GetParentFolderName(arg) & "\PathLink" & strDate & ".Th" & x
		strStreamPathAyPid(x) = objFso.GetSpecialFolder(2) & "\" & "\PathLink" & "Th" & x & ".pid"
	Next	
	

	'//レジューム開始
	Call DataOutPut(UBound(strPathLinkFile))

	

End Sub





Function InStrSheetName( ByVal sheetName )
'//引数１：シート名
'//機能：データ変換ツールと同じシートトラップでＯＫだったらＯＫ


Dim i
	For i = 0 To UBound( strSheet)
		If InStrWord( sheetName , strSheet(i) , False ) Then	'//前方一致のみ
			InStrSheetName = True
			Exit Function
		End If
	Next
	InStrSheetName = False

End Function






Function InStrWord(ByVal strString , ByVal strPattern , ByVal blLike )
'//引数１：検索対象の文字列
'//引数２：検索したい文字列
'//引数３：True⇒含み判定（Like)　False⇒前方一致判定
'//戻値：True⇒ありました。　False⇒なし
Dim objReg


Set objReg = CreateObject("VBScript.RegExp")


	If blLike = True Then
		objReg.Pattern = "(" &  strPattern & ")"
	else
		objReg.Pattern = "^" & strPattern	'//パターンが含まれているかの判定 Ver4.1.1⇒前方一致へ変更
	End If


	objReg.IgnoreCase = True
	If objReg.Test( objInStr.ToWideAll( Ucase(strString),false ) ) Then
		InStrWord = True
	Else
		InStrWord = False
	End IF
Set objReg = Nothing

End Function





Sub NSSsearch()
'//エクセルオブジェクトを作成してそこからマクロを呼び出す

Dim objSrcPathStream
Dim objWord
Dim objDoc
dim iCount

	Do Until objFso.FileExists(strPathFile) = False
		iCount = iCount + 1
		If iCount > 1000 Then
			objFso.DeleteFile strPathFile, True  '//強制削除
		End If
	Loop

	
	Set objSrcPathStream = objFso.OpenTextFile(strPathFile,ForWriting,True)
	objSrcPathStream.WriteLine WScript.Arguments(0)
	objSrcPathStream.Close
	Set objSrcPathStream = Nothing
	
	Set objExcel = CreateObject("Excel.Application")
	

	With objExcel
		.Visible = true
		.Visible = false
		.Workbooks.Open XlsMacroPath,3,True
	End With
	
End Sub





Sub ErrorException()
'//途中で何かあった時　まとめてオブジェクトの開放

	objExcel.Quit
	Set objExcel = Nothing
	Set objFso = Nothing
	Wscript.Quit

End Sub






Class CharWideNarrow
'//　よそから拾ってきたライブラリ
'// i　の宣言が無かったのでグローバルの影響を与えていた(-"-)

	Dim  widedicASCII, widedicANK, narrowdicASCII, narrowdicANK
	Dim x ,i
	
	
	Private Sub Class_Initialize()
		'コンストラクタ
		Set widedicASCII   = CreateObject("Scripting.Dictionary")
		Set widedicANK     = CreateObject("Scripting.Dictionary")
		Set narrowdicASCII = CreateObject("Scripting.Dictionary")
		Set narrowdicANK   = CreateObject("Scripting.Dictionary")

		With narrowdicANK
			'表の作成
			.Add "゜", "ﾟ"
			.Add "゛", "ﾞ"
			.Add "ヶ", "ｹ"
			.Add "ヵ", "ｶ"
			.Add "ヴ", "ｳﾞ"
			.Add "ン", "ﾝ"
			.Add "ヲ", "ｦ"
			.Add "ヱ", "ｳｪ"
			.Add "ヰ", "ｳｨ"
			.Add "ワ", "ﾜ"
			.Add "ヮ", "ﾜ"
			.Add "ロ", "ﾛ"
			.Add "レ", "ﾚ"
			.Add "ル", "ﾙ"
			.Add "リ", "ﾘ"
			.Add "ラ", "ﾗ"
			.Add "ヨ", "ﾖ"
			.Add "ョ", "ｮ"
			.Add "ユ", "ﾕ"
			.Add "ュ", "ｭ"
			.Add "ヤ", "ﾔ"
			.Add "ャ", "ｬ"
			.Add "モ", "ﾓ"
			.Add "メ", "ﾒ"
			.Add "ム", "ﾑ"
			.Add "ミ", "ﾐ"
			.Add "マ", "ﾏ"
			.Add "ポ", "ﾎﾟ"
			.Add "ボ", "ﾎﾞ"
			.Add "ホ", "ﾎ"
			.Add "ペ", "ﾍﾟ"
			.Add "ベ", "ﾍﾞ"
			.Add "ヘ", "ﾍ"
			.Add "プ", "ﾌﾟ"
			.Add "ブ", "ﾌﾞ"
			.Add "フ", "ﾌ"
			.Add "ピ", "ﾋﾟ"
			.Add "ビ", "ﾋﾞ"
			.Add "ヒ", "ﾋ"
			.Add "パ", "ﾊﾟ"
			.Add "バ", "ﾊﾞ"
			.Add "ハ", "ﾊ"
			.Add "ノ", "ﾉ"
			.Add "ネ", "ﾈ"
			.Add "ヌ", "ﾇ"
			.Add "ニ", "ﾆ"
			.Add "ナ", "ﾅ"
			.Add "ド", "ﾄﾞ"
			.Add "ト", "ﾄ"
			.Add "デ", "ﾃﾞ"
			.Add "テ", "ﾃ"
			.Add "ヅ", "ﾂﾞ"
			.Add "ツ", "ﾂ"
			.Add "ッ", "ｯ"
			.Add "ヂ", "ﾁﾞ"
			.Add "チ", "ﾁ"
			.Add "ダ", "ﾀﾞ"
			.Add "タ", "ﾀ"
			.Add "ゾ", "ｿﾞ"
			.Add "ソ", "ｿ"
			.Add "ゼ", "ｾﾞ"
			.Add "セ", "ｾ"
			.Add "ズ", "ｽﾞ"
			.Add "ス", "ｽ"
			.Add "ジ", "ｼﾞ"
			.Add "シ", "ｼ"
			.Add "ザ", "ｻﾞ"
			.Add "サ", "ｻ"
			.Add "ゴ", "ｺﾞ"
			.Add "コ", "ｺ"
			.Add "ゲ", "ｹﾞ"
			.Add "ケ", "ｹ"
			.Add "グ", "ｸﾞ"
			.Add "ク", "ｸ"
			.Add "ギ", "ｷﾞ"
			.Add "キ", "ｷ"
			.Add "ガ", "ｶﾞ"
			.Add "カ", "ｶ"
			.Add "オ", "ｵ"
			.Add "ォ", "ｫ"
			.Add "エ", "ｴ"
			.Add "ェ", "ｪ"
			.Add "ウ", "ｳ"
			.Add "ゥ", "ｩ"
			.Add "イ", "ｲ"
			.Add "ィ", "ｨ"
			.Add "ア", "ｱ"
			.Add "ァ", "ｧ"
			.Add "ー", "ｰ"
			.Add "・", "･"
			.Add "、", "､"
			.Add "」", "｣"
			.Add "「", "｢"
			.Add "。", "｡"

			'逆引き表の作成
			For Each x In .Keys
				If widedicANK.Exists( .Item(x) ) = False Then
					widedicANK.Add .Item(x), x
				End If
			Next
		End With

		With narrowdicASCII
			'表の作成
			.Add "～", "~"
			.Add "｝", "}"
			.Add "｜", "|"
			.Add "｛", "{"
			.Add "ｚ", "z"
			.Add "ｙ", "y"
			.Add "ｘ", "x"
			.Add "ｗ", "w"
			.Add "ｖ", "v"
			.Add "ｕ", "u"
			.Add "ｔ", "t"
			.Add "ｓ", "s"
			.Add "ｒ", "r"
			.Add "ｑ", "q"
			.Add "ｐ", "p"
			.Add "ｏ", "o"
			.Add "ｎ", "n"
			.Add "ｍ", "m"
			.Add "ｌ", "l"
			.Add "ｋ", "k"
			.Add "ｊ", "j"
			.Add "ｉ", "i"
			.Add "ｈ", "h"
			.Add "ｇ", "g"
			.Add "ｆ", "f"
			.Add "ｅ", "e"
			.Add "ｄ", "d"
			.Add "ｃ", "c"
			.Add "ｂ", "b"
			.Add "ａ", "a"
			.Add "‘", "`"
			.Add "＿", "_"
			.Add "＾", "^"
			.Add "］", "]"
			.Add "￥", "\"
			.Add "［", "["
			.Add "Ｚ", "Z"
			.Add "Ｙ", "Y"
			.Add "Ｘ", "X"
			.Add "Ｗ", "W"
			.Add "Ｖ", "V"
			.Add "Ｕ", "U"
			.Add "Ｔ", "T"
			.Add "Ｓ", "S"
			.Add "Ｒ", "R"
			.Add "Ｑ", "Q"
			.Add "Ｐ", "P"
			.Add "Ｏ", "O"
			.Add "Ｎ", "N"
			.Add "Ｍ", "M"
			.Add "Ｌ", "L"
			.Add "Ｋ", "K"
			.Add "Ｊ", "J"
			.Add "Ｉ", "I"
			.Add "Ｈ", "H"
			.Add "Ｇ", "G"
			.Add "Ｆ", "F"
			.Add "Ｅ", "E"
			.Add "Ｄ", "D"
			.Add "Ｃ", "C"
			.Add "Ｂ", "B"
			.Add "Ａ", "A"
			.Add "＠", "@"
			.Add "？", "?"
			.Add "＞", ">"
			.Add "＝", "="
			.Add "＜", "<"
			.Add "；", ";"
			.Add "：", ":"
			.Add "９", "9"
			.Add "８", "8"
			.Add "７", "7"
			.Add "６", "6"
			.Add "５", "5"
			.Add "４", "4"
			.Add "３", "3"
			.Add "２", "2"
			.Add "１", "1"
			.Add "０", "0"
			.Add "／", "/"
			.Add "．", "."
			.Add "－", "-"
			.Add "，", ","
			.Add "＋", "+"
			.Add "＊", "*"
			.Add "）", ")"
			.Add "（", "("
			.Add "’", "'"
			.Add "＆", "&"
			.Add "％", "%"
			.Add "＄", "$"
			.Add "＃", "#"
			.Add "”", """"
			.Add "！", "!"
			.Add "　", " "

			'逆引き表の作成
			For Each x In .Keys
				 widedicASCII.Add .Item(x), x
			Next
		End With
	End Sub

	Private Sub Class_Terminated()
		'デストラクタ
		Set widedicASCII   = Nothing
		Set widedicANK     = Nothing
		Set narrowdicASCII = Nothing
		Set narrowdicANK   = Nothing
	End Sub

	Function ToNarrowAll( byref str )
		Dim rtn, max_, char_, trns_
		rtn = ""
		max_ = len( str )
		For i = 1 to max_
			char_ = Mid( str,i,1 )
			If narrowdicASCII.Exists( char_ ) Then
				trns_ = narrowdicASCII.Item( char_ )
			Else
				If narrowdicANK.Exists( char_ ) Then
					trns_ = narrowdicANK.Item( char_ )
				Else
					trns_ = char_
				End If
			End If
			rtn = rtn & trns_
		Next 
		ToNarrowAll = rtn
	End Function

	Function ToNarrowASCII( byref str )
		Dim rtn, max_, char_, trns_
		rtn = ""
		max_ = len( str )
		For i = 1 to max_
			char_ = Mid( str,i,1 )
			If narrowdicASCII.Exists( char_ ) Then
				trns_ = narrowdicASCII.Item( char_ )
			Else
				trns_ = char_
			End If
			rtn = rtn & trns_
		Next 
		ToNarrowASCII = rtn
	End Function

	Function ToNarrowKANA( byref str )
		Dim rtn, max_, char_, trns_
		rtn = ""
		max_ = len( str )
		For i = 1 to max_
			char_ = Mid( str,i,1 )
			If narrowdicANK.Exists( char_ ) Then
				trns_ = narrowdicANK.Item( char_ )
			Else
				trns_ = char_
			End If
			rtn = rtn & trns_
		Next 
		ToNarrowKANA = rtn
	End Function

	Function ToWideAll( byref str , byval option_ )
	'//使わせてもらっておいてなんだけど
	'//引数のオプションの説明ぐらい書いといて欲しい
	
	
		Dim rtn, max_, char_, trns_, next_c, flg_nextc_trns
		rtn = ""
		max_ = len( str ) - 1
		flg_nextc_trns = False
		For i = 1 to max_
			If flg_nextc_trns = True Then
				flg_nextc_trns = False
			Else
				char_  = Mid( str, i   , 1 )
				next_c = Mid( str, i+1 , 1 )

				Select Case next_c
				Case "ﾟ" , "ﾞ" 
					If widedicANK.Exists( char_ & next_c ) Then
						char_ = char_ & next_c
						flg_nextc_trns = True
					End If				
				Case "ｨ" , "ｪ"
					If Option_ Then
						If widedicANK.Exists( char_ & next_c ) Then
							char_ = char_ & next_c
							flg_nextc_trns = True
						End If
					End If				
				Case Else
				End Select

				If widedicASCII.Exists( char_ ) Then
					trns_ = widedicASCII.Item( char_ )
				Else
					If widedicANK.Exists( char_ ) Then
						trns_ = widedicANK.Item( char_ )
					Else
						trns_ = char_
					End If
				End If
				rtn = rtn & trns_
			End If
		Next

		If flg_nextc_trns = False Then
			char_  = Right( str, 1 )
			If widedicASCII.Exists( char_ ) Then
				trns_ = widedicASCII.Item( char_ )
			Else
				If widedicANK.Exists( char_ ) Then
					trns_ = widedicANK.Item( char_ )
				Else
					trns_ = char_
				End If
			End If
			rtn = rtn & trns_
		End If

		ToWideAll = rtn
	End Function

	Function ToWideASCII( byref str )
		Dim rtn, max_, char_, trns_
		rtn = ""
		max_ = len( str )
		For i = 1 to max_
			char_  = Mid( str,i, 1 )
			If widedicASCII.Exists( char_ ) Then
				trns_ = widedicASCII.Item( char_ )
			Else
				trns_ = char_
			End If
			rtn = rtn & trns_
		Next

		ToWideASCII = rtn
	End Function

	Function ToWideKANA( byref str , byval option_ )
		Dim rtn, max_, char_, trns_, next_c, flg_nextc_trns
		rtn = ""
		max_ = len( str ) - 1
		flg_nextc_trns = False
		For i = 1 to max_
			If flg_nextc_trns = True Then
				flg_nextc_trns = False
			Else
				char_  = Mid( str, i   , 1 )
				next_c = Mid( str, i+1 , 1 )

				Select Case next_c
				Case "ﾟ" , "ﾞ"
					If widedicANK.Exists( char_ & next_c ) Then
						char_ = char_ & next_c
						flg_nextc_trns = True
					End If				
				Case "ｨ" , "ｪ"
					If option_ Then
						If widedicANK.Exists( char_ & next_c ) Then
							char_ = char_ & next_c
							flg_nextc_trns = True
						End If
					End If				
				Case Else
				End Select

				If widedicANK.Exists( char_ ) Then
					trns_ = widedicANK.Item( char_ )
				Else
					trns_ = char_
				End If
				rtn = rtn & trns_
			End If
		Next

		If flg_nextc_trns = False Then
			char_  = Right( str, 1 )
			If widedicANK.Exists( char_ ) Then
				trns_ = widedicANK.Item( char_ )
			Else
				trns_ = char_
			End If
			rtn = rtn & trns_
		End If

		ToWideKANA = rtn
	End Function
End Class

