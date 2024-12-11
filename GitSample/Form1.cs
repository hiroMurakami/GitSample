using MySqlConnector;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GitSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "server=192.168.180.239; database=chat_board; userid=murakami; password=hirokazu;";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectSQL = "SELECT * FROM comments WHERE comment_id = 8";
                    using (MySqlCommand command = new MySqlCommand(selectSQL, connection))
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // データを確認する
                        if (dataTable.Rows.Count > 0)
                        {
                            string output = string.Join(Environment.NewLine,
                                dataTable.Rows.Cast<DataRow>().Select(row => string.Join(", ", row.ItemArray)));
                            MessageBox.Show(output, "検索結果");
                        }
                        else
                        {
                            MessageBox.Show("データが見つかりませんでした。", "情報");
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"データベースエラー: {ex.Message}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"一般的なエラー: {ex.Message}\n\n{ex.StackTrace}", "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}