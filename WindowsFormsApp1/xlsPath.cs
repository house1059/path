using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Diagnostics;


namespace PathLink
{
    /// <summary>
    /// xlsからPathLink.txtを作成する。ClosedXmlを使用
    /// </summary>
    public class XlsPath
    {

        public string FilePath { get; set; }    //データ変換ツール
       


        public XlsPath()
        {
            


        }


        /// <summary>
        /// データ変換ツールからPathLink.txtを作成する。とりあえずそのまま移植してその後リファクタリング
        /// </summary>
        public void DataConvert(string filePath)
        {
            IXLWorksheet sh = null;
            List<string> filePathList = new List<string>();


            try
            {
                //ﾃﾞｰﾀ変換ツールを開いてリストを作成します。
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XLWorkbook wb = new XLWorkbook(fs, XLEventTracking.Disabled);
                sh = wb.Worksheet("変換設定");

                //ファイルパスを抜く ｾﾙの検索が無いのでC1からC下限まで逐次検索
                for (int i = 1; i < sh.LastRowUsed().RowNumber(); i++)
                {
                    string path = sh.Cell($"D{i}").Value.ToString();
                    if (sh.Cell($"C{i}").Value.ToString() == "変換ファイル名（フルパス）" && path != "")
                    {
                        filePathList.Add(path);
                    }
                }


            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show(filePath + "が見つかりません", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }catch (System.IO.IOException)
            {
                MessageBox.Show("ﾃﾞｰﾀ変換ツールを一旦閉じてください", "Error", MessageBoxButtons.OK);
                return;
            }
            catch (System.Exception)
            {
                MessageBox.Show("変換設定のシートが見つかりませんでした", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }




            //ファイルパルの取得完了したので生死判定と拡張子判定
            if (!DeadOrAlive(filePathList))
                return;

            progress prg = new progress();
            int whole = 0;
            Stopwatch stp = new Stopwatch();
            prg.Show();

            //ﾃﾞｰﾀ取得処理を行う。
            foreach (string list in filePathList)
            {
                stp.Start();
                FileStream fs = new FileStream(list, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XLWorkbook wb = new XLWorkbook(fs, XLEventTracking.Disabled);
                prg.wholeLabel.Text = new FileInfo(list).Name;
                prg.wholeProgress.Value = whole / filePathList.Count * 100;

                int single = 0;
                foreach ( IXLWorksheet sheet in wb.Worksheets)
                {
                    prg.singleLabel.Text = sheet.Name;
                    prg.singleProgress.Value = single / wb.Worksheets.Count;

                    switch (sheet.Name)
                    {
                        case "ランプ部品":
                            break;

                        case "サウンド部品":
                            break;

                        case "モータ部品":
                            break;

                        case "選択テーブル部品":
                            break;

                        case "ＳＥＬ":
                            break;

                        case "パターン":
                            break;

                        case "ＰＡＴ":
                            break;

                        case "ＴＢ":
                            break;

                        case "関数部品":
                            break;

                        case "サウンドフレーズ部品":
                            break;

                    }
                    System.Console.WriteLine("ｼｰﾄの処理：" + sheet.Name);
                }
            }
            prg.Dispose();
            stp.Start();
            System.Console.WriteLine(stp.Elapsed);
        }

        //EEplus版
        public void DataConvertEE(string filePath)
        {
            List<string> filePathList = new List<string>();
            try
            {
                //ﾃﾞｰﾀ変換ツールを開いてリストを作成します。
                ExcelPackage excel = new ExcelPackage(new FileInfo(filePath));
                ExcelWorksheet sh = excel.Workbook.Worksheets["変換設定"];      //ｼｰﾄがない場合はnullが返る

                if (sh == null)
                {
                    MessageBox.Show("変換設定のシートが見つかりませんでした", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                for(int i = 1; i <= sh.Dimension.Rows + 1; i++)
                {
                    string path = sh.Cells[$"D{i}"].Value == null ? "": sh.Cells[$"D{i}"].Value.ToString();
                    if (sh.Cells[$"C{i}"].Value == null ? false : sh.Cells[$"C{i}"].Value.ToString().ToString() == "変換ファイル名（フルパス）" && path != "")
                    {
                        filePathList.Add(path);
                    }
                }
            }
            catch (System.IO.FileNotFoundException notFound)
            {
                MessageBox.Show(filePath + "が見つかりません" + "\n" + notFound, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (System.IO.IOException ioExp)
            {
                MessageBox.Show("ﾃﾞｰﾀ変換ツールを一旦閉じてください" + "\n" + ioExp, "Error", MessageBoxButtons.OK);
                return;
            }


            //ファイルパルの取得完了したので生死判定と拡張子判定
            if (!DeadOrAlive(filePathList))
                return;


            progress prg = new progress();
            Stopwatch stp = new Stopwatch();
            prg.wholeProgress.Maximum = filePathList.Count;
            prg.wholeProgress.Value = 0;
            prg.Show();


            //ﾃﾞｰﾀ取得処理を行う。
            foreach (string list in filePathList)
            {
                stp.Start();
                ExcelPackage excel = new ExcelPackage(new FileInfo(list));

                prg.singleProgress.Maximum = excel.Workbook.Worksheets.Count;
                prg.wholeLabel.Text = new FileInfo(list).Name;

                //計算方法　進捗/トータル
                prg.wholeProgress.Value++;
                prg.singleProgress.Value = 0;
                prg.Update();


                foreach (ExcelWorksheet sheet in excel.Workbook.Worksheets)
                {
                    prg.singleLabel.Text = sheet.Name;
                    prg.singleProgress.Value++;
                    prg.Update();
                    System.Threading.Thread.Sleep(1000);    //1秒エミュレート
                    switch (sheet.Name)
                    {
                        case "ランプ部品":
                            break;

                        case "サウンド部品":
                            break;

                        case "モータ部品":
                            break;

                        case "選択テーブル部品":
                            break;

                        case "ＳＥＬ":
                            break;

                        case "パターン":
                            break;

                        case "ＰＡＴ":
                            break;

                        case "ＴＢ":
                            break;

                        case "関数部品":
                            break;

                        case "サウンドフレーズ部品":
                            break;

                    }
                    System.Console.WriteLine("ｼｰﾄの処理：" + sheet.Name);
                }
                excel.Dispose();    //GCの前に殺す
            }

            prg.Dispose();
            stp.Start();
            System.Console.WriteLine(stp.Elapsed);


        }


        private bool DeadOrAlive(List<string> filePathList)
        {
            //ファイルパルの取得完了したので生死判定と拡張子判定
            string dedString = "";
            string dedExtension = "";
            foreach (string list in filePathList)
            {
                FileInfo info = new FileInfo(list);
                if (!File.Exists(list))
                {
                    dedString += list.ToString() + "\n";
                }

                if (!(info.Extension == ".xlsx" || info.Extension == ".xlsm"))
                {
                    dedExtension += list.ToString() + "\n";
                }
            }
            if (dedString != "")
            {
                MessageBox.Show("以下のリンクが見つかりません\n" + dedString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dedExtension != "")
            {
                MessageBox.Show("拡張子は.xlsxか.xlsmのみしか取得できません\n" + dedExtension, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }


    }
}


